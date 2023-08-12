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
using System.Collections.Generic;
using Task = System.Threading.Tasks.Task;
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
        private readonly IFileStorageService _fileStorageService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IFileStorageService fileStorageService,IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileStorageService = fileStorageService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResult<UserDto>> Authenticate(LoginRequest request)
        {
            var user = await _unitOfWork.UserRepository.FindAll(x => x.Email == request.Email).FirstOrDefaultAsync();

            ValidateUser(user, request);

            var token = GenerateToken(user);

            var userDto = _mapper.Map<User, UserDto>(user);
            userDto.Token = token;

            return new ApiSuccessResult<UserDto>(userDto);
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
                new Claim(ClaimConstants.Email, user.Email)
            };

            var tokenConfig = new JwtSecurityToken(EnvironmentConfig.Issuer, 
                                             EnvironmentConfig.Audience,
                                             claims,
                                             expires: DateTime.Now.AddMinutes(15),
                                             signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenConfig);

            return token;
        }

        public async Task<ApiResult<bool>> ChangePassword(UserPasswordChangeRequest request)
        {
            var user = _unitOfWork.UserRepository.FindAll().Where(u => u.Id == request.Id).FirstOrDefault();
            if (user == null)
                return new ApiErrorResult<bool>("User không tồn tại");
            var passwordDecrypt = Cryptography.DecryptString(user.Password);

            if (passwordDecrypt != request.CurrentPassword)
                throw new Exception("Mật khẩu hiện tại không đúng");
            var passwordEncrypt = Cryptography.EncryptString(request.NewPassword);
            user.Password = passwordEncrypt;
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.Commit();
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Delete(int id)
        {
            var user = _unitOfWork.UserRepository.FindAll().Where(u => u.Id == id).FirstOrDefault();
            if (user == null)
            {
                return new ApiErrorResult<bool>("User không tồn tại");
            }
            _unitOfWork.UserRepository.Remove(user);
            await _unitOfWork.Commit();
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> ForgotPassword(ForgotPasswordRequest request)
        {
            var query = _unitOfWork.UserRepository.FindAll();
            if (request.Account != null)
            {
                query = query.Where(x => x.Email.Equals(request.Account) || x.Email.Equals(request.Account));

            }
            var user = await query.FirstOrDefaultAsync();
            if (user == null)
                return new ApiErrorResult<bool>("Tài khoản hoặc email không tồn tại");
            // Sending email for user
            await SendMailForgotPassword(user);
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<UserDto>> GetById(int id)
        {
            var user = await _unitOfWork.UserRepository.FindAll().Where(u => u.Id == id).FirstOrDefaultAsync();
            if (user == null)
            {
                return new ApiErrorResult<UserDto>("User không tồn tại");
            }

            // will use auto mapper
            var dto = new UserDto();
            dto.Id = user.Id;
            dto.Email = user.Email;
            dto.Phone = user.Phone;
            dto.Name = user.Name;
            dto.Role = user.Role;
            dto.Status = user.Status;
            dto.Avatar = user.Avatar;

            return new ApiSuccessResult<UserDto>(dto);
        }

        public async Task<ApiResult<List<UserDto>>> GetClients()
        {
            var users = await _unitOfWork.UserRepository.FindAll().Where(u => u.Role == RoleConstants.AdminRoleName)
                                             .Select(r => new UserDto
                                             {
                                                 Id = r.Id,
                                                 Name = r.Name,
                                                 Email = r.Email
                                             }).ToListAsync();

            return new ApiSuccessResult<List<UserDto>>(users);
        }

        public async Task<ApiResult<PagedResult<UserDto>>> GetUsersPaging(GetUserPagingRequest request)
        {
            var query = _unitOfWork.UserRepository.FindAll(u => u.Role != RoleConstants.AdminRoleName.ToString());

            if (request.Role == RoleConstants.AdminRoleName)
            {
                query = query.Where(u => u.Role != RoleConstants.AdminRoleName.ToString() &&
                                         u.Role != RoleConstants.AdminRoleName.ToString());
            }
            
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.Email.Contains(request.Keyword)
                 || x.Phone.Contains(request.Keyword));
            }

            // sort
            switch (request.SortProp)
            {
                case "name":
                    if (request.SortOrder == SortDirection.DESC.ToString())
                    {
                        query = query.OrderByDescending(t => t.Name);
                    }
                    else
                    {
                        query = query.OrderBy(t => t.Name);
                    }

                    break;

                case "role":
                    if (request.SortOrder == SortDirection.DESC.ToString())
                    {
                        query = query.OrderByDescending(t => t.Role);
                    }
                    else
                    {
                        query = query.OrderBy(t => t.Role);
                    }

                    break;

                case "status":
                    if (request.SortOrder == SortDirection.DESC.ToString())
                    {
                        query = query.OrderByDescending(t => t.Status);
                    }
                    else
                    {
                        query = query.OrderBy(t => t.Status);
                    }

                    break;

                default:
                    query = query.OrderByDescending(t => t.CreatedDate);
                    break;
            }

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageNumber) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new UserDto()
                {
                    Email = x.Email,
                    Id = x.Id,
                    Name = x.Name,
                    Phone = x.Phone,
                    Role = x.Role,
                    Status = x.Status,
                    Avatar = x.Avatar
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<UserDto>()
            {
                TotalCount = totalRow,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<UserDto>>(pagedResult);
        }

        public async Task<ApiResult<bool>> Register(RegisterRequest request)
        {
            var user = _unitOfWork.UserRepository.FindAll(x => x.Email == request.UserName)
                .Select(u => new UserDto()
                {
                    Email = u.Email
                }).FirstOrDefault();

            if (user != null)
            {
                return new ApiErrorResult<bool>("Tài khoản đã tồn tại");
            }

            string password = Cryptography.EncryptString(request.Password);

            // will using automap for this manual
            var userEntity = new User()
            {
                Email = request.Email,
                Name = request.Name,
                Phone = request.Phone,
                Role = request.Role,
                Status = UserStatus.Active.ToString(),
                Avatar = CommonConstants.NoAvatar
            };

            _unitOfWork.UserRepository.Add(userEntity);

            await _unitOfWork.Commit();
            
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<UserDto>> SearchUser(SearchUserRequest request)
        {
            var query = _unitOfWork.UserRepository.FindAll();
            if (request.UserName != null)
            {
                query = query.Where(x => x.Email.Equals(request.Email));

            }
            if (request.Email != null)
            {
                query = query.Where(x => x.Email.Equals(request.Email));
            }
            if (request.Phone != null)
            {
                query = query.Where(x => x.Phone.Equals(request.Phone));
            }
            var user = await query.FirstOrDefaultAsync();
            if (user == null)
                return new ApiErrorResult<UserDto>("Không có data");
            // will using auto mapper
            var dto = new UserDto();
            dto.Id = user.Id;
            dto.Email = user.Email;
            dto.Phone = user.Phone;
            dto.Name = user.Name;
            dto.Role = user.Role;
            dto.Status = user.Status;
            dto.Avatar = _fileStorageService.GetFileUrl(user.Avatar);

            return new ApiSuccessResult<UserDto>(dto);

        }

        public async Task<ApiResult<UserDto>> UpdateInfo(UserUpdateRequest request)
        {
            var query = _unitOfWork.UserRepository.FindAll();
            if (await query.AnyAsync(x => x.Email == request.Email && x.Id != request.Id))
            {
                return new ApiErrorResult<UserDto>("Username is existed.");
            }

            var user = query.FirstOrDefault(u => u.Id == request.Id);
            if (user == null)
            {
                return new ApiErrorResult<UserDto>("Account is not found.");
            }

            user.Name = request.Name;
            user.Email = request.Email;
            user.Phone = request.Phone;
            user.UpdatedBy = request.UpdatedBy;
            
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.Commit();

            //using mapper repplace for this manual
            UserDto dto = new UserDto();
            dto.Id = user.Id;
            dto.Email = user.Email;
            dto.Phone = user.Phone;
            dto.Name = user.Name;
            dto.Role = user.Role;
            dto.Status = user.Status;
            dto.Avatar = user.Avatar;

            return new ApiSuccessResult<UserDto>(dto);
        }

        public async Task<ApiResult<string>> UpdateAvatar(UserDocumentRequest request)
        {
            var user = _unitOfWork.UserRepository.FindAll().Where(u => u.Id == request.Id).FirstOrDefault();
            if (user == null)
            {
                return new ApiErrorResult<string>("User không tồn tại");
            }

            if (request.FileName != null)
            {
                user.Avatar = await this.SaveFile(request);
            }

            _unitOfWork.UserRepository.Update(user);

            await _unitOfWork.Commit();

            return new ApiSuccessResult<string>(user.Avatar);
        }

        public async Task<ApiResult<bool>> DeleteAvatar(int id)
        {
            var user = _unitOfWork.UserRepository.FindAll().Where(u => u.Id == id).FirstOrDefault();
            if (user == null)
            {
                return new ApiErrorResult<bool>("User không tồn tại");
            }
            user.Avatar = null;
            user.UpdatedDate = DateTime.Now;
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.Commit();

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> UpdateStatus(int userId, string status, string currentUserName)
        {
            var user = await _unitOfWork.UserRepository.FindAll().Where(u => u.Id == userId).FirstOrDefaultAsync();

            if (user == null)
            {
                return new ApiErrorResult<bool>("User was not existed.");
            }

            if (user.Role == RoleConstants.AdminRoleName)
            {
                return new ApiErrorResult<bool>("You cannot update status of Super Admin.");
            }

            user.Status = status;
            user.UpdatedBy = currentUserName;

            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.Commit();

            return new ApiSuccessResult<bool>();
        }

        private async Task<string> SaveFile(UserDocumentRequest request)
        {
            var filePath = await _fileStorageService.SaveFileAsync(request);

            return filePath;
        }

        public async Task<ApiResult<string>> Activate(string code)
        {
            try
            {
                code = Cryptography.DecryptString(code);
            }
            catch { }
            var user = _unitOfWork.UserRepository.FindAll().Where(u => u.Email == code).FirstOrDefault();
            if (user == null)
            {
                return new ApiErrorResult<string>("Kích hoạt tài khoản không thành công");
            }
            user.UpdatedDate = DateTime.Now;
            user.Status = UserStatus.Active.ToString();
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.Commit();
            return new ApiSuccessResult<string>("Kích hoạt tài khoản thành công");
        }

        private string BuildActivateUserTemplate(string name, string url)
        {
            var html = new StringBuilder();
            html.Append("<h1>Welcome!</h1>" +
               "<p> Hello <strong style = 'font-family: Avenir,Helvetica,sans-serif; box-sizing: border-box;' >" +
               name +
               "</strong> ! <br /><br /> Thank you for registering on our platform.You're almost ready to start.<br /><br />Simply click the button below to confirm your email address and active your account.</p>" +
               "<table style = 'font-family: Avenir,Helvetica,sans-serif; box-sizing: border-box; margin: 30px auto; padding: 0; text-align: center; width: 100%;' width = '100%' cellspacing = '0' cellpadding = '0' align = 'center' >" +
               "<tbody> <tr><td style = 'font-family: Avenir,Helvetica,sans-serif; box-sizing: border-box;' align = 'center' >" +
               "<table style = 'font-family: Avenir,Helvetica,sans-serif; box-sizing: border-box;' border = '0' width = '100%' cellspacing = '0' cellpadding = '0'>" +
               "<tbody> <tr> <td style = 'font-family: Avenir,Helvetica,sans-serif; box-sizing: border-box;' align = 'center' >" +
               "<table style = 'font-family: Avenir,Helvetica,sans-serif; box-sizing: border-box;' border = '0' cellspacing = '0' cellpadding = '0'>" +
               "<tbody> <tr> <td style = 'font-family: Avenir,Helvetica,sans-serif; box-sizing: border-box;' ><a href='" +
               url +
               "' style = 'font-family: Avenir,Helvetica,sans-serif; box-sizing: border-box; border-radius: 3px; color: #fff; display: inline-block; text-decoration: none; background-color: #16a1fd; border-top: 10px solid #16a1fd; border-right: 18px solid #16a1fd; border-bottom: 10px solid #16a1fd; border-left: 18px solid #16a1fd;' target = '_blank' > Confirm Email Address </a></td>" +
               "</tr> </tbody> </table> </td> </tr> </tbody> </table> </td> </tr> </tbody> </table>" +
               "<hr style = 'font-family: Avenir,Helvetica,sans-serif; box-sizing: border-box;' />" +
               "<p style = 'font-family: Avenir,Helvetica,sans-serif; box-sizing: border-box; color: #74787e; font-size: 16px; line-height: 1.5em; margin-top: 0; text-align: left; margin-bottom: 0; padding-bottom: 0;' > Best Regards, <br/> Furniture Teams </p>"
               );
            return html.ToString();
        }

        private string BuildForgotPasswordTemplate(string password, string userName)
        {
            var html = new StringBuilder();
            html.Append("<p> Hello <strong style = 'font-family: Avenir,Helvetica,sans-serif; box-sizing: border-box;' >" +
               userName +
               "</strong> ! <br /><br /> Thông tin mật khẩu của bạn là:"+ password +"<br /><br /> </p> " +
               "<table style = 'font-family: Avenir,Helvetica,sans-serif; box-sizing: border-box; margin: 30px auto; padding: 0; text-align: center; width: 100%;' width = '100%' cellspacing = '0' cellpadding = '0' align = 'center' >" +
               "<tbody> <tr><td style = 'font-family: Avenir,Helvetica,sans-serif; box-sizing: border-box;' align = 'center' >" +
               "<hr style = 'font-family: Avenir,Helvetica,sans-serif; box-sizing: border-box;' />" +
               "<p style = 'font-family: Avenir,Helvetica,sans-serif; box-sizing: border-box; color: #74787e; font-size: 16px; line-height: 1.5em; margin-top: 0; text-align: left; margin-bottom: 0; padding-bottom: 0;' > Best Regards, <br/> Furniture Teams </p>"
               );
            return html.ToString();
        }

        private async Task SendMailForgotPassword(User user)
        {
            string password = Cryptography.DecryptString(user.Password);
            var message = BuildForgotPasswordTemplate(password, user.Email);
            //await _emailService.SendEmail(user.Email, "Lấy lại mật khẩu", message);

            await Task.Run(() => 1);
        }
    }
}
