using Microsoft.AspNetCore.Mvc;
using sastreria_data.database;
using sastreria_data.database.tables;

namespace WebSastreria.Controllers
{
    [ApiController]
    [Route("api/modelo")]
    public class ModeloController : ControllerBase
    {
        private readonly SastreriaContext _db;
        private readonly ILogger<ModeloController> _logger;

        public ModeloController(SastreriaContext context, ILogger<ModeloController> logger)
        {
            _db = context;
            _logger = logger;
        }

        // GET: api/modelo
        [HttpGet]
        [Route("")]
        public ActionResult<List<ModeloTable>> ListModelo()
        {
            try
            {
                var modelo = _db.Modelo.ToList();
                return Ok(modelo);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[ModeloController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // GET: api/modelo/{id}
        [HttpGet("{id}")]
        public ActionResult<ModeloTable> GetModelo(int id)
        {
            try
            {
                var modelo = _db.Modelo.Find(id);

                if (modelo == null)
                {
                    return NotFound();
                }

                return Ok(modelo);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[ModeloController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // POST: api/horario
        [HttpPost]
        public ActionResult<ModeloTable> CreateModelo([FromBody] ModeloTable modelo)
        {
            try
            {
                if (modelo == null)
                {
                    return BadRequest("Categoria is null.");
                }

                _db.Modelo.Add(modelo);
                _db.SaveChanges();

                return CreatedAtAction(nameof(GetModelo), new { id = modelo.idmodelo }, modelo);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[ModeloController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // PUT: api/modelo/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateModelo(int id, [FromBody] ModeloTable modelo)
        {
            try
            {
                if (id != modelo.idmodelo)
                {
                    return BadRequest("Modelo ID mismatch.");
                }

                var existingModelo = _db.Modelo.Find(id);
                if (existingModelo == null)
                {
                    return NotFound();
                }

                _db.Entry(existingModelo).CurrentValues.SetValues(modelo);
                _db.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"[ModeloController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // DELETE: api/modelo/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteModelo(int id)
        {
            try
            {
                var modelo = _db.Modelo.Find(id);
                if (modelo == null)
                {
                    return NotFound();
                }

                _db.Modelo.Remove(modelo);
                _db.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"[ModeloController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }
    }
}
