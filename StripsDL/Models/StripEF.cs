using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsDL.Models;
public class StripEF
{
    public StripEF()
    {

    }
    public StripEF(string titel, int reeksNummer)
    {
        Titel = titel;
        ReeksNummer = reeksNummer;
    }
    public StripEF(string titel, List<AuteurEF> auteurs, UitgeverijEF uitgeverij, ReeksEF reeks, int reeksNummer)
    {
        Titel = titel;
        Auteurs = auteurs;
        Uitgeverij = uitgeverij;
        Reeks = reeks;
        ReeksNummer = reeksNummer;
    }

    public int Id { get; set; }
    [Required]
    public string Titel { get; set; }
    [Required]
    public ICollection<AuteurEF> Auteurs { get; set; } = new List<AuteurEF>();
    [Required]
    public UitgeverijEF Uitgeverij { get; set; }
    public ReeksEF Reeks { get; set; }
    public int? ReeksNummer { get; set; }
}
