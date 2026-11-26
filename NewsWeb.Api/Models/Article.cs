namespace NewsWeb.Api.Models;
public class Article
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Content { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public ArticleStatus Status { get; set; } = ArticleStatus.Draft;
    public List<ArticleAction> ArticleActions { get; } = [];
    public List<AppUser> AppUsers { get; } = [];

    public static Article Create(string title, string? content, string? imageUrl)
    {
        return new Article
        {            
            Title = title,
            Content = content,
            ImageUrl = imageUrl,
        };
    }
}
public enum ArticleStatus {
    Draft, Published, Deleted }

