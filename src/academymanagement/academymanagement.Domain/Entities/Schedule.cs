using academymanagement.Domain.Entities.Base;

namespace academymanagement.Domain.Entities
{
    public class Schedule : EntityBase
    {
        public int ModalityId { get; set; }        
        public string DayOfWeek { get; set; }
        public string Time { get; set; }
        public SportModality SportModality { get; set; }
    }
}
