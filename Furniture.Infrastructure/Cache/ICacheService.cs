using System;
using System.Collections.Generic;
using System.Text;

namespace PCMS.Infrastructure.Cache
{
    public interface ICacheService
    {
        void AddCache<T>(string key, T data);
        T GetCache<T>(string key);
    }
}
