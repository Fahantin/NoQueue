using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    //[Table("Usuario")]
    public class Usuario
    {
        //[Key]
        [Required]
        public String Id { get; set; }

        //[MaxLength(20)]
        [Required]
        public double Lat { get; set; }

        //[MaxLength(20)]
        [Required]
        public double Lng { get; set; }
        
        public Usuario()
        {

        }

        public Usuario(String id, double lat, double lng)
        {
            this.Id = id;
            this.Lat = lat;
            this.Lng = lng;
        }
    }
}
