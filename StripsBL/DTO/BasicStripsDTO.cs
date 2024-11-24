using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsBL.DTO
{
    public class BasicStripsDTO
    {
        public BasicStripsDTO(int nr, string titel, string url)
        {
            Nr = nr;
            Titel = titel;
            Url = url;
        }

        public int Nr { get; set; }
        public string Titel { get; set; }
        public string Url { get; set; }
    }

}
