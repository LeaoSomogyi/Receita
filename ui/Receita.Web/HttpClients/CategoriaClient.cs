using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using Receita.Web.HttpClients.Interfaces;
using Receita.Web.Util;
using Receita.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Receita.Web.HttpClients
{
    public class CategoriaClient : ICategoriaClient
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _memoryCache;

        public CategoriaClient(HttpClient httpClient, IMemoryCache memoryCache)
        {
            _httpClient = httpClient;
            _memoryCache = memoryCache;
        }

        public async Task<IEnumerable<CategoriaViewModel>> GetCategoriasAsync()
        {
            var cacheName = "categorias";

            if (!_memoryCache.TryGetValue(cacheName, out List<CategoriaViewModel> categorias))
            {
                var cacheOptions = new MemoryCacheEntryOptions()
                {
                    AbsoluteExpiration = DateTime.Now.AddHours(1)
                };

                var response = await _httpClient.GetAsync("api/categorias");

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    categorias = await response.Content.ReadAsJsonAsync<List<CategoriaViewModel>>();
                }

                _memoryCache.Set(cacheName, categorias, cacheOptions);
            }

            return categorias;
        }

        public async Task<IEnumerable<SelectListItem>> GetCategoriasToViewAsync()
        {
            var categorias = await GetCategoriasAsync();

            return categorias.Select(c => new SelectListItem() 
            {
                Text = c.Titulo,
                Value = c.Id.ToString()
            });
        }
    }
}
