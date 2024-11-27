using Microsoft.AspNetCore.Mvc;
using sastreria_data.database;
using sastreria_data.database.tables;

namespace WebSastreria.Controllers
{
    [ApiController]
    [Route("api/modeloimagen")]
    public class ModeloImagenController : ControllerBase
    {
        private readonly SastreriaContext _db;
        private readonly ILogger<ModeloImagenController> _logger;

        public ModeloImagenController(SastreriaContext context, ILogger<ModeloImagenController> logger)
        {
            _db = context;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<ModeloImagenTable>> ListModeloImagen()
        {
            try
            {
                var modeloimagen = _db.ModeloImagen.ToList();
                return Ok(modeloimagen);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[ModeloImagenController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // GET: api/modeloimagen/{id}
        [HttpGet("{id}")]
        public ActionResult<ModeloImagenTable> GetModeloImagen(int id)
        {
            try
            {
                var modeloimagen = _db.ModeloImagen.Find(id);

                if (modeloimagen == null)
                {
                    return NotFound();
                }

                return Ok(modeloimagen);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[ModeloImagenController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        [HttpPost]
        public ActionResult<ModeloImagenTable> CreateModeloImagen([FromBody] ModeloImagenTable modeloimagen)
        {
            try
            {
                if (modeloimagen == null)
                {
                    return BadRequest("ModeloImagen is null.");
                }

                _db.ModeloImagen.Add(modeloimagen);
                _db.SaveChanges();

                return CreatedAtAction(nameof(GetModeloImagen), new { id = modeloimagen.idmodeloimagen }, modeloimagen);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[ModeloImagenController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateModeloImagen(int id, [FromBody] ModeloImagenTable modeloimagen)
        {
            try
            {
                if (id != modeloimagen.idmodeloimagen)
                {
                    return BadRequest("ModeloImagen ID mismatch.");
                }

                var existingModeloImagen = _db.ModeloImagen.Find(id);
                if (existingModeloImagen == null)
                {
                    return NotFound();
                }

                _db.Entry(existingModeloImagen).CurrentValues.SetValues(modeloimagen);
                _db.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"[ModeloImagenController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteModeloImagen(int id)
        {
            try
            {
                var modeloimagen = _db.ModeloImagen.Find(id);
                if (modeloimagen == null)
                {
                    return NotFound();
                }

                _db.ModeloImagen.Remove(modeloimagen);
                _db.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"[ModeloImagenController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }
    }
}
