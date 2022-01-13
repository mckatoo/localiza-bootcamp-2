namespace Classes
{
  public class Classes
  {
    public static void Main(string[] args)
    {

    }
  }

  public class Ref
  {
    static void Inverter(int x, int y, out int out_x, out int out_y)
    {
      int temp = x;
      x = y;
      y = temp;
      out_x = x;
      out_y = y;
    }
    public static void InverterSemReferencia(int x, int y, out int out_x, out int out_y)
    {
      Inverter(x, y, out int x2, out int y2);
      out_x = x2;
      out_y = y2;
    }

    public static void InverterComReferencia(int x, int y, out int out_x, out int out_y)
    {
      Inverter(x, y, out int x2, out int y2);
      out_x = x2;
      out_y = y2;
    }
  }
}