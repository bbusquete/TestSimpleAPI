using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class Portifolio
    {
        public User User { get; set; }
        public List<Investiment> Investiments { get; set; }


    }
}
