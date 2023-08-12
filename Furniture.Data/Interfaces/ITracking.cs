using System;
using System.Collections.Generic;
using System.Text;

namespace Furniture.Data.Interfaces
{
    public interface ITracking
    {
        DateTime CreatedDate { get; set; }

        DateTime? UpdatedDate { get; set; }

        string CreatedBy { get; set; }

        string UpdatedBy { get; set; }
    }
}
