﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Furniture.Application.Models.Common
{
    public class ApiSuccessResult<T> : ApiResult<T>
    {
        public ApiSuccessResult(T resultObj)
        {
            IsSuccessed = true;
            ResultObj = resultObj;
        }

        public ApiSuccessResult()
        {
            IsSuccessed = true;
        }

        public ApiSuccessResult(string message)
        {
            IsSuccessed = false;
            Message = message;
        }
    }
}