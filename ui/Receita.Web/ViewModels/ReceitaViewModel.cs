using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;

namespace Receita.Web.ViewModels
{
    public class ReceitaViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Usuário")]
        public int IdUsuario { get; set; }

        [Display(Name = "Categoria")]
        public int IdCategoria { get; set; }

        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public string Ingredientes { get; set; }

        [Display(Name = "Modo De Preparo")]
        public string ModoDePreparo { get; set; }

        public string Foto { get; set; }

        [Display(Name = "Foto")]
        public IFormFile FotoUpload { get; set; }

        public string Tag { get; set; }

        public bool Status { get; set; }

        public async Task<ReceitaViewModel> ConverterArquivoParaBase64() 
        {
            if (FotoUpload != null)
            {
                using (var ms = new MemoryStream()) 
                {
                    await FotoUpload.CopyToAsync(ms);

                    var fotoBytes = ms.ToArray();

                    Foto = Convert.ToBase64String(fotoBytes);
                }
            }

            return this;
        }

        public ReceitaViewModel() { }
    }
}
