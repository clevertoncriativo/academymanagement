using academymanagement.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace academymanagement.Domain.Entities
{
    public class Customer : EntityBase
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int AddressId { get; set; }
        public CustomerAddress Address { get; set; }
        public int ModalityId { get; set; }
        public SportModality Modality { get; set; }
        public int PlanId { get; set; }
        public Plan Plan { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public bool IsEnabled { get; set; }
        public IEnumerable<Billing> Billings { get; set; }

    }
}
