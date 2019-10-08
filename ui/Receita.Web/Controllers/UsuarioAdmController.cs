using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Receita.Web.Controllers
{
    public class UsuarioAdmController : Controller
    {
        // GET: UsuarioAdm
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsuarioAdm/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioAdm/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioAdm/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioAdm/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioAdm/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioAdm/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioAdm/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}