﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace sastreria_data.database.tables
{
    [Table("ModeloImagen")]
    public class ModeloImagenTable
    {
        [Key]
        public int idmodeloimagen { get; set; }
        public string url { get; set; }
    }
}
