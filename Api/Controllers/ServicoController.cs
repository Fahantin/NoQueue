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
    public class ServicoController : ApiController
    {
        static List<Servico> _servicos = new List<Servico> {
            new Servico(){Id=1,IdSupermercado=1,IdTipoServico=2,atualSenha=20,proxSenha=30}
        };

        //GET
        /// <summary>
        /// Listar Todos os Serviços
        /// </summary>
        /// <param name="Servico">Serviço Modelo</param>
        /// <param name="Id">Id do Serviço</param>
        /// <param name="IdSupermercado">Id do Supermercado</param>
        /// <param name="IdTipoServico">Id do Tipo de Serviço</param>
        /// <param name="atualSenha">Atual Senha</param>
        /// <param name="proxSenha">Próxima Senha</param>
        /// <response code="200">OK</response>
        /// <response code="400">Solicitação imprópria (Bad Request)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(Servico))]
        public IHttpActionResult Get()
        {
            return Ok(_servicos);
        }


        //POST
        /// <summary>
        /// Adicionar Serviço
        /// </summary>
        /// <param name="Servico">Serviço Modelo</param>
        /// <param name="Id">Id do Serviço</param>
        /// <param name="IdSupermercado">Id do Supermercado</param>
        /// <param name="IdTipoServico">Id do Tipo de Serviço</param>
        /// <param name="atualSenha">Atual Senha</param>
        /// <param name="proxSenha">Próxima Senha</param>
        /// <remarks>/POST
        /// {
        ///    "id": 1;
        ///    "idSupermercado": 1;
        ///    "idTipoServico": 2;
        ///    "atualSenha": 20;
        ///    "proxSenha": 30;
        ///  }
        /// </remarks>
        /// <response code="200">OK</response>
        /// <response code="201">Criado</response>
        /// <response code="400">Solicitação imprópria (Bad Request)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(Servico))]
        public HttpResponseMessage Post([FromBody]Servico servico)
        {
            if (servico != null)
            {
                _servicos.Add(servico);
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
        /// Deletar Serviço
        /// </summary>
        /// <param name="Servico">Serviço Modelo</param>
        /// <param name="Id">Id do Serviço</param>
        /// <param name="IdSupermercado">Id do Supermercado</param>
        /// <param name="IdTipoServico">Id do Tipo de Serviço</param>
        /// <param name="atualSenha">Atual Senha</param>
        /// <param name="proxSenha">Próxima Senha</param>
        /// <response code="200">OK</response>
        /// <response code="400">Solicitação imprópria (Bad Request)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(Servico))]
        // DELETE api/values
        public IHttpActionResult Delete(int id)
        {
            if (id != null)
            {
                //return new HttpResponseMessage(HttpStatusCode.OK);
                _servicos = _servicos.Where(note => note.Id != id).ToList();
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