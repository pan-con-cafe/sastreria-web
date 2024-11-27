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
    [Table("Cliente")]
    public class ClienteTable
    {
        [Key]
        public int idcliente { get; set; }
        public int idtipodocumento{ get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string phonenumber { get; set; }
    }
}
