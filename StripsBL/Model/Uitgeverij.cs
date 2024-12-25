using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsBL.Model;
public class Uitgeverij
{
    public int Id { get; set; }
    public string Naam { get; set; }
    public string Adres { get; set; }
    public List<Strip> Strips { get; set; }
}
