using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Domain.Controllers
{
    public class SupermercadoController : ApiController
    {
        static List<Supermercado> _supermercados = new List<Supermercado> {
            new Supermercado(){Id=1,Nome="Tauste",Lat=22.45,Lng=-22.38}
        };

        //GET
        /// <summary>
        /// Listar Todos os Supermercados
        /// </summary>
        /// <param name="Supermercado">Supermercado Modelo</param>
        /// <param name="Id">Id do Supermercado</param>
        /// <param name="Nome">Nome do Supermercado</param>
        /// <param name="Lat">Latitude do Supermercado</param>
        /// <param name="Lng">Longitude do Supermercado</param>
        /// <response code="200">OK</response>
        /// <response code="400">Solicitação imprópria (Bad Request)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(Supermercado))]
        public IHttpActionResult Get()
        {
            return Ok(_supermercados);
        }


        //POST
        /// <summary>
        /// Adicionar Supermercado
        /// </summary>
        /// <param name="Supermercado">Supermercado Modelo</param>
        /// <param name="Id">Id do Supermercado</param>
        /// <param name="Nome">Nome do Supermercado</param>
        /// <param name="Lat">Latitude do Supermercado</param>
        /// <param name="Lng">Longitude do Supermercado</param>
        /// <remarks>/POST
        /// {
        ///     "id": 1;
        ///     "name": Tauste;
        ///     "lat": 22.45;
        ///     "lng": -22.38;
        ///  }
        /// </remarks>
        /// <response code="200">OK</response>
        /// <response code="201">Criado</response>
        /// <response code="400">Solicitação imprópria (Bad Request)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(Supermercado))]
        public HttpResponseMessage Post([FromBody]Supermercado supermercado)
        {
            if (supermercado != null)
            {
                _supermercados.Add(supermercado);
                var msg = new HttpResponseMessage(HttpStatusCode.Created);
                return msg;
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
        }


        //DELETE
        /// <summary>
        /// Deletar Supermercado
        /// </summary>
        /// <param name="Supermercado">Supermercado Modelo</param>
        /// <param name="Id">Id do Supermercado</param>
        /// <param name="Nome">Nome do Supermercado</param>
        /// <param name="Lat">Latitude do Supermercado</param>
        /// <param name="Lng">Longitude do Supermercado</param>
        /// <response code="200">OK</response>
        /// <response code="400">Solicitação imprópria (Bad Request)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(Supermercado))]
        // DELETE api/values
        public IHttpActionResult Delete(int id)
        {
            if (id != null)
            {
                //return new HttpResponseMessage(HttpStatusCode.OK);
                _supermercados = _supermercados.Where(note => note.Id != id).ToList();
                return Ok();
            }
            else
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            }
        }
    }
}