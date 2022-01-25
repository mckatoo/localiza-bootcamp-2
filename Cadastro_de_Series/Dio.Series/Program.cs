namespace Dio.Series
{
    public class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            string? indiceSerie = Console.ReadLine();

            if (indiceSerie != null)
            {
                Serie serie = repositorio.PorID(Guid.Parse(indiceSerie));
                repositorio.Remover(serie.ID);
            }
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            string? indiceSerie = Console.ReadLine();

            if (indiceSerie != null)
            {
                Serie serie = repositorio.PorID(Guid.Parse(indiceSerie));

                Console.WriteLine(serie);
            }
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            Guid indiceSerie = Guid.TryParse(Console.ReadLine(), out Guid id)
              ? id
              : throw new Exception("Id inválido.");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.TryParse(Console.ReadLine(), out int genero) ? genero : 0;

            Console.Write("Digite o Título da Série: ");
            string? entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.TryParse(Console.ReadLine(), out int ano) ? ano : 0;

            Console.Write("Digite a Descrição da Série: ");
            string? entradaDescricao = Console.ReadLine();

            Serie atualizaSerie;
            if (indiceSerie != null && entradaTitulo != null && entradaDescricao != null)
            {
                atualizaSerie = new Serie(
                    genero: (Genero)entradaGenero,
                    titulo: entradaTitulo,
                    ano: entradaAno,
                    descricao: entradaDescricao
                );

                repositorio.Atualizar(atualizaSerie);
            }
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Listar();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                string excluido = serie.Excluido_em == null ? "*Excluido*" : "";

                Console.WriteLine($"#ID {serie.ID}: - {serie.retornaTitulo} {excluido}");
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.TryParse(Console.ReadLine(), out int genero)
              ? genero
              : throw new Exception("Gênero inválido.");

            Console.Write("Digite o Título da Série: ");
            string? entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.TryParse(Console.ReadLine(), out int ano)
              ? ano
              : throw new Exception("Ano inválido.");

            Console.Write("Digite a Descrição da Série: ");
            string? entradaDescricao = Console.ReadLine();

            if (entradaTitulo != null && entradaDescricao != null)
            {
                Serie novaSerie = new Serie(
                    genero: (Genero)entradaGenero,
                    titulo: entradaTitulo,
                    ano: entradaAno,
                    descricao: entradaDescricao
                );
                repositorio.Adicionar(novaSerie);
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string? opcaoUsuario = Console.ReadLine()?.ToUpper();
            Console.WriteLine();
            if (opcaoUsuario == null)
            {
                throw new Exception("Opção inválida.");
            }
            return opcaoUsuario;
        }
    }
}
