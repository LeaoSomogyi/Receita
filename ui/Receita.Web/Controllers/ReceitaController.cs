using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Receita.Web.HttpClients.Interfaces;
using System.Threading.Tasks;

namespace Receita.Web.Controllers
{
    public class ReceitaController : Controller
    {
        private readonly IReceitaClient _receitaClient;

        public ReceitaController(IReceitaClient receitaClient)
        {
            _receitaClient = receitaClient;
        }

        // GET: Receita
        public async Task<IActionResult> Index()
        {
            var receitas = await _receitaClient.GetReceitasAsync();

            return View(receitas);
        }

        // Get: Receita/PorCategoria/5
        public async Task<IActionResult> PorCategoria(int id)
        {
            var receitas = await _receitaClient.GetPorCategoriaAsync(id);

            return View("Index", receitas);
        }

        // GET: Receita/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: Receita/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Receita/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
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

        // GET: Receita/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: Receita/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
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

        // GET: Receita/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: Receita/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
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