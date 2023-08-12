using System;
using System.Collections.Generic;
using System.Text;
using Furniture.Application.Models.Task;

namespace Furniture.Application.Interfaces
{
    public interface IUserTaskConfigService
    {
        void Create(UserTaskConfigCreateRequest model);
        void Update(UserTaskConfigUpdateRequest model);
        void Delete(int id);
    }
}
