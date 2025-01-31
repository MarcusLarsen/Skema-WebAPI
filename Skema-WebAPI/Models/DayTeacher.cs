using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Skema_WebAPI.Models
{
    public class DayTeacher
    {
        public int DayTeacherId { get; set; }

        public int DayId { get; set; }

        [ForeignKey(nameof(DayId))]
        public Day? Day { get; set; }

        public int TeacherId { get; set; }

        [ForeignKey(nameof(TeacherId))]
        public Teacher? Teacher { get; set; }
    }
}
