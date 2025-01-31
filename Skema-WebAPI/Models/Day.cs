using System.ComponentModel.DataAnnotations.Schema;

namespace Skema_WebAPI.Models
{
    public class Day
    {
        public int DayId { get; set; }
        public required string Name { get; set; }
        public required DateTime Dato { get; set; }
        public required int Samlet_Timer { get; set; }
        public required int TP_Timer { get; set; }
        public required int FagFaglige_Timer { get; set; }

        public ICollection<DaySubject>? DaySubjects { get; set; }
        public ICollection<DayTeacher>? DayTeachers { get; set; }
    }
}
