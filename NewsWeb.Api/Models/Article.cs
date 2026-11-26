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

    public static Article Create(int id, string title, string? content, string? imageUrl, DateTime createdAt, ArticleStatus status)
    {
        return new Article
        {
            Id = id,
            Title = title,
            Content = content,
            ImageUrl = imageUrl,
            CreatedAt = createdAt,
            Status = status
        };
    }
}
public enum ArticleStatus
{
    Draft,
    Published,
    Deleted
}

