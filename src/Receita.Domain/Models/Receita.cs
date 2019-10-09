namespace Receita.Domain.Models
{
    public class Receita
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdCategoria { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Ingredientes { get; set; }
        public string ModoDePreparo { get; set; }
        public string Foto { get; set; }
        public string Tag { get; set; }
        public bool Status { get; set; }
    }
}
