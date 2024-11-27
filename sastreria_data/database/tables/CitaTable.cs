using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace sastreria_data.database.tables
{
    [Table("Cita")]
    public class CitaTable
    {
        [Key]
        public int idcita { get; set; }
        public int idhistorial { get; set; }
        public int idcliente { get; set; }
        public DateTime citafecha { get; set; }
        public bool state {  get; set; }
        public string notes { get; set; }
    }
}
