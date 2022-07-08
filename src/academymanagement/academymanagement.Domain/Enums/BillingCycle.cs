using System.ComponentModel;

namespace academymanagement.Domain.Enums
{
    public enum BillingCycle
    {
        [Description("Mensal")]
        Monthly = 'M',
        [Description("Semestral")]
        Biannual = 'B',
        [Description("Anual")]
        Yearly = 'Y'
    }
}
