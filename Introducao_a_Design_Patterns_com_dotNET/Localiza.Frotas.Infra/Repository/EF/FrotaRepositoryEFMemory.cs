using Localiza.Frotas.Domain;
using Microsoft.EntityFrameworkCore;

namespace Localiza.Frotas.Infra.Repository.EF
{
  public class FrotaRepositoryEFMemory : IVeiculoRepository
  {
    private readonly FrotaContext _dbContext;

    public FrotaRepositoryEFMemory(FrotaContext dbContext) => this._dbContext = dbContext;

    public void Atualizar(Veiculo veiculo)
    {
      _dbContext.Veiculos.Update(veiculo);
      _dbContext.SaveChanges();
    }

    public void Excluir(Veiculo veiculo)
    {
      _dbContext.Veiculos.Remove(veiculo);
      _dbContext.SaveChanges();
    }

    public IEnumerable<Veiculo> ListaPorAnoFabricacao(string anoFabricacao)
      => _dbContext.Veiculos.Where(v => v.AnoFabricacao == anoFabricacao);

    public IEnumerable<Veiculo> ListaPorMarca(string marca)
      => _dbContext.Veiculos.Where(v => v.Marca == marca).ToList();

    public IEnumerable<Veiculo> ListaTodos()
      => _dbContext.Veiculos.ToListAsync().Result;

    public Veiculo? PorID(Guid id)
      => _dbContext.Veiculos.SingleOrDefault(v => v.Id == id);

    public Veiculo? PorPlaca(string placa)
      => _dbContext.Veiculos.SingleOrDefault(v => v.Placa == placa);

    public void Salvar(Veiculo veiculo)
    {
      _dbContext.Veiculos.AddAsync(veiculo);
      _dbContext.SaveChanges();
    }
  }
}