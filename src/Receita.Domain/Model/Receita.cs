using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Receita.Domain.Model
{
    public class Receita
    {
        public int idReceita { get; set; }
        public int IdUsuario { get; set; }
        public int IdCategoria { get; set; }
        public string TituloReceita { get; set; }
        public string Descricao { get; set; }

        public string Ingredientes { get; set; }

        public string ModoDePreparo { get; set; }

        public string Foto { get; set; }

        public string Tag { get; set; }

        public bool Status { get; set; }

   




    }
}
