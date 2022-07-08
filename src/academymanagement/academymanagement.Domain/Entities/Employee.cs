using academymanagement.Domain.Entities.Base;
using System;

namespace academymanagement.Domain.Entities
{
    public class Employee : EntityBase
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Cpf { get; set; }
        public string DocumentNumber { get; set; }
        public decimal Salary { get; set; }
        public int PositionId { get; set; }
        public EmployeePosition Position { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public bool IsEnabled { get; set; }
        public int AddressId { get; set; }
        public EmployeeAddress Address { get; set; }
    }
}
