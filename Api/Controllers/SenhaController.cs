using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace Domain.Controllers
{
    public class SenhaController : ApiController
    {
        static List<Senha> _senhas = new List<Senha> {
            new Senha(){Id=1,IdServico=1,IdUsuario=1,SenhaUsuario=19}
        };

        //GET
        /// <summary>
        /// Listar Todos as Senhas
        /// </summary>
        /// <param name="Senha">Senha Modelo</param>
        /// <param name="Id">Id da Senha</param>
        /// <param name="IdServico">Id do Serviço</param>
        /// <param name="IdUsuario">Id do Usuário</param>
        /// <param name="SenhaUsuario">Senha do Usuario</param>
        /// <response code="200">OK</response>
        /// <response code="400">Solicitação imprópria (Bad Request)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(Senha))]
        public IHttpActionResult Get()
        {
            return Ok(_senhas);
        }


        //POST
        /// <summary>
        /// Adicionar Senha
        /// </summary>
        /// <param name="Senha">Senha Modelo</param>
        /// <param name="Id">Id da Senha</param>
        /// <param name="IdServico">Id do Serviço</param>
        /// <param name="IdUsuario">Id do Usuário</param>
        /// <param name="SenhaUsuario">Senha do Usuario</param>
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
        [ResponseType(typeof(Senha))]
        public HttpResponseMessage Post([FromBody]Senha senha)
        {
            if (senha != null)
            {
                _senhas.Add(senha);
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
        /// Deletar Senha
        /// </summary>
        /// <param name="Senha">Senha Modelo</param>
        /// <param name="Id">Id da Senha</param>
        /// <param name="IdServico">Id do Serviço</param>
        /// <param name="IdUsuario">Id do Usuário</param>
        /// <param name="SenhaUsuario">Senha do Usuario</param>
        /// <response code="200">OK</response>
        /// <response code="400">Solicitação imprópria (Bad Request)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(Senha))]
        // DELETE api/values
        public IHttpActionResult Delete(int id)
        {
            if (id != null)
            {
                //return new HttpResponseMessage(HttpStatusCode.OK);
                _senhas = _senhas.Where(note => note.Id != id).ToList();
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