using System;
using System.Collections.Generic;

#nullable disable

namespace NorthWind.UI.Models
{
    public partial class JobHistory
    {
        public int? EmployeeId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string JobId { get; set; }
        public int? DepartmentId { get; set; }
    }
}
