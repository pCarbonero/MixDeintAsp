using BL;
using Entidades;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudAsp.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoApiController : ControllerBase
    {
        // GET: api/<DepartamentoApiController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<clsDepartamento> listadoCompleto = new List<clsDepartamento>();
            try
            {
                listadoCompleto = clsListadosBL.listadoCompletoDepartamentosBL();
                if (listadoCompleto.Count() == 0)
                {
                    salida = NoContent();
                }
                else
                {
                    salida = Ok(listadoCompleto);
                }
            }
            catch
            {
                salida = BadRequest();
            }
            return salida;
        }

        // GET api/<DepartamentoApiController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult salida;
            clsDepartamento dept;
            try
            {
                dept = clsListadosBL.getDepartamentoIdBL(id);
                if (dept == null)
                {
                    salida = NoContent();
                }
                else
                {
                    salida = Ok(dept);
                }
            }
            catch
            {
                salida = BadRequest();
            }
            return salida;
        }

        // POST api/<DepartamentoApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DepartamentoApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DepartamentoApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
