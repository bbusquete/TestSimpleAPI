using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IPortifolioRepository : IRepositoryBase<Investiment>
    {
        IList<Investiment> GetAll();
        Investiment GetById(int id);
        IList<Investiment> GetBySymbol(string symbol);
        void Add(Investiment investiment);
        void Update(int id, Investiment investiment);
        void Delete(int id);
    }
}
