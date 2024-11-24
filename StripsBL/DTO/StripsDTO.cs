using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsBL.DTO;

public class StripsDTO
{
    public StripsDTO(string url, string titel, int? nr, string reeks, string reeksUrl, string uitgeverij, string uitgeverijUrl, List<AuteurDTO> auteurs)
    {
        Url = url;
        Titel = titel;
        Nr = nr;
        Reeks = reeks;
        ReeksUrl = reeksUrl;
        Uitgeverij = uitgeverij;
        UitgeverijUrl = uitgeverijUrl;
        Auteurs = auteurs;
    }

    public string Url { get; set; }
    public string Titel { get; set; }
    public int? Nr { get; set; }
    public string Reeks { get; set; }
    public string ReeksUrl { get; set; }
    public string Uitgeverij { get; set; }
    public string UitgeverijUrl { get; set; }
    public List<AuteurDTO> Auteurs { get; set; }
}
