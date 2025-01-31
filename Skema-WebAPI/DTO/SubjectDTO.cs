namespace Skema_WebAPI.DTO
{
    public class SubjectForSaveDTO
    {
        public required string Name { get; set; }
        public required int SamletTimer { get; set; }
        public required bool ErTP { get; set; }

        public int? TeacherId { get; set; } 
        public ICollection<int>? DayIds { get; set; }
    }

    public class SubjectForUpdateDTO : SubjectForSaveDTO
    {
        public int SubjectId { get; set; }
    }

    public class SubjectDTO : SubjectForUpdateDTO
    {
        public TeacherDTO? Teacher { get; set; } 
        public ICollection<DayDTO>? Days { get; set; } 
    }

    public class SubjectDTOMinusRelations : SubjectForUpdateDTO
    {

    }
}
