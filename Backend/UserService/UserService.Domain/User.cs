using System.ComponentModel.DataAnnotations;

namespace UserService.Domain;

public class User
{
    [Key]

    public long Id { get; set; }

    public string Login { get; set; } = "";

    public string Password { get; set; } = "";

    public string NickName { get; set; } = "";

    public string Email { get; set; } = "";

    public string PhoneNumber { get; set; } = "";

    public bool EmailConfirmed { get; set; } = false;

    public bool PhoneConfirmed { get; set; } = false;

   

}
