using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TipoServico
    {
        public int Id { get; set; }
        public String Nome { get; set; }

        public TipoServico()
        {

        }

        public TipoServico(int id, String nome)
        {
            this.Id = id;
            this.Nome = nome;
        }

    }
}
