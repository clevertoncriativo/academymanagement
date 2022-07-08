using System.ComponentModel;

namespace academymanagement.Domain.Enums
{
    public enum BillingStatus
    {
        [Description("Aberta")]
        Open = 'O',
        [Description("Paga")]
        Paid = 'P',
        [Description("Cancelada")]
        Cancel = 'C',
    }
}
