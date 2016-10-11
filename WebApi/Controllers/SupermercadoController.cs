using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Domain.Controllers
{
    public class SupermercadoController : ApiController
    {
        static List<Supermercado> _supermercados = new List<Supermercado> {
            new Supermercado(){Id=1,Nome="Tauste",Lat=22.45,Lng=-22.38}
        };

        public IHttpActionResult Get()
        {
            return Ok(_supermercados);
        }
    }
}