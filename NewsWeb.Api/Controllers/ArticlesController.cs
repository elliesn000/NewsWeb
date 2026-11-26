using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsWeb.Api.Models;

namespace NewsWeb.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArticlesController : ControllerBase
{
    private readonly NewsDbContext _context;

    public ArticlesController(NewsDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Article>>> GetArticles()
    {
        var articles = await _context.Articles
            .AsNoTracking()
            .OrderByDescending(a => a.CreatedAt)
            .ToListAsync();

        return Ok(articles);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Article>> GetArticleById(int id)
    {
        var article = await _context.Articles.FindAsync(id);
        if (article == null)
        {
            return NotFound();
        }
        return article;
    }

    [HttpPost]
    public async Task<ActionResult<ArticleDTO>> CreateArticle(ArticleDTO articleDTO)
    {
        var article = Article.Create(articleDTO.Title, articleDTO.Content, articleDTO.ImageUrl);

        _context.Articles.Add(article);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetArticleById), new { id = article.Id }, article);
    }

    //[HttpPut("{id}")]
    //public async Task<ActionResult<Article>> UpdateArticle(int id, Article article)
    //{


    //}
}
