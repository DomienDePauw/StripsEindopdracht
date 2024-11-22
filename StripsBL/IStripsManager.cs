using StripsDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsBL
{
    public interface IStripsManager
    {
        Strip GetStripById(int id);
    }
}
