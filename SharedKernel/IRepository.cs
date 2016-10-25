using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel
{
    public interface IRepository
    {
        Usuario GetById(int id);
        IQueryable<Usuario> GetAll();
        void Save(Usuario usuario);
        void Delete(Usuario usuario);
    }
}
