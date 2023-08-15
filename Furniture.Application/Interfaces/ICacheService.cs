using System;
using System.Collections.Generic;
using System.Text;

namespace Furniture.Application.Interfaces
{
    public interface ICacheService
    {
        void AddCache<T>(string key, T data);
        T GetCache<T>(string key);
    }
}
