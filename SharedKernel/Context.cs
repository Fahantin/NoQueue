using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel
{
    public class Context : DbContext
    {

        public Context() : base("DefaultConnection")
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }

    }
}
