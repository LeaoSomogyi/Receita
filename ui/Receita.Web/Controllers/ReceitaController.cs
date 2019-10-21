using Microsoft.AspNetCore.Mvc;
using Receita.Web.HttpClients.Interfaces;
using Receita.Web.ViewModels;
using System.Threading.Tasks;

namespace Receita.Web.Controllers
{
    public class ReceitaController : Controller
    {
        private readonly IReceitaClient _receitaClient;
        private readonly ICategoriaClient _categoriaClient;
        private readonly IUsuarioAdmClient _usuarioAdmClient;

        public ReceitaController(IReceitaClient receitaClient, 
            ICategoriaClient categoriaClient,
            IUsuarioAdmClient usuarioAdmClient)
        {
            _receitaClient = receitaClient;
            _categoriaClient = categoriaClient;
            _usuarioAdmClient = usuarioAdmClient;
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
        public async Task<IActionResult> Details(int id)
        {
            var receita = await _receitaClient.GetPorIdAsync(id);

            return View(receita);
        }

        // GET: Receita/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Categorias = await _categoriaClient.GetCategoriasToViewAsync();
            ViewBag.Usuarios = await _usuarioAdmClient.GetAllToViewAsync();

            return View();
        }

        // POST: Receita/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReceitaViewModel receitaViewModel)
        {
            try
            {
                var receita = await receitaViewModel.ConverterArquivoParaBase64();

                await _receitaClient.SalvarAsync(receita);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Receita/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var receita = await _receitaClient.GetPorIdAsync(id);

            return View("Create", receita);
        }

        // GET: Receita/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _receitaClient.DeleteAsync(id);

            if (response)
                TempData["msg"] = "Receita removida com sucesso!";
            else
                TempData["erro"] = "Problemas ao remover receita";

            TempData.Keep();

            return RedirectToAction(nameof(List));
        }

        public async Task<IActionResult> List()
        {
            var receitas = await _receitaClient.GetReceitasAsync();

            return View(receitas);
        }
    }
}