using Microsoft.AspNetCore.Mvc;
using sastreria_data.database;
using sastreria_data.database.tables;

namespace WebSastreria.Controllers
{
    [ApiController]
    [Route("api/sastre")]
    public class SastreController : ControllerBase
    {
        private readonly SastreriaContext _db;
        private readonly ILogger<SastreController> _logger;

        public SastreController(SastreriaContext context, ILogger<SastreController> logger)
        {
            _db = context;
            _logger = logger;
        }

        // GET: api/sastre
        [HttpGet]
        [Route("")]
        public ActionResult<List<SastreTable>> ListSastre()
        {
            try
            {
                var sastre = _db.Sastre.ToList();
                return Ok(sastre);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[SastreController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // GET: api/sastre/{id}
        [HttpGet("{id}")]
        public ActionResult<SastreTable> GetSastre(int id)
        {
            try
            {
                var sastre = _db.Sastre.Find(id);

                if (sastre == null)
                {
                    return NotFound();
                }

                return Ok(sastre);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[SastreController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }
        
        // POST: api/sastre
        [HttpPost]
        public ActionResult<SastreTable> CreateSastre([FromBody] SastreTable sastre)
        {
            try
            {
                if (sastre == null)
                {
                    return BadRequest("Sastre is null.");
                }

                _db.Sastre.Add(sastre);
                _db.SaveChanges();

                return CreatedAtAction(nameof(GetSastre), new { id = sastre.idsastre }, sastre);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[SastreController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // PUT: api/sastre/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateSastre(int id, [FromBody] SastreTable sastre)
        {
            try
            {
                if (id != sastre.idsastre)
                {
                    return BadRequest("Sastre ID mismatch.");
                }

                var existingSastre = _db.Sastre.Find(id);
                if (existingSastre == null)
                {
                    return NotFound();
                }

                _db.Entry(existingSastre).CurrentValues.SetValues(sastre);
                _db.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"[SastreController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // DELETE: api/sastre/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteSastre(int id)
        {
            try
            {
                var sastre = _db.Sastre.Find(id);
                if (sastre == null)
                {
                    return NotFound();
                }

                _db.Sastre.Remove(sastre);
                _db.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"[SastreController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }
    }
}
