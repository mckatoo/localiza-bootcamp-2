using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Localiza.Frotas.Domain
{
    public interface IVeiculoDetran
    {
        public Task AgendarVistoriaDetran(Guid veiculoID);
    }
}