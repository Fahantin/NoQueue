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
        static List<TipoServico> _tipoServico = new List<TipoServico> {
            new TipoServico(){Id="1",Nome="Açougue"}
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
        /// <response code="404">Não Encontrado (Not Found)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(TipoServico))]
        public IHttpActionResult Get()
        {
            return Ok(_tipoServico);
        }


        //GET ID
        /// <summary>
        /// Listar Tipo de Serviço
        /// </summary>
        /// <param name="Tipo Servico">Tipo Serviço Modelo</param>
        /// <param name="Id">Id do Tipo de Serviço</param>
        /// <param name="Nome">Nome do Tipo de Serviço</param>
        /// <response code="200">OK</response>
        /// <response code="400">Solicitação imprópria (Bad Request)</response>
        /// <response code="404">Não Encontrado (Not Found)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(TipoServico))]
        public IHttpActionResult GetId(String id)
        {
            TipoServico TipoServico = _tipoServico.Find(x => x.Id == id);

            if (TipoServico != null)
            {
                return Ok(TipoServico);
            }
            else
            {
                return NotFound();
            }
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
        ///     "Id": 1,
        ///     "Nome": Açougue
        ///  }
        /// </remarks>
        /// <response code="200">OK</response>
        /// <response code="201">Criado</response>
        /// <response code="400">Solicitação imprópria (Bad Request)</response>
        /// <response code="404">Não Encontrado (Not Found)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(TipoServico))]
        public IHttpActionResult Post(TipoServico TipoServico)
        {
            var uuid = Guid.NewGuid().ToString();

            TipoServico.Id = uuid;

            if (TipoServico != null)
            {
                _tipoServico.Add(TipoServico);
                return Ok(TipoServico);
            }
            else
            {
                return NotFound();
            }
        }


        //PUT
        /// <summary>
        /// Atualizar Tipo de Serviço
        /// </summary>
        /// <param name="Tipo Servico">Tipo Serviço Modelo</param>
        /// <param name="Id">Id do Tipo de Serviço</param>
        /// <param name="Nome">Nome do Tipo de Serviço</param>
        /// <response code="200">OK</response>
        /// <response code="400">Solicitação imprópria (Bad Request)</response>
        /// <response code="404">Não Encontrado (Not Found)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(TipoServico))]
        public IHttpActionResult Put(String id, TipoServico TipoServico)
        {
            TipoServico NovoTipoServico = _tipoServico.Find(x => x.Id.Equals(id));

            if (NovoTipoServico != null)
            {
                NovoTipoServico.Nome = TipoServico.Nome;
                return Ok();
            }
            else
            {
                return NotFound();
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
        /// <response code="404">Não Encontrado (Not Found)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(TipoServico))]
        public IHttpActionResult Delete(String id)
        {
            if (id != null)
            {
                _tipoServico = _tipoServico.Where(note => !(note.Id.Equals(id))).ToList();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}