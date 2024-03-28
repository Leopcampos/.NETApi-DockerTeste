using DockerTeste.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DockerTeste.Infra.Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<Livro>? Livros { get; set; }
}