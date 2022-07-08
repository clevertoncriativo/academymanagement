using academymanagement.Domain.Entities.Base;
using academymanagement.Domain.Enums;

namespace academymanagement.Domain.Entities
{
    public class Plan : EntityBase
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public BillingCycle BillingCycle { get; set; }
    }
}
