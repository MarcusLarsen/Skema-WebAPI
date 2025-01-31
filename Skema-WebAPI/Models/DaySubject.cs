using System.ComponentModel.DataAnnotations.Schema;

namespace Skema_WebAPI.Models
{
    public class DaySubject
    {
        public int DaySubjectId { get; set; }

        public int DayId { get; set; }
        
        [ForeignKey(nameof(DayId))]
        public Day? Day { get; set; }

        public int SubjectId { get; set; }

        [ForeignKey(nameof(SubjectId))]
        public Subject? Subject { get; set; }
    }
}
