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
    [Table("DatoSastreria")]
    public class DatosTable
    {
        [Key]
        public int iddatosastreria { get; set; }
        public string name { get; set; }
        public string phonenumber { get; set; }
        public string address { get; set; }
        public string description { get; set; }
        public string picture { get; set; }
    }
}
