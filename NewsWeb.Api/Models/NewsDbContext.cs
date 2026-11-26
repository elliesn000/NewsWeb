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
        optionsBuilder
        .UseAsyncSeeding(async (context, _, cancellationToken) =>
        {
            if (!await context.Set<AppUser>().AnyAsync(cancellationToken))
            {
                var users = new[]
                {
                    AppUser.Create ("user1", UserRole.Writer),
                    AppUser.Create ("user2", UserRole.Publisher),
                    AppUser.Create ("user3", UserRole.Admin),
                };
                await context.Set<AppUser>().AddRangeAsync(users, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
            }

            if (!await context.Set<Article>().AnyAsync(cancellationToken))
            {
                var articles = new[]
                {
                    Article.Create ("Article 1", "Content of Article 1", "https://example.com/image1.jpg"),
                    Article.Create ("Article 2", "Content of Article 2", "https://example.com/image2.jpg"),
                    Article.Create ("Article 3", "Content of Article 3", "https://example.com/image3.jpg"),
                };
                await context.Set<Article>().AddRangeAsync(articles, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
            }


            if (!await context.Set<ArticleAction>().AnyAsync(cancellationToken))
            {
                var actions = new[]
                {
                ArticleAction.Create (1, 1, ActionType.Created)
                };
                await context.Set<ArticleAction>().AddRangeAsync(actions, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
            }
        })


        .UseSeeding((context, _) =>
        {
            if (!context.Set<AppUser>().Any())
            {
                var users = new[]
                {
                    AppUser.Create ("user1", UserRole.Writer),
                    AppUser.Create ("user2", UserRole.Publisher),
                    AppUser.Create ("user3", UserRole.Admin),
                };
                context.Set<AppUser>().AddRange(users);
                context.SaveChanges();
            }
            if (!context.Set<Article>().Any())
            {
                var articles = new[]
                {
                    Article.Create ("Article 1", "Content of Article 1", "https://example.com/image1.jpg"),
                    Article.Create ("Article 2", "Content of Article 2", "https://example.com/image2.jpg"),
                    Article.Create ("Article 3", "Content of Article 3", "https://example.com/image3.jpg"),
                };
                context.Set<Article>().AddRange(articles);
                context.SaveChanges();
            }
            if (!context.Set<ArticleAction>().Any())
            {
                var actions = new[]
                {
                ArticleAction.Create (1, 1, ActionType.Created)
                };
                context.Set<ArticleAction>().AddRange(actions);
                context.SaveChanges();
            }
        });
    }
}
