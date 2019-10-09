namespace Receita.Domain.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        private Status status;

        public Status GetStatus()
        {
            return status;
        }

        public void SetStatus(Status value)
        {
            status = value;
        }

        public int IdGrupo { get; set; }
    }
}
