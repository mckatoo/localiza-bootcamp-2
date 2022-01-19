namespace Localiza.Frotas.Domain
{
  public class Veiculo
  {
    public Veiculo(Guid id, string placa, string marca, string anoFabricacao)
    {
      this.Id = id;
      this.Marca = marca;
      this.Placa = placa;
      this.AnoFabricacao = anoFabricacao;
    }
    public Guid Id { get; set; }
    public string Placa { get; set; }
    public string Marca { get; set; }
    public string AnoFabricacao { get; set; }
  }
}