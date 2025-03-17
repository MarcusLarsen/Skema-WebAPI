namespace Skema_WebAPI.DTO
{
    public class DayForSaveDTO
    {
        public string Name { get; set; }
        public DateTime Dato { get; set; }
        public int Samlet_Timer { get; set; }
        public int TP_Timer { get; set; }
        public int FagFaglige_Timer { get; set; }


        public List<SubjectForSaveDTO> Subjects { get; set; } = new List<SubjectForSaveDTO>();
        public int CourseId { get; set; }
    }

    public class DayForUpdateDTO : DayForSaveDTO
    {
        public int DayId { get; set; }
    }

    public class DayDTO : DayForUpdateDTO
    {
        public CourseDTOMinusRelations? Course { get; set; }
        public List<DaySubjectDTO> DaySubjects { get; set; } = new();
        public List<DayTeacherDTO> DayTeachers { get; set; } = new();
    }

    public class DayDTOMinusRelations : DayForUpdateDTO
    {
    }
}
