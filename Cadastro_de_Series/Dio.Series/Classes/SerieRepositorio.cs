using Dio.Series.Interfaces;
using Dio.Series.Utils;

namespace Dio.Series
{
    public class SerieRepositorio : ISerieRepositorio
    {
        List<Serie> listaSeries = new List<Serie>();

        public void Adicionar(Serie serie)
        {
            listaSeries.Add(serie);
        }

        public void Atualizar(Serie serie)
        {
            var serieOriginal = listaSeries.Where(x => x.ID == serie.ID).FirstOrDefault();
            if (serieOriginal == null)
                throw new Exception("Não foi possível encontrar a série.");
            listaSeries.Remove(serieOriginal);
            listaSeries.Add(serie);
        }

        public List<Serie> ListaContemTitulo(string titulo)
        {
            List<Serie> series = listaSeries
                .Where(
                    x =>
                    {
                        var selectedSerie = StringUtils.RemoveAcentos(x.retornaTitulo().ToLower());
                        return selectedSerie.Contains(StringUtils.RemoveAcentos(titulo.ToLower()));
                    }
                )
                .ToList();
            if (series.Count == 0)
                throw new Exception("Não foi possível encontrar uma série deste genero.");

            return series;
        }

        public List<Serie> Listar()
        {
            return listaSeries.ToList();
        }

        public List<Serie> PorGenero(Genero genero)
        {
            List<Serie> series = listaSeries.Where(x => x.retornaGenero() == genero).ToList();
            if (series.Count == 0)
                throw new Exception("Não foi possível encontrar uma série deste genero.");

            return series;
        }

        public Serie PorID(Guid id)
        {
            Serie? serie = listaSeries.Where(x => x.ID == id).FirstOrDefault();
            if (serie == null)
                throw new Exception("Não foi possível encontrar a série.");

            return serie;
        }

        public void Remover(Guid id)
        {
            var serie = listaSeries.Where(x => x.ID == id).FirstOrDefault();
            if (serie == null)
                throw new Exception("Não foi possível encontrar a serie com o ID informado.");
            serie.remove();
        }
    }
}
