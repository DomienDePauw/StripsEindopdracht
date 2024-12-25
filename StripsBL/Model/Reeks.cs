using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsBL.Model;
public class Reeks
{
    public int Id { get; set; }
    public string Naam { get; set; }
    public List<Strip> Strips { get; set; } = new List<Strip>();
}
