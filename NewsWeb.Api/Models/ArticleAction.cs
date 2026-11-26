using NewsWeb.Api.Models;
public class ArticleAction
{
    public int Id { get; set; }
    public int ArticleId { get; set; }
    public int AppUserId { get; set; }
    public Article Article { get; set; } = null!;
    public AppUser AppUser { get; set; } = null!;
    public DateTime Time { get; set; } = DateTime.UtcNow;
    public ActionType Type { get; set; }

    public static ArticleAction Create(int articleId, int userId, ActionType type)
    {
        return new ArticleAction
        {
            ArticleId = articleId,
            AppUserId = userId,
            Type = type,
            Time = DateTime.UtcNow
        };
    }
}


    

public enum  ActionType
{
    Created, Edited, ChangedStatus,
}