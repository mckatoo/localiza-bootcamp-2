using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dio.Series.Tests;

[TestClass]
public class SerieTest
{
    static SerieRepositorio repositorio = new SerieRepositorio();

    [TestMethod]
    public void CriarSerie()
    {
        Serie novaSerie = new Serie(
            genero: Genero.Comedia,
            titulo: "Breaking Bad",
            ano: 2008,
            descricao: "A história se passa em Albuquerque, no meio de uma pandemia de drogas, e um policial é chamado para investigar."
        );

        repositorio.Adicionar(novaSerie);

        // O objeto adicionado deve ser igual ao objeto passado como parâmetro.
        Assert.AreEqual(repositorio.Listar()[0], novaSerie);

        // O objeto adicionado deve ter um ID diferente de Null.
        Assert.IsNotNull(repositorio.Listar()[0].ID);

        // O objeto adicionado deve ser diferente de 0.
        Assert.AreNotEqual(repositorio.Listar()[0].ID, "00000000-0000-0000-0000-000000000000");

        // A lista deve ter 1 elemento.
        Assert.AreEqual(repositorio.Listar().Count, 1);
    }

    [TestMethod]
    public void ListarTodasSeries()
    {
        Serie novaSerie = new Serie(
            genero: Genero.Acao,
            titulo: "Lost",
            ano: 2003,
            descricao: "A história de Lost"
        );

        repositorio.Adicionar(novaSerie);

        // A lista deve ter 2 objetos distintos.
        Assert.AreNotEqual(repositorio.Listar()[0], novaSerie);
        Assert.AreEqual(repositorio.Listar()[1], novaSerie);

        // Os objetos da lista devem ter IDs diferentes.
        Assert.AreNotEqual(repositorio.Listar()[0].ID, novaSerie.ID);

        // A lista deve ter 2 objetos.
        Assert.AreEqual(repositorio.Listar().Count, 2);
    }

    [TestMethod]
    public void AtualizarSerie()
    {
        Serie original = new Serie(
            genero: Genero.Acao,
            titulo: "Atualizar",
            ano: 2003,
            descricao: "A história para atualizar"
        );
        repositorio.Adicionar(original);

        Serie atualizada = new Serie(
            id: original.ID,
            genero: Genero.Acao,
            titulo: "Atualizada",
            ano: 2003,
            descricao: "A história atualizada"
        );
        repositorio.Atualizar(atualizada);

        // A ID da lista deve ser igual ao ID original.
        Assert.AreEqual(repositorio.Listar()[2].ID, original.ID);

        // O conteúdo do objeto da lista deve ser DIFERENTE do original.
        Assert.AreNotEqual(repositorio.Listar()[2], original);
        
        // O conteúdo do objeto da lista deve ser IGUAL ao atualizado.
        Assert.AreEqual(repositorio.Listar()[2], atualizada);

        // A lista deve conter apenas 3 itens.
        Assert.AreEqual(repositorio.Listar().Count, 3);
    }

    [TestMethod]
    public void RetornarSeriePorID()
    {
        Serie? serie = repositorio.PorID(repositorio.Listar()[1].ID);

        // O objeto passado no parametro deve ser igual ao objeto da lista.
        Assert.AreEqual(repositorio.Listar()[1], serie);
    }

    [TestMethod]
    public void RetornaSeriePorGenero()
    {
        List<Serie> series = repositorio.PorGenero(Genero.Acao);

        // Devem conter apenas 2 item na lista.
        Assert.AreEqual(series.Count, 2);

        // O primeiro item da lista deve ter o título "Lost".
        Assert.AreEqual(series[0].retornaTitulo(), "Lost");

        // O segundo item da lista deve ter o título "Atualizada".
        Assert.AreEqual(series[1].retornaTitulo(), "Atualizada");
    }

    [TestMethod]
    public void RetornaSerieContendoTitulo()
    {
        repositorio.Adicionar(new Serie(
            genero: Genero.Acao,
            titulo: "Título 1",
            ano: 2003,
            descricao: "Descrição título 1"
        ));
        repositorio.Adicionar(new Serie(
            genero: Genero.Acao,
            titulo: "Título 2",
            ano: 2003,
            descricao: "Descrição título 2"
        ));
        List<Serie> series = repositorio.ListaContemTitulo("titulo");

        // Devem conter apenas 2 item na lista.
        Assert.AreEqual(series.Count, 2);

        // O primeiro item da lista deve ter o título "Título 1".
        Assert.AreEqual(series[0].retornaTitulo(), "Título 1");

        // O segundo item da lista deve ter o título "Título 2".
        Assert.AreEqual(series[1].retornaTitulo(), "Título 2");
    }

    [TestCleanup]
    public void TestCleanup()
    {
        List<Serie> series = repositorio.Listar();
        series.RemoveAll(x => x.ID != null);
    }
}
