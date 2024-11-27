using Microsoft.AspNetCore.Mvc;
using sastreria_data.database;
using sastreria_data.database.tables;

namespace WebSastreria.Controllers
{
    [ApiController]
    [Route("api/cita")]
    public class CitaController : ControllerBase
    {
        private readonly SastreriaContext _db;
        private readonly ILogger<CitaController> _logger;

        public CitaController(SastreriaContext context, ILogger<CitaController> logger)
        {
            _db = context;
            _logger = logger;
        }

        // GET: api/cita
        [HttpGet]
        [Route("")]
        public ActionResult<List<CitaTable>> ListCitas()
        {
            try
            {
                var citas = _db.Cita.ToList();
                return Ok(citas);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[CitaController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // GET: api/cita/{id}
        [HttpGet("{id}")]
        public ActionResult<CitaTable> GetCita(int id)
        {
            try
            {
                var cita = _db.Cita.Find(id);

                if (cita == null)
                {
                    return NotFound();
                }

                return Ok(cita);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[CitaController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // POST: api/cita
        [HttpPost]
        public ActionResult<CitaTable> CreateCita([FromBody] CitaTable cita)
        {
            try
            {
                if (cita == null)
                {
                    return BadRequest("Cita is null.");
                }

                _db.Cita.Add(cita);
                _db.SaveChanges();

                return CreatedAtAction(nameof(GetCita), new { id = cita.idcita }, cita);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[CitaController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // PUT: api/cita/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCita(int id, [FromBody] CitaTable cita)
        {
            try
            {
                if (id != cita.idcita)
                {
                    return BadRequest("Cita ID mismatch.");
                }

                var existingCita = _db.Cita.Find(id);
                if (existingCita == null)
                {
                    return NotFound();
                }

                _db.Entry(existingCita).CurrentValues.SetValues(cita);
                _db.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"[CitaController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // DELETE: api/cita/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCita(int id)
        {
            try
            {
                var cita = _db.Cita.Find(id);
                if (cita == null)
                {
                    return NotFound();
                }

                _db.Cita.Remove(cita);
                _db.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"[CitaController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }
    }
}
