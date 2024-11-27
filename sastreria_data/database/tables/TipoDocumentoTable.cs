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
    [Table("TipoDocumento")]
    public class TipoDocumentoTable
    {
        [Key]
        public int idtipodocumento {  get; set; }
        public string name {  get; set; }
    }
}
