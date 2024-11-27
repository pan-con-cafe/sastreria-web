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
    [Table("Sastre")]
    public class SastreTable
    {
        [Key]
        public int idsastre {  get; set; }
        public string name {  get; set; }
        public string email {  get; set; }
        public string password { get; set; }
    }
}
