using Microsoft.AspNetCore.Mvc;
using sastreria_data.database;
using sastreria_data.database.tables;

namespace WebSastreria.Controllers
{
    [ApiController]
    [Route("api/pedido")]
    public class PedidoController : ControllerBase
    {
        private readonly SastreriaContext _db;
        private readonly ILogger<PedidoController> _logger;

        public PedidoController(SastreriaContext context, ILogger<PedidoController> logger)
        {
            _db = context;
            _logger = logger;
        }

        // GET: api/pedido
        [HttpGet]
        [Route("")]
        public ActionResult<List<PedidoTable>> ListPedido()
        {
            try
            {
                var pedido = _db.Pedido.ToList();
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[PedidoController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // GET: api/pedido/{id} ------------------------------------ aqui me quede
        [HttpGet("{id}")]
        public ActionResult<PedidoTable> GetPedido(int id)
        {
            try
            {
                var pedido = _db.Pedido.Find(id);

                if (pedido == null)
                {
                    return NotFound();
                }

                return Ok(pedido);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[PedidoController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // POST: api/pedido
        [HttpPost]
        public ActionResult<PedidoTable> CreatePedido([FromBody] PedidoTable pedido)
        {
            try
            {
                if (pedido == null)
                {
                    return BadRequest("Pedido is null.");
                }

                _db.Pedido.Add(pedido);
                _db.SaveChanges();

                return CreatedAtAction(nameof(GetPedido), new { id = pedido.idpedido }, pedido);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[PedidoController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // PUT: api/pedido/{id}
        [HttpPut("{id}")]
        public ActionResult UpdatePedido(int id, [FromBody] PedidoTable pedido)
        {
            try
            {
                if (id != pedido.idpedido)
                {
                    return BadRequest("Pedido ID mismatch.");
                }

                var existingPedido = _db.Pedido.Find(id);
                if (existingPedido == null)
                {
                    return NotFound();
                }

                _db.Entry(existingPedido).CurrentValues.SetValues(pedido);
                _db.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"[PedidoController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        // DELETE: api/pedido/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePedido(int id)
        {
            try
            {
                var pedido = _db.Pedido.Find(id);
                if (pedido == null)
                {
                    return NotFound();
                }

                _db.Pedido.Remove(pedido);
                _db.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"[PedidoController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }
    }
}
