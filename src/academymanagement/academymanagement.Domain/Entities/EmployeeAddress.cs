using academymanagement.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;
namespace academymanagement.Domain.Entities
{
    public class EmployeeAddress : Address
    {
        public Employee Employee { get; set; }
    }
}
