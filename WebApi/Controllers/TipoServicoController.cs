using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Domain.Controllers
{
    public class TipoServicoController : ApiController
    {
        static List<TipoServico> _tipos = new List<TipoServico> {
            new TipoServico(){Id=1,Nome="Açougue"}
        };

        public IHttpActionResult Get()
        {
            return Ok(_tipos);
        }
    }
}