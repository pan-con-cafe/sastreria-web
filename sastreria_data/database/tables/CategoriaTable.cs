using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace sastreria_data.database.tables
{
    [Table("Categoria")]
    public class CategoriaTable
    {
        [Key]
        public int idcategoria { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}
