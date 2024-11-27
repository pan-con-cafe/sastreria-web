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
    [Table("Horario")]
    public class HorarioTable
    {
        [Key]
        public int idhorario {  get; set; }
        public string day {  get; set; }
        public TimeOnly horainicio { get; set; }
        public TimeOnly horafin {  get; set; }
        public bool state {  get; set; }
    }
}
