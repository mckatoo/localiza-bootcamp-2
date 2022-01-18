using Colecoes.Helper;

namespace Colecoes
{
  public class Program
  {
    static void Main(string[] args)
    {
      int[] inteiros = new int[] { 9, 5, 6, 3, 2 };
      var inteirosConvertido = Array.ConvertAll(inteiros, elemento => elemento.ToString());
      Console.WriteLine($"inteiros convertido é do tipo: {inteirosConvertido.GetType()}");

      Console.WriteLine("Array original: ");
      Console.WriteLine(OperacoesArray.ImprimirArray(inteiros));

      // OperacoesArray.OrdenarComBubbleSort(ref inteiros);
      // Console.WriteLine("Array ordenado: ");
      // OperacoesArray.ImprimirArray(inteiros);

      // OperacoesArray.OrdenarSemBubbleSort(ref inteiros);
      // Console.WriteLine($"Array ordenado: {OperacoesArray.ImprimirArray(inteiros)}");

      // int[] arrayCopia = new int[10];
      // Console.WriteLine($"Array ANTES da copia: {OperacoesArray.ImprimirArray(arrayCopia)}");
      // OperacoesArray.Copiar(ref inteiros, ref arrayCopia);
      // Console.WriteLine($"Array DEPOIS da copia: {OperacoesArray.ImprimirArray(arrayCopia)}");

      // Verificar se o array contem um elemento com o valor 10
      // int numero = 10;
      // if (inteiros.Contains(numero))
      // {
      //   Console.WriteLine($"O array contém o número {numero}");
      // }
      // else
      // {
      //   Console.WriteLine($"O array não contém o número {numero}");
      // }

      // Verificar se o array contem um elemento com o valor maior que 1
      // int numero = 1;
      // if (inteiros.Min() < numero)
      // {
      //   Console.WriteLine($"O array contém um número maior que {numero}");
      // }
      // else
      // {
      //   Console.WriteLine($"O array não contém um número maior que {numero}");
      // }

      // Verificar se o array contem um elemento com o valor menor que 10
      // int numero = 10;
      // if (inteiros.Max() > numero)
      // {
      //   Console.WriteLine($"O array contém um número menor que {numero}");
      // }
      // else
      // {
      //   Console.WriteLine($"O array não contém um número menor que {numero}");
      // }

      // Executar uma ação para o elemento encontrado no array
      // var numero = 5;
      // var numero = '5';
      // var numero = "5";
      // bool existe = Array.Exists(inteiros, elemento => elemento.GetType() == numero.GetType());
      // if(existe)
      // {
      //   Console.WriteLine($"O array contém um elemento do tipo {numero.GetType()}");
      // }
      // else
      // {
      //   Console.WriteLine($"O array NÃO contém um elemento do tipo {numero.GetType()}");
      // }

      
    }
  }
}