namespace Dio.Series.Interfaces
{
    public interface ISerieRepositorio : IRepositorio<Serie>
    {
        List<Serie> PorGenero(Genero genero);
        List<Serie> ListaContemTitulo(string titulo);
    }
}
