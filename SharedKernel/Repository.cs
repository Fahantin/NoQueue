using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace SharedKernel
{
    public class Repository : IRepository
    {

        public Context _Db { get; set; }

        public Repository()
        {
            _Db = new Context();
        }

        public void Delete(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Usuario> GetAll()
        {
            throw new NotImplementedException();
        }

        public Usuario GetById(int id)
        {
            return _Db.Usuarios.Find(id);
        }

        public void Save(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
