namespace WebApplication1.Models;

public static class UserStore
{
    public static readonly List<User> Users =
    [
        new User("admin", "password123") { Id = 1, Role = "Admin" },
        new User("guest", "guest123")    { Id = 2, Role = "User"  }
    ];
}
