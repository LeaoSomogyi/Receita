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

        public async Task<IEnumerable<ReceitaViewModel>> GetPorCategoriaAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/receitas/categoria/{id}");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadAsJsonAsync<IEnumerable<ReceitaViewModel>>();
            }

            return new List<ReceitaViewModel>();
        }

        public async Task<ReceitaViewModel> GetPorIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/receitas/{id}");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadAsJsonAsync<ReceitaViewModel>();
            }

            return new ReceitaViewModel();
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

        public async Task<bool> DeleteAsync(int id) 
        {
            var response = await _httpClient.DeleteAsync($"api/receitas/{id}");

            return response.StatusCode == HttpStatusCode.OK;
        }

        public async Task<bool> SalvarAsync(ReceitaViewModel receita) 
        {
            var response = await _httpClient.PostAsync("api/receitas", receita.SerializeAsJson());

            return response.StatusCode == HttpStatusCode.Created;
        }
    }
}
