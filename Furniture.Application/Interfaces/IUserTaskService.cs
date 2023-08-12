using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Furniture.Application.Dtos;
using Furniture.Application.Models.Task;
using Furniture.Application.Models.Common;
using Furniture.Application.Models.UserTask;

namespace Furniture.Application.Interfaces
{
    public interface IUserTaskService
    {
        Task<ApiResult<bool>> PickTask(UserTaskCreateRequest request);
        Task<ApiResult<TaskDto>> ViewTaskDetail(int taskId);
        Task<ApiResult<bool>> FinishTask(UserTaskUpdateRequest request);
        Task<ApiResult<PagedResult<TaskDto>>> GetTaskListPaging(GetListTaskPagingByUserIdRequest request);
        Task<ApiResult<UserEarningDto>> ViewEarning(UserEarningRequest request);
        Task<ApiResult<PagedResult<UsersPickedTaskDto>>> ViewUsersPickedTask(UsersPickedTaskRequest request);
    }
}
