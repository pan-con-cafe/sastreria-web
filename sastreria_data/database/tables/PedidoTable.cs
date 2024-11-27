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
    [Table("Pedido")]
    public class PedidoTable
    {
        [Key]
        public int idpedido {  get; set; }
        public DateTime fechaentrega {  get; set; }
        public string details {  get; set; }
        public int idsastre { get; set; }
        public int idcliente { get; set; }
        public int idestado { get; set; }
        public int idmodelo { get; set; }
    }
}
