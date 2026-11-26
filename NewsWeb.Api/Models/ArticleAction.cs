using NewsWeb.Api.Models;
public class ArticleAction
{
    public int Id { get; set; }

    public int ArticleId { get; set; }
    public int UserId { get; set; }
    public Article Article { get; set; } = null!;
    public AppUser AppUser { get; set; } = null!;
    public DateTime Time { get; set; } = DateTime.UtcNow;
    public ActionType Type { get; set; }
}
public enum  ActionType
{
    Created, Edited, ChangedStatus,
}