using Infrastructure.Models;
using NPoco;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco.SqlServer;

namespace Infrastructure.Repositories
{
    public class PortifolioRepository :  IPortifolioRepository
    {
        private readonly IDbFactory _dbFactory;

        public PortifolioRepository(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public void Add(Investiment investiment)
        {
            using(var db = _dbFactory.GetConnection())
            {
                db.Insert<Investiment>(investiment);
            }
            
        }

        public void Delete(int id)
        {
            using (var db = _dbFactory.GetConnection())
            {
                db.Delete<Investiment>(id);
            }
        }

        public IList<Investiment> GetAll()
        {
            IList<Investiment> list;
            using (var db = _dbFactory.GetConnection())
            {
                //string query = "SELECT * FROM Investiments";
                list = db.Fetch<Investiment>();
            }
            return list.ToList();
        }


        public IList<Investiment> GetBySymbol(string symbol)
        {
            //string query = String.Format("SELECT * FROM Investiments where Symbol = {0}", Symbol);
            IList<Investiment> list;
            using (var db = _dbFactory.GetConnection())
            {
             list = db.Fetch<Investiment>().Where(i => i.Symbol == symbol).ToList();
            }
            return list.ToList();
        }

        public Investiment GetById(int id)
        {
            Investiment investiment;
            using (var db = _dbFactory.GetConnection())
            {
                investiment = db.SingleById<Investiment>(id);
            }

            return investiment;
        }

        public void Update(int id, Investiment investiment)
        {
            investiment.Id = id;
            using (var db = _dbFactory.GetConnection())
            {
                db.Update(investiment);
            }
        }

       
    }
}
