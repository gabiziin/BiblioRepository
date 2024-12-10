using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.DTO
{
    public class LivroDTO
    {
        public int IdLivro { get; set; }
        public string TituloLivro { get; set; }
        public string EditoraLivro { get; set; }
        public string AutorLivro { get; set; }
        public DateTime DtPubli { get; set; }
        public string SinopseLivro { get; set; }
        public string UrlLivro { get; set; }
        public string UrlPDF { get; set; }
        public string GeneroId { get; set; }
    }
}
