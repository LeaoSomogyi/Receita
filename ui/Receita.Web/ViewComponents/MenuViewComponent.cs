using Microsoft.AspNetCore.Mvc;
using Receita.Web.HttpClients.Interfaces;
using System.Threading.Tasks;

namespace Receita.Web.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly ICategoriaClient _categoriaClient;

        public MenuViewComponent(ICategoriaClient categoriaClient)
        {
            _categoriaClient = categoriaClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categorias = await _categoriaClient.GetCategoriasAsync();

            return View(categorias);
        }
    }
}
