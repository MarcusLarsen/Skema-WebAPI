namespace Skema_WebAPI.DTO
{
    public class SubjectForSaveDTO
    {
        public string Name { get; set; }
        public int SamletTimer { get; set; }
        public bool ErTP { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int? TeacherId { get; set; }
    }

    public class SubjectForUpdateDTO : SubjectForSaveDTO
    {
        public int SubjectId { get; set; }
    }

    public class SubjectDTO : SubjectForUpdateDTO
    {
        public TeacherDTO? Teacher { get; set; }
        public List<DaySubjectDTO> DaySubjects { get; set; } = new();
    }

    public class SubjectDTOMinusRelations : SubjectForUpdateDTO
    {
    }
}
