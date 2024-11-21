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
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
