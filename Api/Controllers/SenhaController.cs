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
            new Senha(){Id="1",IdServico="1",IdUsuario="1",SenhaUsuario=18}
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
        /// <response code="404">Não Encontrado (Not Found)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(Senha))]
        public IHttpActionResult Get()
        {
            return Ok(_senhas);
        }


        //GET ID
        /// <summary>
        /// Listar Senha
        /// </summary>
        /// <param name = "Senha" > Senha Modelo</param>
        /// <param name="Id">Id da Senha</param>
        /// <param name="IdServico">Id do Serviço</param>
        /// <param name="IdUsuario">Id do Usuário</param>
        /// <param name="SenhaUsuario">Senha do Usuario</param>
        /// <response code="200">OK</response>
        /// <response code="400">Solicitação imprópria (Bad Request)</response>
        /// <response code="404">Não Encontrado (Not Found)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(Senha))]
        public IHttpActionResult GetId(String id)
        {
            Senha Senha = _senhas.Find(x => x.Id == id);

            if (Senha != null)
            {
                return Ok(Senha);
            }
            else
            {
                return NotFound();
            }
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
        ///    "Id": 1,
        ///    "IdSupermercado": 1,
        ///    "IdTipoServico": 2,
        ///    "AtualSenha": 20,
        ///    "ProxSenha": 30
        ///  }
        /// </remarks>
        /// <response code="200">OK</response>
        /// <response code="201">Criado</response>
        /// <response code="400">Solicitação imprópria (Bad Request)</response>
        /// <response code="404">Não Encontrado (Not Found)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(Senha))]
        public IHttpActionResult Post(Senha Senha)
        {
            var uuid = Guid.NewGuid().ToString();

            Senha.Id = uuid;

            if (Senha != null)
            {
                _senhas.Add(Senha);
                return Ok(Senha);
            }
            else
            {
                return NotFound();
            }
        }


        //PUT
        /// <summary>
        /// Atualizar Senha
        /// </summary>
        /// <param name="Senha">Senha Modelo</param>
        /// <param name="Id">Id da Senha</param>
        /// <param name="IdServico">Id do Serviço</param>
        /// <param name="IdUsuario">Id do Usuário</param>
        /// <param name="SenhaUsuario">Senha do Usuario</param>
        /// <response code="200">OK</response>
        /// <response code="400">Solicitação imprópria (Bad Request)</response>
        /// <response code="404">Não Encontrado (Not Found)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(Senha))]
        public IHttpActionResult Put(String id, Senha Senha)
        {
            Senha NovaSenha = _senhas.Find(x => x.Id.Equals(id));

            if (Senha != null)
            {
                NovaSenha.Id = Senha.Id;
                NovaSenha.IdServico = Senha.IdServico;
                NovaSenha.IdUsuario = Senha.IdUsuario;
                NovaSenha.SenhaUsuario = Senha.SenhaUsuario;
                return Ok();
            }
            else
            {
                return NotFound();
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
        /// <response code="404">Não Encontrado (Not Found)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(Senha))]
        // DELETE api/values
        public IHttpActionResult Delete(String id)
        {
            if (id != null)
            {
                _senhas = _senhas.Where(note => !(note.Id.Equals(id))).ToList();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}