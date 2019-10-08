namespace Receita.Domain.Model
{
    public class UsuarioAdm
    {
        public int IdUsuarioAdm { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public Status status { get; set; }
        public int IdPapel { get; set; }
    }
}
