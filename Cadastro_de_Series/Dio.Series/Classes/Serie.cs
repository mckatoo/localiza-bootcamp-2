namespace Dio.Series
{
    public class Serie : EntidadeBase
    {
        public Serie(Genero genero, string descricao, string titulo, int ano)
        {
            Genero = genero;
            Descricao = descricao;
            Titulo = titulo;
            Ano = ano;
        }
        public Serie(Guid id, Genero genero, string descricao, string titulo, int ano)
        {
            ID = id;
            Genero = genero;
            Descricao = descricao;
            Titulo = titulo;
            Ano = ano;
        }

        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }

        public override string ToString()
        {
            return $@"Gênero: {Genero}\n
            Titulo: {Titulo}\n
            Descrição: {Descricao}\n
            Ano de Início: {Ano}";
        }

        public string retornaTitulo()
        {
            return Titulo;
        }

        public Genero retornaGenero()
        {
            return Genero;
        }

        public void remove()
        {
            Excluido_em = DateTime.Now;
        }

    }
}
