using academymanagement.Domain.Entities.Base;
using academymanagement.Domain.Enums;
using System;

namespace academymanagement.Domain.Entities
{
    public class Billing : EntityBase
    {
        public BillingStatus Status { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal Value { get; set; }
        public decimal PaidValue { get; set; }
        public DateTime? DueDate { get; set; }
        public Billing()
        {
            this.Status = BillingStatus.Open;
        }
    }
}
