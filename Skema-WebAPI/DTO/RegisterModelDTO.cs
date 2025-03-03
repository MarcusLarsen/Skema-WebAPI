namespace Skema_WebAPI.DTO
{
    public class RegisterModelForSaveDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
    }

    public class RegisterModelForUpdateDTO : RegisterModelForSaveDTO
    {
    }

    public class RegisterModelDTO : RegisterModelForUpdateDTO
    {

    }

    public class RegisterModelDTOMinusRelations : RegisterModelForUpdateDTO
    {

    }
}
