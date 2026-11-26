namespace NewsWeb.Api.Models;
public class AppUser
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public UserRole Role { get; set; } = UserRole.None;
    public List<ArticleAction> ArticleActions { get; } = [];
    public List<Article> Articles { get; } = [];

    public static AppUser Create(int id, string username, UserRole role)
    {
        return new AppUser
        {
            Id = id,
            Username = username,
            Role = role
        };
    }
}

public enum UserRole { 
    None,Writer,Publisher,Admin }


    