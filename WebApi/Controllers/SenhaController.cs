using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Domain.Controllers
{
    public class SenhaController : ApiController
    {
        static List<Senha> _senhas = new List<Senha> {
            new Senha(){Id=1,IdServico=1,IdUsuario=1,SenhaUsuario=19}
        };

        public IHttpActionResult Get()
        {
            return Ok(_senhas);
        }
    }
}