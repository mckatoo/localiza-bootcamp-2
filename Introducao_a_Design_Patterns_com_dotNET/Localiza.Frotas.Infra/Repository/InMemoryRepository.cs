using Localiza.Frotas.Domain;

namespace Localiza.Frotas.Infra.Repository
{
  public class InMemoryRepository : IVeiculoRepository
  {
    private readonly IList<Veiculo> _veiculos = new List<Veiculo>();

    public void Salvar(Veiculo veiculo) => _veiculos.Add(veiculo);

    public void Atualizar(Veiculo veiculo)
    {
      var veiculoAtulizar = _veiculos.SingleOrDefault(v => v.Id == veiculo.Id);

      if (veiculoAtulizar != null)
      {
        veiculoAtulizar.Placa = veiculo.Placa;
        veiculoAtulizar.Marca = veiculo.Marca;
        veiculoAtulizar.AnoFabricacao = veiculo.AnoFabricacao;
      }
    }

    public void Excluir(Veiculo veiculo) => _veiculos.Remove(veiculo);

    public IEnumerable<Veiculo> ListaPorAnoFabricacao(string anoFabricacao)
    {
      Veiculo[] veiculos = _veiculos.Where(v => v.AnoFabricacao == anoFabricacao).ToArray();

      return veiculos;
    }

    public IEnumerable<Veiculo> ListaTodos()
    {
      return _veiculos.ToList();
    }

    public IEnumerable<Veiculo> ListaPorMarca(string marca)
    {
      Veiculo[] veiculos = _veiculos.Where(v => v.Marca == marca).ToArray();

      return veiculos;
    }

    public Veiculo? PorID(Guid id)
    {
      var veiculo = _veiculos.SingleOrDefault(v => v.Id == id);

      return veiculo;
    }

    public Veiculo? PorPlaca(string placa)
    {
      var veiculo = _veiculos.SingleOrDefault(v => v.Placa == placa);

      return veiculo;
    }
  }
}