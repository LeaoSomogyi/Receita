using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Receita.Web.HttpClients.Interfaces;

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
        public async Task<ActionResult> Index()
        {
            var receitas = await _receitaClient.GetReceitasAsync();

            return View(receitas);
        }

        // GET: Receita/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Receita/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Receita/Create
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

        // GET: Receita/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Receita/Edit/5
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

        // GET: Receita/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Receita/Delete/5
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