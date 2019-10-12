using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Receita.Web.Controllers
{
    public class PapelController : Controller
    {
        // GET: Papel
        public ActionResult Index()
        {
            return View();
        }

        // GET: Papel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Papel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Papel/Create
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

        // GET: Papel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Papel/Edit/5
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

        // GET: Papel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Papel/Delete/5
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