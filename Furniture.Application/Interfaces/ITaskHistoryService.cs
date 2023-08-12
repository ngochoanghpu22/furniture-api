using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Furniture.Application.Dtos;
using Furniture.Application.Models.Task;
using Furniture.Application.Models.Common;

namespace Furniture.Application.Interfaces
{
    public interface ITaskHistoryService
    {

        Task<ApiResult<bool>> Create(TaskHistoryCreateRequest request);

        Task<ApiResult<PagedResult<TaskHistoryDto>>> GetListPagingByUser(GetListPagingRequest request, string ownerBy);

        Task<ApiResult<PagedResult<TaskHistoryClientDto>>> GetListPagingByClient(GetListPagingRequest request, string ownerBy);
    }
}
