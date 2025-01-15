namespace Skema_WebAPI.DTO
{
    public class TeacherForSaveDTO
    {
       public required string Name { get; set; }
    }
    public class TeacherForUpdateDTO : TeacherForSaveDTO
    {
        public int TeacherId { get; set; }
    }

    public class TeacherDTO : TeacherForUpdateDTO
    {

    }

    public class TeacherDTOMinusRelations : TeacherForUpdateDTO
    {

    }
}
