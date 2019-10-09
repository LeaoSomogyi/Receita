using System.ComponentModel.DataAnnotations;

namespace Receita.Web.ViewModels
{
    public class ReceitaViewModel
    {
        public int Id { get; set; }

        public int IdUsuario { get; set; }

        public int IdCategoria { get; set; }

        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public string Ingredientes { get; set; }

        [Display(Name = "Modo De Preparo")]
        public string ModoDePreparo { get; set; }

        public string FotoBase64 { get; set; }

        public string Tag { get; set; }

        public bool Status { get; set; }

        public ReceitaViewModel() { }
    }
}
