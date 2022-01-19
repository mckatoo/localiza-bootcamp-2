using Localiza.Frotas.Domain;
using Microsoft.EntityFrameworkCore;

namespace Localiza.Frotas.Infra.Repository.EF
{
  public class FrotaContext : DbContext
  {
    public FrotaContext(DbContextOptions<FrotaContext> options) : base(options)
    {
      if (Veiculos == null)
        throw new System.Exception("DbSet de Veiculos não foi inicializado");
    }

    public DbSet<Veiculo> Veiculos { get; set; }
  }
}