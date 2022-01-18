namespace Colecoes.Helper
{
  public static class OperacoesArray
  {
    public static void OrdenarComBubbleSort(ref int[] array)
    {
      int temp = 0;
      for (int i = 0; i < array.Length; i++)
      {
        for (int j = 0; j < array.Length -1; j++)
        {
          if(array[j] > array[j + 1])
          {
            temp = array[j + 1];
            array[j + 1] = array[j];
            array[j] = temp;
          }
        }
      }
    }

    public static string ImprimirArray(int[] array)
    {
      string linha = string.Join(", ", array);
      return linha;
    }

    public static void OrdenarSemBubbleSort(ref int[] array)
    {
     Array.Sort(array);
    }

    public static void Copiar(ref int[] array, ref int[] arrayCopia)
    {
      Array.Copy(array, arrayCopia, array.Length);
    }
  }
}