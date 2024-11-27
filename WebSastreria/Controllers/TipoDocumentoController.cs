using Microsoft.AspNetCore.Mvc;
using sastreria_data.database;
using sastreria_data.database.tables;

namespace WebSastreria.Controllers
{
    [ApiController]
    [Route("api/tipodocumento")]
    public class TipoDocumentoController : ControllerBase
    {
        private readonly SastreriaContext _db;
        private readonly ILogger<TipoDocumentoController> _logger;

        public TipoDocumentoController(SastreriaContext context, ILogger<TipoDocumentoController> logger)
        {
            _db = context;
            _logger = logger;
        }

        // GET: api/tipodocumento
        [HttpGet]
        [Route("")]
        public ActionResult<List<TipoDocumentoTable>> ListTipoDocumento()
        {
            try
            {
                var tipodocumento = _db.TipoDocumento.ToList();
                return Ok(tipodocumento);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[TipoDocumentoController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // GET: api/tipodocumento/{id}
        [HttpGet("{id}")]
        public ActionResult<TipoDocumentoTable> GetTipoDocumento(int id)
        {
            try
            {
                var tipodocumento = _db.TipoDocumento.Find(id);

                if (tipodocumento == null)
                {
                    return NotFound();
                }

                return Ok(tipodocumento);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[TipoDocumentoController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // POST: api/tipodocumento
        [HttpPost]
        public ActionResult<TipoDocumentoTable> CreateTipoDocumento([FromBody] TipoDocumentoTable tipodocumento)
        {
            try
            {
                if (tipodocumento == null)
                {
                    return BadRequest("TipoDocumento is null.");
                }

                _db.TipoDocumento.Add(tipodocumento);
                _db.SaveChanges();

                return CreatedAtAction(nameof(GetTipoDocumento), new { id = tipodocumento.idtipodocumento }, tipodocumento);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[TipoDocumentoController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // PUT: api/tipodocumento/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateTipoDocumento(int id, [FromBody] TipoDocumentoTable tipodocumento)
        {
            try
            {
                if (id != tipodocumento.idtipodocumento)
                {
                    return BadRequest("TipoDocumento ID mismatch.");
                }

                var existingTipoDocumento = _db.TipoDocumento.Find(id);
                if (existingTipoDocumento == null)
                {
                    return NotFound();
                }

                _db.Entry(existingTipoDocumento).CurrentValues.SetValues(tipodocumento);
                _db.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"[TipoDocumentoController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // DELETE: api/tipodocumento/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteTipoDocumento(int id)
        {
            try
            {
                var tipodocumento = _db.TipoDocumento.Find(id);
                if (tipodocumento == null)
                {
                    return NotFound();
                }

                _db.TipoDocumento.Remove(tipodocumento);
                _db.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"[TipoDocumentoController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }
    }
}
