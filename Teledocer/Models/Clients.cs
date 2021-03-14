using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Teledocer.Models
{
    public class Clients
    {
        [Key]
        public int Id_clients { get; set; }

        [Required]
        public long Inn_kl { get; set; }

        [Required]
        public string Name_corp { get; set; }

       [Required]
        public int Type { get; set; }

        public DateTime Data_add { get; set; }
        public DateTime Data_reload { get; set; }
        public List<founder> Founders { get; set; }

        [ForeignKey("Type")]
        public Types Types { get; set; }
    }
}
