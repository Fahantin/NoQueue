using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Servico
    {

        public String Id { get; set; }
        public String IdSupermercado { get; set; }
        public String IdTipoServico { get; set; }
        public int ProxSenha { get; set; }
        public int AtualSenha { get; set; }

        public Servico()
        {

        }

        public Servico(int atualSenha)
        {
            this.AtualSenha = atualSenha;
        }

        public Servico(String id, String idSupermercado, String idTipoServico)
        {
            this.Id = id;
            this.IdSupermercado = idSupermercado;
            this.IdTipoServico = idTipoServico;
        }
    }
}