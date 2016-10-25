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
            new Supermercado(){Id="1",Nome="Tauste Sul",Lat=-22.225837,Lng=-49.933186}
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
        /// <response code="404">Não Encontrado (Not Found)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(Supermercado))]
        public IHttpActionResult Get()
        {
            return Ok(_supermercados);
        }


        //GET ID
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
        /// <response code="404">Não Encontrado (Not Found)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(Supermercado))]
        public IHttpActionResult GetId(String id)
        {
            Supermercado Supermercado = _supermercados.Find(x => x.Id == id);

            if (Supermercado != null)
            {
                return Ok(Supermercado);
            }
            else
            {
                return NotFound();
            }
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
        ///     "Id": 1,
        ///     "Nome": Tauste,
        ///     "Lat": -22.225837,
        ///     "Lng": -49.933186
        ///  }
        /// </remarks>
        /// <response code="200">OK</response>
        /// <response code="201">Criado</response>
        /// <response code="400">Solicitação imprópria (Bad Request)</response>
        /// <response code="404">Não Encontrado (Not Found)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(Supermercado))]
        public IHttpActionResult Post(Supermercado Supermercado)
        {
            var uuid = Guid.NewGuid().ToString();

            Supermercado.Id = uuid;

            if (Supermercado != null)
            {
                _supermercados.Add(Supermercado);
                return Ok(Supermercado);
            }
            else
            {
                return NotFound();
            }
        }


        //PUT
        /// <summary>
        /// Atualizar Supermercado
        /// </summary>
        /// <param name="Supermercado">Supermercado Modelo</param>
        /// <param name="Id">Id do Supermercado</param>
        /// <param name="Nome">Nome do Supermercado</param>
        /// <param name="Lat">Latitude do Supermercado</param>
        /// <param name="Lng">Longitude do Supermercado</param>
        /// <response code="200">OK</response>
        /// <response code="400">Solicitação imprópria (Bad Request)</response>
        /// <response code="404">Não Encontrado (Not Found)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(Supermercado))]
        public IHttpActionResult Put(String id, Supermercado Supermercado)
        {
            Supermercado NovoSupermercado = _supermercados.Find(x => x.Id.Equals(id));

            if (Supermercado != null)
            {
                NovoSupermercado.Nome = Supermercado.Nome;
                NovoSupermercado.Lat = Supermercado.Lat;
                NovoSupermercado.Lng = Supermercado.Lng;
                return Ok();
            }
            else
            {
                return NotFound();
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
        /// <response code="404">Não Encontrado (Not Found)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(Supermercado))]
        public IHttpActionResult Delete(String id)
        {
            if (id != null)
            {
                _supermercados = _supermercados.Where(note => !(note.Id.Equals(id))).ToList();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}