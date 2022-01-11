using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Contas.Tests;

[TestClass]
public class ContasTests
{
  [TestMethod]
  public void SomaTest()
  {
    var a = 5;
    var b = 5;
    var expected = 10;
    var contas = new Contas();

    var result = contas.Soma(a, b);

    Assert.AreEqual(expected, result);
  }

  [TestMethod]
  public void SubTest()
  {
    var a = 10;
    var b = 5;
    var expected = 5;
    var contas = new Contas();

    var result = contas.Sub(a, b);

    Assert.AreEqual(expected, result);
  }

  [TestMethod]
  public void MultTest()
  {
    var a = 10;
    var b = 5;
    var expected = 50;
    var contas = new Contas();

    var result = contas.Mult(a, b);

    Assert.AreEqual(expected, result);
  }

  [TestMethod]
  public void DivTest()
  {
    var a = 10;
    var b = 5;
    var expected = 2;
    var contas = new Contas();

    var result = contas.Div(a, b);

    Assert.AreEqual(expected, result);
  }
}
