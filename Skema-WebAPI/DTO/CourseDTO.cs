namespace Skema_WebAPI.DTO
{
    public class CourseForSaveDTO
    {
        public required string CourseName { get; set; }
    }

    public class CourseForUpdateDTO : CourseForSaveDTO
    {
        public int CourseId { get; set; }
    }

    public class CourseDTO : CourseForUpdateDTO
    {

    }

    public class CourseDTOMinusRelations : CourseForUpdateDTO
    {

    }
}
