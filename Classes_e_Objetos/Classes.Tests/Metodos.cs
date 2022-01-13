using Xunit;

namespace Classes.Tests;

public class Metodos
{
    void dobrar_usando_referencia(ref int x)
    {
        x *= 2;
    }

    void dobrar_usando_valor(int x, out int out_x)
    {
        x *= 2;
        out_x = x;
    }

    [Fact]
    void Referencias()
    {
        int n = 10;
        dobrar_usando_referencia(ref n);
        Assert.Equal(20, n);

        int n2 = 10;
        dobrar_usando_valor(n2, out int n2_out);
        Assert.Equal(10, n2);
        Assert.Equal(20, n2_out);
    }
}