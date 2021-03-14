using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Teledocer.Models
{
    public class Types
    {
        [Key]
        public int Id_type { get; set; }
        [Required]
        public string Name_of_type { get; set; }
        public List<Clients> Clientes { get; set; }
    }
}
