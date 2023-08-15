using Furniture.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Furniture.Application.Interfaces;
using Furniture.Application.Models.Common;
using Furniture.Application.Models.User;
using Furniture.Utilities.Helpers;
using Furniture.Application.Dtos;
using static Furniture.Utilities.Enums;
using Furniture.Utilities.Constants;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using PCMS.Infrastructure.UoW;

namespace Furniture.Application.Implementation
{
    public class UserService : IUserService
    {      
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResult<UserDto>> SignIn(LoginRequest request)
        {
            var user = await _unitOfWork.UserRepository.FindAll(x => x.Email == request.Email).FirstOrDefaultAsync();

            ValidateUser(user, request);

            var token = GenerateToken(user);

            var userDto = _mapper.Map<User, UserDto>(user);
            userDto.Token = token;

            return new ApiSuccessResult<UserDto>(userDto);
        }

        public async Task<ApiResult<bool>> Signup(RegisterRequest request)
        {
            var isValidEmail = EmailHelper.IsValidEmail(request.Email);

            if (!isValidEmail)
            {
                return new ApiErrorResult<bool>(ErrorMessageConstants.InvalidEmail);
            }

            var isValidPhone = PhoneNumberHelper.IsValidPhoneNumber(request.Phone);

            if (!isValidPhone)
            {
                return new ApiErrorResult<bool>(ErrorMessageConstants.InvalidPhoneNumber);
            }

            var isExistedUser = _unitOfWork.UserRepository.FindAll(x => x.Email == request.Email).Any();

            if (isExistedUser)
            {
                return new ApiErrorResult<bool>(ErrorMessageConstants.ExistedEmail);
            }

            request.Password = Cryptography.EncryptString(request.Password);

            var userEntity = _mapper.Map<RegisterRequest, User>(request);
            userEntity.CreatedBy = CommonConstants.CreatedBySystem;

            _unitOfWork.UserRepository.Add(userEntity);

            await _unitOfWork.Commit();
            
            return new ApiSuccessResult<bool>();
        }

        private void ValidateUser(User user, LoginRequest request)
        {
            if (user == null)
            {
                throw new ArgumentException(ErrorMessageConstants.NotExistedEmail);
            }

            var passwordDecrypt = Cryptography.DecryptString(user.Password);

            if (passwordDecrypt != request.Password)
            {
                throw new ArgumentException(ErrorMessageConstants.IncorrectPassword);
            }


            if (user.Status == UserStatus.Locked.ToString())
            {
                throw new ArgumentException(ErrorMessageConstants.LockedAccount);
            }
        }

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(EnvironmentConfig.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimConstants.UserId, user.Id.ToString()),
                new Claim(ClaimConstants.Role, user.Role),
                new Claim(ClaimConstants.Email, user.Email),
                new Claim(ClaimConstants.Name, user.Name)
            };

            var tokenConfig = new JwtSecurityToken(EnvironmentConfig.Issuer,
                                             EnvironmentConfig.Audience,
                                             claims,
                                             expires: DateTime.Now.AddDays(7),
                                             signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenConfig);

            return token;
        }
    }
}
