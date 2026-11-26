using Microsoft.EntityFrameworkCore;

namespace NewsWeb.Api.Models;

public class NewsDbContext : DbContext
{
    public NewsDbContext(DbContextOptions<NewsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Article> Articles { get; set; }
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<ArticleAction> ArticleActions { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseAsyncSeeding(async (context, _, cancellationToken) =>
        {
            if (!await context.Set<AppUser>().AnyAsync(cancellationToken))
            {
                var users = new[]
                {
                    AppUser.Create (1, "user1", UserRole.Writer),
                    AppUser.Create (2, "user2", UserRole.Publisher),
                    AppUser.Create (3, "user3", UserRole.Admin),
                };
                await context.Set<AppUser>().AddRangeAsync(users, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
            }

            if (!await context.Set<Article>().AnyAsync(cancellationToken))
            {
                var articles = new[]
                {
                    Article.Create (1, "Article 1", "Content of Article 1", "https://example.com/image1.jpg", DateTime.UtcNow, ArticleStatus.Published),
                    Article.Create (2, "Article 2", "Content of Article 2", "https://example.com/image2.jpg", DateTime.UtcNow, ArticleStatus.Draft),
                    Article.Create (3, "Article 3", "Content of Article 3", "https://example.com/image3.jpg", DateTime.UtcNow, ArticleStatus.Deleted),
                };
                await context.Set<Article>().AddRangeAsync(articles, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
            }

        });
    }
}
