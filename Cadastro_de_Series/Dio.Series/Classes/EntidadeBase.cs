namespace Dio.Series
{
    public abstract class EntidadeBase
    {
        public Guid ID { get; protected set; } = Guid.NewGuid();

        public DateTime Criado_em { get; protected set; } = DateTime.Now;
        public DateTime Atualizado_em { get; protected set; } = DateTime.Now;
        public DateTime Excluido_em { get; protected set; } = DateTime.UnixEpoch;
    }
}
