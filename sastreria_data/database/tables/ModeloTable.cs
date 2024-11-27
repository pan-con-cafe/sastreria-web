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
    [Table("Modelo")]
    public class ModeloTable
    {
        [Key]
        public int idmodelo { get; set; }
        public int idcategoria { get; set; }
        public int idmodeloimagen { get; set; }
        public string name { get; set; }
        public string description {  get; set; }
        public DateTime creationdate { get; set; }
    }
}
