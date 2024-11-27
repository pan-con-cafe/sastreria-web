using Microsoft.AspNetCore.Mvc;
using sastreria_data.database;
using sastreria_data.database.tables;

namespace WebSastreria.Controllers
{
    [ApiController]
    [Route("api/categoria")]
    public class CategoriaController : ControllerBase
    {
        private readonly SastreriaContext _db;
        private readonly ILogger<CategoriaController> _logger;

        public CategoriaController(SastreriaContext context, ILogger<CategoriaController> logger)
        {
            _db = context;
            _logger = logger;
        }

        // GET: api/categoria
        [HttpGet]
        [Route("")]
        public ActionResult<List<CategoriaTable>> ListCategorias()
        {
            try
            {
                var categorias = _db.Categoria.ToList();
                return Ok(categorias);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[CategoriaController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // GET: api/categoria/{id}
        [HttpGet("{id}")]
        public ActionResult<CategoriaTable> GetCategoria(int id)
        {
            try
            {
                var categoria = _db.Categoria.Find(id);

                if (categoria == null)
                {
                    return NotFound();
                }

                return Ok(categoria);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[CategoriaController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // POST: api/categoria
        [HttpPost]
        public ActionResult<CategoriaTable> CreateCategoria([FromBody] CategoriaTable categoria)
        {
            try
            {
                if (categoria == null)
                {
                    return BadRequest("Categoria is null.");
                }

                _db.Categoria.Add(categoria);
                _db.SaveChanges();

                return CreatedAtAction(nameof(GetCategoria), new { id = categoria.idcategoria }, categoria);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[CategoriaController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // PUT: api/categoria/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCategoria(int id, [FromBody] CategoriaTable categoria)
        {
            try
            {
                if (id != categoria.idcategoria)
                {
                    return BadRequest("Categoria ID mismatch.");
                }

                var existingCategoria = _db.Categoria.Find(id);
                if (existingCategoria == null)
                {
                    return NotFound();
                }

                _db.Entry(existingCategoria).CurrentValues.SetValues(categoria);
                _db.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"[CategoriaController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // DELETE: api/categoria/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCategoria(int id)
        {
            try
            {
                var categoria = _db.Categoria.Find(id);
                if (categoria == null)
                {
                    return NotFound();
                }

                _db.Categoria.Remove(categoria);
                _db.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"[CategoriaController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }
    }
}

