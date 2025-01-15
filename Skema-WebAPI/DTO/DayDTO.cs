namespace Skema_WebAPI.DTO
{
    public class DayForSaveDTO
    {
        public required DateTime Dato { get; set; }
        public required int Samlet_Timer { get; set; }
        public required int TP_Timer { get; set; }
        public required int FagFaglige_Timer { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
    }
    public class DayForUpdateDTO : DayForSaveDTO
    {
        public int DayId { get; set; }
    }

    public class DayDTO : DayForUpdateDTO
    {
        public SubjectDTOMinusRelations? Subject { get; set; }
    }

    public class DayDTOMinusRelations : DayForUpdateDTO
    {

    }
}
