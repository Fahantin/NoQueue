using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Supermercado
    {
        public String Id { get; set; }
        public String Nome { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }

        public Supermercado()
        {

        }

        public Supermercado(String id, String nome, double lat, double lng)
        {
            this.Id = id;
            this.Nome = nome;
            this.Lat = lat;
            this.Lng = lng;
        }
    }
}
