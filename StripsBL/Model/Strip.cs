using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsBL.Model;
public class Strip
{
    public int Id { get; set; }
    public string Titel { get; set; }
    public Reeks Reeks { get; set; }
    public int ReeksNummer { get; set; }
    public Uitgeverij Uitgeverij { get; set; }
    public List<Auteur> Auteurs { get; set; }

}
