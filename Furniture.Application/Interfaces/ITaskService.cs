using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Furniture.Application.Dtos;
using Furniture.Application.Models.Task;
using Furniture.Application.Models.Common;
using Furniture.Application.Models.User;

namespace Furniture.Application.Interfaces
{
    public interface ITaskService
    {
        Task<ApiResult<bool>> Create(TaskCreateRequest request);
        Task<ApiResult<bool>> Update(TaskUpdateRequest request);
        Task<ApiResult<PagedResult<TaskDto>>> SearchTaskPaging(SearchTaskRequest request);

        Task<ApiResult<PagedResult<TaskDto>>> SearchMyPickedTaskPaging(SearchTaskRequest request);

        Task<ApiResult<PagedResult<TaskDto>>> SearchMyOwnTaskPaging(SearchTaskRequest request);

        Task<ApiResult<PagedResult<TaskDto>>> GetListTaskPagingByUserId(GetListTaskPagingByUserIdRequest request);
        Task<ApiResult<TaskDto>> GetById(int id);
        Task<ApiResult<bool>> Delete(int id);
        Task<ApiResult<bool>> UpdateStatus(int TaskId, string status, string updatedBy);
    }
}
