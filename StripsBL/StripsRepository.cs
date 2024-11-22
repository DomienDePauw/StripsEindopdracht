using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StripsDL;
using StripsDL.Models;

namespace StripsBL
{
    public class StripsRepository : IStripsRepository
    {
        private readonly StripsContext _context;

        public StripsRepository(StripsContext context)
        {
            _context = context;
        }
        public Strip GetById(int id) 
        {
            return _context.Strips.FirstOrDefault(s => s.Id == id); 
        }
    }
}
