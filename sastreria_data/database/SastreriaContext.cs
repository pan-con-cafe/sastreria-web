using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sastreria_data.database.tables;

namespace sastreria_data.database
{
    public class SastreriaContext : DbContext
    {
        public SastreriaContext(DbContextOptions<SastreriaContext> options) : base(options)
        {
        }
        public DbSet<CategoriaTable> Categoria { get; set; }
        public DbSet<CitaTable> Cita { get; set; }
        public DbSet<ClienteTable> Cliente { get; set; }
        public DbSet<DatosTable> DatoSastreria { get; set; }
        public DbSet<EstadoTable> Estado { get; set; }
        public DbSet<HorarioTable> Horario { get; set; }
        public DbSet<ModeloImagenTable> ModeloImagen { get; set; }
        public DbSet<ModeloTable> Modelo { get; set; }
        public DbSet<PedidoTable> Pedido { get; set; }
        public DbSet<SastreTable> Sastre { get; set; }
        public DbSet<TipoDocumentoTable> TipoDocumento { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Seed();
        }
    }
}
