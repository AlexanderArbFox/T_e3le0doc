using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Teledocer.Models
{
    public class founder
    {
        [Required]
        public int Id_founder { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Inn_uch { get; set; }
        [Required]
        public string Fio { get; set; }
        public DateTime Date_add { get; set; }
        public DateTime Date_reload { get; set; }

        [ForeignKey("Id_founder")]
        public Clients Clients { get; set; }
    }
}
