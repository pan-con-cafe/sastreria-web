using Microsoft.AspNetCore.Mvc;
using sastreria_data.database;
using sastreria_data.database.tables;

namespace WebSastreria.Controllers
{
    [ApiController]
    [Route("api/horario")]
    public class HorarioController : ControllerBase
    {
        private readonly SastreriaContext _db;
        private readonly ILogger<HorarioController> _logger;

        public HorarioController(SastreriaContext context, ILogger<HorarioController> logger)
        {
            _db = context;
            _logger = logger;
        }

        // GET: api/horario
        [HttpGet]
        [Route("")]
        public ActionResult<List<HorarioTable>> ListHorario()
        {
            try
            {
                var horario = _db.Horario.ToList();
                return Ok(horario);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[HorarioController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // GET: api/horario/{id}
        [HttpGet("{id}")]
        public ActionResult<HorarioTable> GetHorario(int id)
        {
            try
            {
                var horario = _db.Horario.Find(id);

                if (horario == null)
                {
                    return NotFound();
                }

                return Ok(horario);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[HorarioController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // POST: api/horario
        [HttpPost]
        public ActionResult<HorarioTable> CreateHorario([FromBody] HorarioTable horario)
        {
            try
            {
                if (horario == null)
                {
                    return BadRequest("Categoria is null.");
                }

                _db.Horario.Add(horario);
                _db.SaveChanges();

                return CreatedAtAction(nameof(GetHorario), new { id = horario.idhorario }, horario);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[HorarioController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // PUT: api/horario/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateHorario(int id, [FromBody] HorarioTable horario)
        {
            try
            {
                if (id != horario.idhorario)
                {
                    return BadRequest("Horario ID mismatch.");
                }

                var existingHorario = _db.Horario.Find(id);
                if (existingHorario == null)
                {
                    return NotFound();
                }

                _db.Entry(existingHorario).CurrentValues.SetValues(horario);
                _db.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"[HorarioController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // DELETE: api/horario/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteHorario(int id)
        {
            try
            {
                var horario = _db.Horario.Find(id);
                if (horario == null)
                {
                    return NotFound();
                }

                _db.Horario.Remove(horario);
                _db.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"[HorarioController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }
    }
}
