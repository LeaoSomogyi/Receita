using Receita.Web.HttpClients.Interfaces;
using Receita.Web.Util;
using Receita.Web.ViewModels;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Receita.Web.HttpClients
{
    public class ReceitaClient : IReceitaClient
    {
        private readonly HttpClient _httpClient;

        public ReceitaClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ReceitaViewModel>> GetReceitasAsync()
        {
            var response = await _httpClient.GetAsync("api/receitas");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadAsJsonAsync<IEnumerable<ReceitaViewModel>>();
            }

            return new List<ReceitaViewModel>();
        }
    }
}
