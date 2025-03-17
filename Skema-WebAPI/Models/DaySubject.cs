using System.ComponentModel.DataAnnotations.Schema;

namespace Skema_WebAPI.Models
{
    public class DaySubject
    {
        public int DaySubjectId { get; set; }

        public int DayId { get; set; }
        public Day? Day { get; set; }

        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }
    }
}
