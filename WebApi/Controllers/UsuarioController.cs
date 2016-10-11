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

        /// <summary>
        /// Gets some very important data from the server.
        /// </summary>
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult Get()
        {
            return Ok(_usuarios);
        }
        

        // POST api/values
        public HttpResponseMessage Post([FromBody]Usuario user)
        {
            var newUser = _usuarios;

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