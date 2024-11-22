using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StripsDL;
using StripsDL.Models;

namespace StripsBL
{
    public class StripsRepository
    {
        private readonly StripsContext _context;

        public StripsRepository(StripsContext context)
        {
            _context = context;
        }
        public Strip GetById(int id)
        {
            return _context.Strips
                           .Include(s => s.Auteurs)
                           .Include(s => s.Uitgeverij)
                           .Include(s => s.Reeks)
                           .FirstOrDefault(s => s.Id == id);
        }
    }
}
