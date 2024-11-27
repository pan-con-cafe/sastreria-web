using Microsoft.AspNetCore.Mvc;
using sastreria_data.database;
using sastreria_data.database.tables;

namespace WebSastreria.Controllers
{
    [ApiController]
    [Route("api/estado")]
    public class EstadoController : ControllerBase
    {
        private readonly SastreriaContext _db;
        private readonly ILogger<EstadoController> _logger;

        public EstadoController(SastreriaContext context, ILogger<EstadoController> logger)
        {
            _db = context;
            _logger = logger;
        }

        // GET: api/estado
        [HttpGet]
        [Route("")]
        public ActionResult<List<EstadoTable>> ListEstado()
        {
            try
            {
                var estado = _db.Estado.ToList();
                return Ok(estado);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[EstadoController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // GET: api/estado/{id}
        [HttpGet("{id}")]
        public ActionResult<EstadoTable> GetEstado(int id)
        {
            try
            {
                var estado = _db.Estado.Find(id);

                if (estado == null)
                {
                    return NotFound();
                }

                return Ok(estado);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[EstadoController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // POST: api/estado
        [HttpPost]
        public ActionResult<EstadoTable> CreateEstado([FromBody] EstadoTable estado)
        {
            try
            {
                if (estado == null)
                {
                    return BadRequest("Estado is null.");
                }

                _db.Estado.Add(estado);
                _db.SaveChanges();

                return CreatedAtAction(nameof(GetEstado), new { id = estado.idestado }, estado);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[EstadoController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // PUT: api/estado/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateEstado(int id, [FromBody] EstadoTable estado)
        {
            try
            {
                if (id != estado.idestado)
                {
                    return BadRequest("Estado ID mismatch.");
                }

                var existingEstado = _db.Estado.Find(id);
                if (existingEstado == null)
                {
                    return NotFound();
                }

                _db.Entry(existingEstado).CurrentValues.SetValues(estado);
                _db.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"[EstadoController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // DELETE: api/estado/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteEstado(int id)
        {
            try
            {
                var estado = _db.Estado.Find(id);
                if (estado == null)
                {
                    return NotFound();
                }

                _db.Estado.Remove(estado);
                _db.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"[EstadoController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }
    }
}
