using Domain.Base;

namespace Domain.User;

public class User : BaseEntity
{
    public string UserName { get; set; }
    public string PasswordHash { get;set; }
    public Roles.Roles Role { get; set; }
}