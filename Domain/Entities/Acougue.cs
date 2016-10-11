using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Servico
    {

        public int Id { get; set; }
        public int IdSupermercado { get; set; }
        public int IdTipoServico { get; set; }
        public int proxSenha { get; set; }
        public int atualSenha { get; set; }

        public Servico()
        {

        }

        public Servico(int id, int idSupermercado)
        {
            this.Id = id;
            this.IdSupermercado = idSupermercado;
        }
    }
}
