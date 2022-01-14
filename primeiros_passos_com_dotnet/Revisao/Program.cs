namespace Revisao
{
  class Program
  {
    static void Main(string[] args)
    {
      Aluno[] alunos = new Aluno[4];
      int indiceAluno = 0;
      string opcaoUsuario = ObterOpcaoUsuario();

      while (opcaoUsuario!.ToUpper() != "0")
      {
        switch (opcaoUsuario)
        {
          case "0":
            Console.WriteLine("Saindo...");
            break;
          case "1":
            indiceAluno = InserirAluno(alunos, indiceAluno);
            break;
          case "2":
            foreach (var aluno in alunos)
            {
              if (!string.IsNullOrEmpty(aluno.Nome))
              {
                Console.WriteLine($"ID: {aluno.Id} \nNome: {aluno.Nome} \nNota: {aluno.Nota} \nMatricula: {aluno.Matricula}");
                Console.WriteLine("-");
              }
            }
            break;
          case "3":
            decimal mediaGeral = MediaGeral(alunos);
            string conceitoGeral = ObterConceito(mediaGeral);
            Console.WriteLine($"Média geral: {mediaGeral}. \nConceito: {conceitoGeral}");
            break;
          default:
            Console.WriteLine("Opção inválida!");
            break;
        }

        opcaoUsuario = ObterOpcaoUsuario();
      }
    }

    private static string ObterConceito(decimal mediaGeral)
    {
      string conceitoGeral = "";
      conceitoGeral = mediaGeral >= 9 ? "A" : conceitoGeral;
      conceitoGeral = mediaGeral >= 7 && mediaGeral < 9 ? "B" : conceitoGeral;
      conceitoGeral = mediaGeral >= 5 && mediaGeral < 7 ? "C" : conceitoGeral;
      conceitoGeral = mediaGeral >= 3 && mediaGeral < 5 ? "D" : conceitoGeral;
      conceitoGeral = mediaGeral < 3 ? "E" : conceitoGeral;

      return conceitoGeral;
    }

    private static decimal MediaGeral(Aluno[] alunos)
    {
      decimal notaTotal = 0;
      int quantidadeAlunos = 0;

      for (var i = 0; i < alunos.Length; i++)
      {
        if (!string.IsNullOrEmpty(alunos[i].Nome))
        {
          notaTotal += alunos[i].Nota;
          quantidadeAlunos++;
        }
      }

      decimal mediaGeral = notaTotal / quantidadeAlunos;
      return mediaGeral;
    }

    private static int InserirAluno(Aluno[] alunos, int indiceAluno)
    {
      Console.WriteLine("Informe o nome do aluno:");
      Aluno aluno = new Aluno();
      aluno.Nome = Console.ReadLine()!;

      Console.WriteLine("Informe a nota do aluno:");
      if (decimal.TryParse(Console.ReadLine()!, out decimal nota))
      {
        aluno.Nota = nota;
      }
      else
      {
        throw new ArgumentException("Valor da nota inválido. Informe um valor decimal válido.");
      }

      aluno.Id = indiceAluno + 1;
      aluno.Matricula = new Random().Next(1000, 9999).ToString();
      alunos[indiceAluno] = aluno;
      indiceAluno++;
      return indiceAluno;
    }

    private static string ObterOpcaoUsuario()
    {
      Console.WriteLine();
      Console.WriteLine("Informe a opção desejada: ");
      Console.WriteLine("1 - Inserir novo aluno");
      Console.WriteLine("2 - Listar alunos");
      Console.WriteLine("3 - Calcular média geral");
      Console.WriteLine("0 - Sair");
      Console.WriteLine();

      Console.Write("Opção: ");
      string opcaoUsuario = Console.ReadLine()!;
      return opcaoUsuario;
    }
  }
}
