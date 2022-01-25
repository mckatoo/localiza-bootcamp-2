using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dio.Series.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Listar();
        T PorID(Guid id);
        void Adicionar(T entidade);
        void Atualizar(T entidade);
        void Remover(Guid id);
    }
}