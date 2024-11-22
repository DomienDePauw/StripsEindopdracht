using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsBL
{
    public class StripsDTO
    {
        public string Url { get; set; }
        public string Titel { get; set; }
        public int? Nr { get; set; }
        public string Reeks { get; set; }
        public string ReeksUrl { get; set; }
        public string Uitgeverij { get; set; }
        public string UitgeverijUrl { get; set; }
        public List<AuteurDTO> Auteurs { get; set; }
    }

    public class AuteurDTO
    {
        public string Auteur { get; set; }
        public string Url { get; set; }
    }

}
