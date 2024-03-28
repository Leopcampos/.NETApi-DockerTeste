using DockerTeste.Domain.Entities;
using DockerTeste.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace DockerTeste.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LivrosController : ControllerBase
{
    private readonly AppDbContext _context;

    public LivrosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var livros = _context.Livros.ToList();
        return Ok(livros);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Livro livro)
    {
        try
        {
            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();
            return Ok(livro);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}