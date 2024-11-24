using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsBL.DTO;

public class AuteurDTO
{
    public AuteurDTO(string auteur, string url)
    {
        Auteur = auteur;
        Url = url;
    }

    public string Auteur { get; set; }
    public string Url { get; set; }
}
