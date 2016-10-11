using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Domain.Controllers
{
    public class ServicoController : ApiController
    {
        static List<Servico> _servicos = new List<Servico> {
            new Servico(){Id=1,IdSupermercado=1,IdTipoServico=2,atualSenha=20,proxSenha=30}
        };

        public IHttpActionResult Get()
        {
            return Ok(_servicos);
        }
    }
}