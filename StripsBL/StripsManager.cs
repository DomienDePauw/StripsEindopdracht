using StripsDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsBL
{
    public class StripsManager : IStripsManager
    {
        private readonly IStripsRepository _repository;

        public StripsManager(IStripsRepository repository)
        {
            _repository = repository;
        }
        public Strip GetStripById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
