using System;
using System.Collections.Generic;
using System.Text;
using Furniture.Application.Models.Common;

namespace Furniture.Application.Models.Task
{
    public class SearchTaskRequest : PagingRequestBase
    {
        public string Keyword { get; set; }

        public string UserName { get; set; }
    }

}
