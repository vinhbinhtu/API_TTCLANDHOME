namespace KOG.Intergration.Models.UsersConfig;

using System.ComponentModel.DataAnnotations;

public class AdminLogin
{
    public int Role { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }
}