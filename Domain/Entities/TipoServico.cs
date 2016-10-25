using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TipoServico
    {
        public String Id { get; set; }
        public String Nome { get; set; }

        public TipoServico()
        {

        }

        public TipoServico(String id, String nome)
        {
            this.Id = id;
            this.Nome = nome;
        }

    }
}
