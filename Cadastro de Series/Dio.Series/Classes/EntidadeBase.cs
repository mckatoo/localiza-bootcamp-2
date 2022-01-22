using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dio.Series
{
    public class EntidadeBase
    {
        public Guid ID
        {
            get { return ID; }
            protected set
            {
                if (ID == Guid.Empty)
                    ID = Guid.NewGuid();
            }
        }

        public DateTime Criado_em { get; set; } = DateTime.Now;
        public DateTime Atualizado_em { get; set; } = DateTime.Now;
        public DateTime Excluido_em { get; set; }
    }
}
