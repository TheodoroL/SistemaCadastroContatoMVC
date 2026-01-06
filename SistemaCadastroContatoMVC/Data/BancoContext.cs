using Microsoft.EntityFrameworkCore;
using SistemaCadastroContatoMVC.Models;

namespace SistemaCadastroContatoMVC.Data;

public class BancoContext : DbContext
{
    public BancoContext(DbContextOptions<BancoContext> options) : base(options)
    {
    }

    public DbSet<ContatoModel> Contatos { get; set; }
}
