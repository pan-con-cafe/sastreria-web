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
    [Table("Estado")]
    public class EstadoTable
    {
        [Key]
        public int idestado {  get; set; }
        public string name { get; set; }
    }
}
