namespace Skema_WebAPI.DTO
{
    public class LoginModelForSaveDTO
    {

    }

    public class LoginModelForUpdateDTO : LoginModelForSaveDTO
    {
    }

    public class LoginModelDTO : LoginModelForUpdateDTO
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }

    public class LoginModelDTOMinusRelations : LoginModelForUpdateDTO
    {

    }
}
