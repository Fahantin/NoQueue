using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace Domain.Controllers
{
    public class TipoServicoController : ApiController
    {
        static List<TipoServico> _tipos = new List<TipoServico> {
            new TipoServico(){Id=1,Nome="Açougue"}
        };

        //GET
        /// <summary>
        /// Listar Todos os Tipos de Serviços
        /// </summary>
        /// <param name="Tipo Servico">Tipo Serviço Modelo</param>
        /// <param name="Id">Id do Tipo de Serviço</param>
        /// <param name="Nome">Nome do Tipo de Serviço</param>
        /// <response code="200">OK</response>
        /// <response code="400">Solicitação imprópria (Bad Request)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(TipoServico))]
        public IHttpActionResult Get()
        {
            return Ok(_tipos);
        }


        //POST
        /// <summary>
        /// Adicionar Tipo de Serviço
        /// </summary>
        /// <param name="Tipo Servico">Tipo Serviço Modelo</param>
        /// <param name="Id">Id do Tipo de Serviço</param>
        /// <param name="Nome">Nome do Tipo de Serviço</param>
        /// <remarks>/POST
        /// {
        ///     "id": 1;
        ///     "name": Açougue;
        ///  }
        /// </remarks>
        /// <response code="200">OK</response>
        /// <response code="201">Criado</response>
        /// <response code="400">Solicitação imprópria (Bad Request)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(TipoServico))]
        public HttpResponseMessage Post([FromBody]TipoServico tipoServico)
        {
            if (tipoServico != null)
            {
                _tipos.Add(tipoServico);
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
        /// Deletar Tipo de Serviço
        /// </summary>
        /// <param name="Tipo Servico">Tipo Serviço Modelo</param>
        /// <param name="Id">Id do Tipo de Serviço</param>
        /// <param name="Nome">Nome do Tipo de Serviço</param>
        /// <response code="200">OK</response>
        /// <response code="400">Solicitação imprópria (Bad Request)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(TipoServico))]
        // DELETE api/values
        public IHttpActionResult Delete(int id)
        {
            if (id != null)
            {
                //return new HttpResponseMessage(HttpStatusCode.OK);
                _tipos = _tipos.Where(note => note.Id != id).ToList();
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