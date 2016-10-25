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
            new Servico(){Id="1",IdSupermercado="1",IdTipoServico="2",AtualSenha=20,ProxSenha=30}
        };


        //GET
        /// <summary>
        /// Listar Todos os Serviços
        /// </summary>
        /// <param name="Servico">Serviço Modelo</param>
        /// <param name="Id">Id do Serviço</param>
        /// <param name="IdSupermercado">Id do Supermercado</param>
        /// <param name="IdTipoServico">Id do Tipo de Serviço</param>
        /// <param name="AtualSenha">Atual Senha</param>
        /// <param name="ProxSenha">Próxima Senha</param>
        /// <response code="200">OK</response>
        /// <response code="400">Solicitação imprópria (Bad Request)</response>
        /// <response code="404">Não Encontrado (Not Found)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(Servico))]
        public IHttpActionResult Get()
        {
            return Ok(_servicos);
        }


        //GET ID
        /// <summary>
        /// Listar Serviço
        /// </summary>
        /// <param name="Servico">Serviço Modelo</param>
        /// <param name="Id">Id do Serviço</param>
        /// <param name="IdSupermercado">Id do Supermercado</param>
        /// <param name="IdTipoServico">Id do Tipo de Serviço</param>
        /// <param name="AtualSenha">Atual Senha</param>
        /// <param name="ProxSenha">Próxima Senha</param>
        /// <response code="200">OK</response>
        /// <response code="400">Solicitação imprópria (Bad Request)</response>
        /// <response code="404">Não Encontrado (Not Found)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(Servico))]
        public IHttpActionResult GetId(String id)
        {
            Servico Servico = _servicos.Find(x => x.Id == id);

            if (Servico != null)
            {
                return Ok(Servico);
            }
            else
            {
                return NotFound();
            }
        }


        //POST
        /// <summary>
        /// Adicionar Serviço
        /// </summary>
        /// <param name="Servico">Serviço Modelo</param>
        /// <param name="Id">Id do Serviço</param>
        /// <param name="IdSupermercado">Id do Supermercado</param>
        /// <param name="IdTipoServico">Id do Tipo de Serviço</param>
        /// <param name="AtualSenha">Atual Senha</param>
        /// <param name="ProxSenha">Próxima Senha</param>
        /// <remarks>/POST
        /// {
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
        [ResponseType(typeof(Servico))]
        public IHttpActionResult Post(Servico Servico)
        {
            var uuid = Guid.NewGuid().ToString();

            Servico.Id = uuid;

            if (Servico != null)
            {
                _servicos.Add(Servico);
                return Ok(Servico);
            }
            else
            {
                return NotFound();
            }
        }



        //PUT
        /// <summary>
        /// Atualizar Serviço
        /// </summary>
        /// <param name="Servico">Serviço Modelo</param>
        /// <param name="Id">Id do Serviço</param>
        /// <param name="IdSupermercado">Id do Supermercado</param>
        /// <param name="IdTipoServico">Id do Tipo de Serviço</param>
        /// <param name="AtualSenha">Atual Senha</param>
        /// <param name="ProxSenha">Próxima Senha</param>
        /// <remarks>/PUT
        /// {
        ///    "Id": 1,
        ///    "IdSupermercado": 1,
        ///    "IdTipoServico": 2,
        ///    "AtualSenha": 20,
        ///    "ProxSenha": 30
        ///  }
        /// </remarks>
        /// <response code="200">OK</response>
        /// <response code="400">Solicitação imprópria (Bad Request)</response>
        /// <response code="404">Não Encontrado (Not Found)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(Servico))]
        public IHttpActionResult Put(String id, Servico Servico)
        {
            Servico NovoServico = _servicos.Find(x => x.Id.Equals(id));

            if (Servico != null)
            {
                NovoServico.Id = Servico.Id;
                NovoServico.IdSupermercado = Servico.IdSupermercado;
                NovoServico.IdTipoServico = Servico.IdTipoServico;
                NovoServico.ProxSenha = Servico.ProxSenha;
                NovoServico.AtualSenha = Servico.AtualSenha;               
                return Ok();
            }
            else
            {
                return NotFound();
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
        /// <param name="AtualSenha">Atual Senha</param>
        /// <param name="ProxSenha">Próxima Senha</param>
        /// <response code="200">OK</response>
        /// <response code="400">Solicitação imprópria (Bad Request)</response>
        /// <response code="404">Não Encontrado (Not Found)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(Servico))]
        public IHttpActionResult Delete(String id)
        {
            if (id != null)
            {
                _servicos = _servicos.Where(note => !(note.Id.Equals(id))).ToList();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}