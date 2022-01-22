using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dio.Series.Interfaces;

namespace Dio.Series
{
  public class SerieRepositorio : IRepositorio<Serie>
  {
    List<Serie> listaSeries = new List<Serie>();
    public void Adicionar(Serie serie)
    {
      listaSeries.Add(serie);
    }

    public void Atualizar(Serie serie)
    {
      // listaSeries.Where(x => x.ID == serie.ID).FirstOrDefault();
    }

    public List<Serie> Listar()
    {
      return listaSeries.ToList();
    }

    public Serie PorID(Guid id)
    {
      throw new NotImplementedException();
    }

    public Guid ProximoID()
    {
      throw new NotImplementedException();
    }

    public void Remover(Serie serie)
    {
      throw new NotImplementedException();
    }
  }
}