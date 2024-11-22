using StripsDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsBL
{
    public interface IStripsRepository
    {
        //Methodes die nodig zijn voor de databankoperaties
        Strip GetById(int id);
    }
}

