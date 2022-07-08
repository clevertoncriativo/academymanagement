using academymanagement.Domain.Entities.Base;

namespace academymanagement.Domain.Entities
{
    public class CustomerAddress : Address
    {
        public Customer Customer { get; set; }
    }
}
