using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Proyecto.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesPedidoController : ControllerBase
    {
        // GET: api/<DetallesPedidoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DetallesPedidoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DetallesPedidoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DetallesPedidoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DetallesPedidoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
