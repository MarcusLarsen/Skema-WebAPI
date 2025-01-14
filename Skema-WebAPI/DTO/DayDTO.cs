namespace Skema_WebAPI.DTO
{
    public class DayForSaveDTO
    {
        public required DateTime Dato { get; set; }
        public required int Samlet_Timer { get; set; }
        public required int TP_Timer { get; set; }
        public required int FagFaglige_Timer { get; set; }
    }
    public class DayForUpdateDTO : DayForSaveDTO
    {
        public int DayId { get; set; }
    }

    public class DayDTO : DayForUpdateDTO
    {

    }

    public class DayDTOMinusRelations : DayForUpdateDTO
    {

    }
}
