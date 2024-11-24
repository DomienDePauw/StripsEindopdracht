using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsBL.DTO;

public class ReeksDTO
{
    public string Naam { get; set; }
    public string Url { get; set; }
    public List<BasicStripsDTO> Strips { get; set; }
}
