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

}
