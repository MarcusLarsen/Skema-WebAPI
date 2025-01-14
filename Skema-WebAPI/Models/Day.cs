using System.ComponentModel.DataAnnotations.Schema;

namespace Skema_WebAPI.Models
{
    public class Day
    {
        //Primary key
        public int DayId { get; set; }

        //Foreign Keys
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }

        public required string Name { get; set; }
        public required DateTime Dato { get; set; }
        public required int Samlet_Timer { get; set; }
        public required int TP_Timer { get; set; }
        public required int FagFaglige_Timer { get; set; }

        [ForeignKey(nameof(SubjectId))]
        public Subject? Subject { get; set; }

        [ForeignKey(nameof(TeacherId))]
        public Teacher? Teacher { get; set; }
    }
}
