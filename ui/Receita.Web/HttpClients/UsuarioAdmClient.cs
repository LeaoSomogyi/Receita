using Microsoft.AspNetCore.Mvc.Rendering;
using Receita.Web.HttpClients.Interfaces;
using Receita.Web.Util;
using Receita.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Receita.Web.HttpClients
{
    public class UsuarioAdmClient : IUsuarioAdmClient
    {
        private readonly HttpClient _httpClient;

        public UsuarioAdmClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<UsuarioAdmViewModel>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("api/usuarios");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadAsJsonAsync<IEnumerable<UsuarioAdmViewModel>>();
            }

            return new List<UsuarioAdmViewModel>();
        }

        public async Task<IEnumerable<SelectListItem>> GetAllToViewAsync() 
        {
            var usuarios = await GetAllAsync();

            return usuarios.Select(u => new SelectListItem() 
            {
                Text = u.Nome,
                Value = u.Id.ToString()
            });
        }
    }
}
