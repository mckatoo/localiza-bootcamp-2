namespace Localiza.Frotas.Domain
{
    public interface IVeiculoRepository
    {
        IEnumerable<Veiculo> ListaTodos();
        Veiculo? PorID(Guid id);
        Veiculo? PorPlaca(string placa);
        IEnumerable<Veiculo> ListaPorMarca(string marca);
        IEnumerable<Veiculo> ListaPorAnoFabricacao(string anoFabricacao);
        void Salvar(Veiculo veiculo);
        void Excluir(Veiculo veiculo);
        void Atualizar(Veiculo veiculo);

    }
}