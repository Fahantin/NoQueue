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
    /// <summary>
    /// Usuário Controller
    /// </summary>
    public class UsuarioController : ApiController
    {
        //private Usuario db = new UsuarioContext();

        static List<Usuario> _usuarios = new List<Usuario> {
            new Usuario(){Id="1",Lat=22.15,Lng=-22.37}
        };


        //GET
        /// <summary>
        /// Listar Todos os Usuários
        /// </summary>
        /// <param name="Usuario">Usuario Modelo</param>
        /// <param name="Id">Id do Usuário</param>
        /// <param name="Lat">Latitude do Usuário</param>
        /// <param name="Lng">Longitude do Usuário</param>
        /// <response code="200">OK</response>
        /// <response code="400">Solicitação imprópria (Bad Request)</response>
        /// <response code="404">Não Encontrado (Not Found)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult Get()
        {
            return Ok(_usuarios);
        }


        //GET ID
        /// <summary>
        /// Listar Usuário
        /// </summary>
        /// <param name="Usuario">Usuario Modelo</param>
        /// <param name="Id">Id do Usuário</param>
        /// <param name="Lat">Latitude do Usuário</param>
        /// <param name="Lng">Longitude do Usuário</param>
        /// <response code="200">OK</response>
        /// <response code="400">Solicitação imprópria (Bad Request)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult GetId(String id)
        {
            Usuario Usuario = _usuarios.Find(x => x.Id == id);

            if (Usuario != null)
            {
                return Ok(Usuario);
            }
            else
            {
                return NotFound();
            }
        }


        //POST
        /// <summary>
        /// Adicionar Usuário
        /// </summary>
        /// <param name="Usuario">Usuario Modelo</param>
        /// <param name="Id">Id do Usuário</param>
        /// <param name="Lat">Latitude do Usuário</param>
        /// <param name="Lng">Longitude do Usuário</param>
        /// <remarks>/POST
        /// {
        ///     "Id": 1,
        ///     "Lat": 22.10,
        ///     "Lng": -23.10
        ///  }
        /// </remarks>
        /// <response code="200">OK</response>
        /// <response code="201">Criado</response>
        /// <response code="400">Solicitação imprópria (Bad Request)</response>
        /// <response code="404">Não Encontrado (Not Found)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult Post(Usuario Usuario)
        {
            var uuid = Guid.NewGuid().ToString();

            Usuario.Id = uuid;

            if (Usuario != null)
            {
                _usuarios.Add(Usuario);
                return Ok(Usuario);
            }
            else
            {
                return NotFound();
            }
        }


        //PUT
        /// <summary>
        /// Atualizar Usuário
        /// </summary>
        /// <param name="Usuario">Usuario Modelo</param>
        /// <param name="Id">Id do Usuário</param>
        /// <param name="Lat">Latitude do Usuário</param>
        /// <param name="Lng">Longitude do Usuário</param>
        /// <response code="200">OK</response>
        /// <response code="400">Solicitação imprópria (Bad Request)</response>
        /// <response code="404">Não Encontrado (Not Found)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult Put(String id, Usuario Usuario)
        {
            Usuario NovoUsuario = _usuarios.Find(x => x.Id.Equals(id));

            if (NovoUsuario != null)
            {
                NovoUsuario.Lat = Usuario.Lat;
                NovoUsuario.Lng = Usuario.Lng;
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }


        //DELETE
        /// <summary>
        /// Deletar Usuário
        /// </summary>
        /// <param name="Usuario">Usuario Modelo</param>
        /// <param name="Id">Id do Usuário</param>
        /// <param name="Lat">Latitude do Usuário</param>
        /// <param name="Lng">Longitude do Usuário</param>
        /// <response code="200">OK</response>
        /// <response code="400">Solicitação imprópria (Bad Request)</response>
        /// <response code="404">Não Encontrado (Not Found)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult Delete(String id)
        {
            if (id != null)
            {
                _usuarios = _usuarios.Where(note => !(note.Id.Equals(id))).ToList();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}