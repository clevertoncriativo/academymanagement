namespace academymanagement.Domain.Entities.Base
{
    public abstract class Address : EntityBase
    {
        public string Number { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ContactPhone { get; set; }
        public string CellPhone { get; set; }
    }
}
