using Microsoft.AspNetCore.Mvc;
using sastreria_data.database;
using sastreria_data.database.tables;

namespace WebSastreria.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly SastreriaContext _db;
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(SastreriaContext context, ILogger<ClienteController> logger)
        {
            _db = context;
            _logger = logger;
        }

        // GET: api/cliente
        [HttpGet]
        [Route("")]
        public ActionResult<List<ClienteTable>> ListClientes()
        {
            try
            {
                var clientes = _db.Cliente.ToList();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[ClienteController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // GET: api/cliente/{id}
        [HttpGet("{id}")]
        public ActionResult<ClienteTable> GetCliente(int id)
        {
            try
            {
                var cliente = _db.Cliente.Find(id);

                if (cliente == null)
                {
                    return NotFound();
                }

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[ClienteController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // POST: api/cliente
        [HttpPost]
        public ActionResult<ClienteTable> CreateCliente([FromBody] ClienteTable cliente)
        {
            try
            {
                if (cliente == null)
                {
                    return BadRequest("Cliente is null.");
                }

                _db.Cliente.Add(cliente);
                _db.SaveChanges();

                return CreatedAtAction(nameof(GetCliente), new { id = cliente.idcliente }, cliente);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[CitaCliente] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // PUT: api/cliente/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCliente(int id, [FromBody] ClienteTable cliente)
        {
            try
            {
                if (id != cliente.idcliente)
                {
                    return BadRequest("Cliente ID mismatch.");
                }

                var existingCliente = _db.Cliente.Find(id);
                if (existingCliente == null)
                {
                    return NotFound();
                }

                _db.Entry(existingCliente).CurrentValues.SetValues(cliente);
                _db.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"[ClienteController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // DELETE: api/cliente/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCliente(int id)
        {
            try
            {
                var cliente = _db.Cliente.Find(id);
                if (cliente == null)
                {
                    return NotFound();
                }

                _db.Cliente.Remove(cliente);
                _db.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"[ClienteController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }
    }
}
