using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Receita.Domain.Model;
using Receita.Web.Util;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Receita.Web.Controllers
{
    public class CategoriaController : Controller
    {
        HttpClient catego;
        Uri categoriUri;

        public CategoriaController()
        {
            catego = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44338/")
            };
        }

        // GET: Categoria
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await catego.GetAsync("api/Categoria");
            List<Categoria> categoria = await response.Content.ReadAsJsonAsync<List<Categoria>>();

            if (response.IsSuccessStatusCode)
            {
                categoriUri = response.Headers.Location;
                var cat = await response.Content.ReadAsAsync<List<Categoria>>();
                return Ok(cat);
            }
            return View();
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
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

        // GET: Categoria/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Categoria/Edit/5
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

        // GET: Categoria/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Categoria/Delete/5
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