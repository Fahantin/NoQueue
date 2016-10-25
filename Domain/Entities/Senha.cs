using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    //[Table("Tarefas")]
    public class Senha
    {
        //[Key]
        public String Id { get; set; }

        //[ForeignKey]
        public String IdServico { get; set; }

        //[ForeignKey]
        public String IdUsuario { get; set; }

        //[MaxLength(4)]
        public int SenhaUsuario { get; set; }

        public Senha()
        {

        }

        public Senha(String idServico, String idUsuario)
        {
            this.IdServico = idServico;
            this.IdUsuario = idUsuario;
        }
    }
}
