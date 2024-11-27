using Microsoft.AspNetCore.Mvc;
using sastreria_data.database;
using sastreria_data.database.tables;

namespace WebSastreria.Controllers
{
    [ApiController]
    [Route("api/datos")]
    public class DatosController : ControllerBase
    {
        private readonly SastreriaContext _db;
        private readonly ILogger<DatosController> _logger;

        public DatosController(SastreriaContext context, ILogger<DatosController> logger)
        {
            _db = context;
            _logger = logger;
        }

        // GET: api/datos
        [HttpGet]
        [Route("")]
        public ActionResult<List<DatosTable>> ListDatos()
        {
            try
            {
                var citas = _db.DatoSastreria.ToList();
                return Ok(citas);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[DatosController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // GET: api/dato/{id}
        [HttpGet("{id}")]
        public ActionResult<DatosTable> GetDatos(int id)
        {
            try
            {
                var dato = _db.DatoSastreria.Find(id);

                if (dato == null)
                {
                    return NotFound();
                }

                return Ok(dato);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[DatosController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // POST: api/dato
        [HttpPost]
        public ActionResult<DatosTable> CreateDatos([FromBody] DatosTable datos)
        {
            try
            {
                if (datos == null)
                {
                    return BadRequest("Dato is null.");
                }

                _db.DatoSastreria.Add(datos);
                _db.SaveChanges();

                return CreatedAtAction(nameof(GetDatos), new { id = datos.iddatosastreria }, datos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[DatosController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // PUT: api/datos/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateDatos(int id, [FromBody] DatosTable datos)
        {
            try
            {
                if (id != datos.iddatosastreria)
                {
                    return BadRequest("Datos ID mismatch.");
                }

                var existingDatos = _db.DatoSastreria.Find(id);
                if (existingDatos == null)
                {
                    return NotFound();
                }

                _db.Entry(existingDatos).CurrentValues.SetValues(datos);
                _db.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"[DatosController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // DELETE: api/datos/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteDatos(int id)
        {
            try
            {
                var datos = _db.DatoSastreria.Find(id);
                if (datos == null)
                {
                    return NotFound();
                }

                _db.DatoSastreria.Remove(datos);
                _db.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"[DatosController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }
    }
}

