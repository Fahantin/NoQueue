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
        public int Id { get; set; }

        //[ForeignKey]
        public int IdServico { get; set; }

        //[ForeignKey]
        public int IdUsuario { get; set; }

        //[MaxLength(4)]
        public int SenhaUsuario { get; set; }

        public Senha()
        {

        }

        public Senha(int idServico, int idUsuario)
        {
            this.IdServico = idServico;
            this.IdUsuario = idUsuario;
        }
    }
}
