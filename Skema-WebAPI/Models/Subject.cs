using System.ComponentModel.DataAnnotations.Schema;

namespace Skema_WebAPI.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public required string Name { get; set; }
        public required int SamletTimer { get; set; }
        public required bool ErTP {  get; set; }

        public int? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public ICollection<Day>? Days { get; set; }
    }
}
