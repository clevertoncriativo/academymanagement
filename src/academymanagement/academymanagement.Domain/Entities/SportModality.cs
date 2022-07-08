using academymanagement.Domain.Entities.Base;
using System.Collections.Generic;

namespace academymanagement.Domain.Entities
{
    public class SportModality : EntityBase
    {
        public string Name { get; set; }
        public bool IsEnable { get; set; }
        public IEnumerable<Schedule> Schedules { get; set; }
    }
}
