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
    public class UsuarioController : ApiController
    {
        //private Usuario db = new UsuarioContext();

        static List<Usuario> _usuarios = new List<Usuario> {
            new Usuario(){Id=1,Lat=22.15,Lng=-22.37}
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
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult Get()
        {
            return Ok(_usuarios);
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
        ///     "id": 1;
        ///     "lat": 22.10;
        ///     "lng": -23.10;
        ///  }
        /// </remarks>
        /// <response code="200">OK</response>
        /// <response code="201">Criado</response>
        /// <response code="400">Solicitação imprópria (Bad Request)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(Usuario))]
        public HttpResponseMessage Post([FromBody]Usuario user)
        {
             if (user != null)
            {
                _usuarios.Add(user);
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
        /// Deletar Usuário
        /// </summary>
        /// <param name="Usuario">Usuario Modelo</param>
        /// <param name="Id">Id do Usuário</param>
        /// <param name="Lat">Latitude do Usuário</param>
        /// <param name="Lng">Longitude do Usuário</param>
        /// <response code="200">OK</response>
        /// <response code="400">Solicitação imprópria (Bad Request)</response>
        /// <response code="500">Erro Interno de Servidor (Internal Server Error)</response>
        [ResponseType(typeof(Usuario))]
        // DELETE api/values
        public IHttpActionResult Delete(int id)
        {
            if (id != null)
            {
                //return new HttpResponseMessage(HttpStatusCode.OK);
                _usuarios = _usuarios.Where(note => note.Id != id).ToList();
                return Ok();
            }
            else
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            }
        }


        // PUT api/values
        //public IHttpActionResult Put(Usuario user)
        //{
        //    if (id != null)
        //    {
        //        //return new HttpResponseMessage(HttpStatusCode.OK);
        //        _usuarios = _usuarios.Where(note => note.Id != id).ToList();
        //        return Ok();
        //    }
        //    else
        //    {
        //        //throw new HttpResponseException(HttpStatusCode.NotFound);
        //        return NotFound();
        //    }
        //}
    }
}