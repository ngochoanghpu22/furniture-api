﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Furniture.Application.Models.User
{
    public class UserPasswordChangeRequest
    {
        public int Id { get; set; }

        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
