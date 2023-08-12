using System;
using System.Collections.Generic;
using System.Text;
using Furniture.Application.Models.Common;

namespace Furniture.Application.Models.UserTask
{
    public class UsersPickedTaskRequest : PagingRequestBase
    {
        public int TaskId { get; set; }
    }
}
