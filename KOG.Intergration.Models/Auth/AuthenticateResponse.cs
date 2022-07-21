namespace KOG.Intergration.Models.Users;

public class AuthenticateResponse
{
    public int Id { get; set; }
    public int RoleId { get; set; }
    public string Token { get; set; }

    public AuthenticateResponse(UserModel user, string token)
    {
        Id = user.Id;
        RoleId = user.RoleId;
        Token = token;
    }
}