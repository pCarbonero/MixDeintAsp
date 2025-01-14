using BL;
using Entidades;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudAsp.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaApiController : ControllerBase
    {
        // GET: api/<PersonaApiController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<clsPersona> listadoCompleto = new List<clsPersona>();
            try
            {
                listadoCompleto = clsListadosBL.listadoCompletoPersonasBL();
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


        // GET api/<PersonaApiController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult salida;
            clsPersona persona;
            try
            {
                persona = clsListadosBL.getPersonaIdBL(id);
                if (persona == null)
                {
                    salida = NoContent();
                }
                else
                {
                    salida = Ok(persona);
                }
            }
            catch
            {
                salida = BadRequest();
            }
            return salida;
        }

        // POST api/<PersonasController>
        [HttpPost]
        public IActionResult Post([FromBody] clsPersona persona)
        {
            bool guardadoCorrectamente;
            IActionResult salida;
            if (persona != null)
            {
                try
                {
                    guardadoCorrectamente = clsManejadoraBL.insertPersonaBL(persona);
                    salida = Ok(guardadoCorrectamente);
                }
                catch
                {
                    salida = BadRequest();
                }
            }
            else
            {
                salida = NoContent();
            }

            return salida;
        }

        // PUT api/<PersonasController>/
        [HttpPut]
        public IActionResult Put(clsPersona persona)
        {
            bool guardadoCorrectamente;
            IActionResult salida;
            if (persona != null)
            {
                try
                {
                    guardadoCorrectamente = clsManejadoraBL.updatePersonaBL(persona);
                    salida = Ok(guardadoCorrectamente);
                }
                catch
                {
                    salida = BadRequest();
                }
            }
            else
            {
                salida = NoContent();
            }

            return salida;
        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult salida;
            int columnasBorradas;
            try
            {
                columnasBorradas = clsManejadoraBL.deletePersonaBL(id);
                if (columnasBorradas == 0)
                {
                    salida = NotFound();
                }
                else
                {
                    salida = Ok();
                }
            }
            catch (Exception e)
            {
                salida = BadRequest();
            }

            return salida;

        }

    }
}
