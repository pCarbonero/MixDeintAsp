using BL;
using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace CrudAsp.Controllers
{
    public class PersonaController : Controller
    {
        // GET: PersonaController
        public ActionResult Index()
        {
            List<clsPersona> listado = new List<clsPersona>();
            try
            {
                listado = clsListadosBL.listadoCompletoPersonasBL();
            }
            catch (Exception ex) 
            {
                return View("Error");
            }
            return View(listado);
        }

        // GET: PersonaController/Details/5
        public ActionResult Details(int id)
        {
            clsPersona persona = new clsPersona();
            try
            {
                persona = clsListadosBL.getPersonaIdBL(id);
            }
            catch (Exception e)
            {
                return View("Error");
            }

            return View(persona);
        }

        // GET: PersonaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(clsPersona personaInsertar)
        {
            try
            {
                clsManejadoraBL.insertPersonaBL(personaInsertar);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: PersonaController/Edit/5
        public ActionResult Edit(int id)
        {
            clsPersona personaEditar = new clsPersona();
            try
            {
                personaEditar = clsListadosBL.getPersonaIdBL(id);
            }
            catch (Exception e)
            {
                return View("Error");
            }
            return View(personaEditar);
        }

        // POST: PersonaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(clsPersona persona)
        {
            try
            {
                clsManejadoraBL.updatePersonaBL(persona);
            }
            catch
            {
                return View("Error");
            }
            return View(persona);
        }

        // GET: PersonaController/Delete/5
        public ActionResult Delete(int id)
        {
            clsPersona personaBorrar = new clsPersona();
            try
            {
                personaBorrar = clsListadosBL.getPersonaIdBL(id);
            }
            catch(Exception e)
            {
                return View("Error");
            }
            return View(personaBorrar);
        }

        // POST: PersonaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            try
            {
                int filasAfectadas = clsManejadoraBL.deletePersonaBL(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e) 
            {
                return View("Error");
            }
        }
    }
}
