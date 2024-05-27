using Domain.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Infrastructure.Models;

namespace Application.Behaviors
{
    public class PortifolioService
    {
        private IPortifolioRepository _repository;

        public PortifolioService(IPortifolioRepository portifolioRepository)
        {
            _repository = portifolioRepository;
        }

        public bool AddInvestiment(Domain.Entities.Investiment investiment) 
        {
            bool result = true;
            try
            {
                _repository.Add(ConvertToInfraModel(investiment));
            }
            catch (Exception)
            {
                throw;
                result = false;
            }
             
            return result;
        }

        public List<Domain.Entities.Investiment> ListAllInvestiments()
        {
            var listDomain = new List<Domain.Entities.Investiment>();

            try
            {
                var list = _repository.GetAll();
                
                foreach (var item in list)
                {
                    listDomain.Add(ConvertToModel(item));
                }
            }
            catch (Exception)
            {
                throw;
            }
            
            return listDomain;
        }

        public bool UpdateInvestiment(int id, Domain.Entities.Investiment investiment)
        {
            bool result = true;
            try
            {
                _repository.Update(id, ConvertToInfraModel(investiment));
            }
            catch (Exception)
            {
                throw;
                result = false;
            }

            return result;
        }

        public Domain.Entities.Investiment GetInvestimentsBySymbol(string symbol)
        {
            var AllInvestimentsBySymbol = _repository.GetBySymbol(symbol);
            Domain.Entities.Investiment investiment = new Domain.Entities.Investiment();

            if (AllInvestimentsBySymbol != null && AllInvestimentsBySymbol.Count > 0)
            {
                investiment.Symbol = symbol;
                
                foreach (var item in AllInvestimentsBySymbol)
                {
                    investiment.Quantity += item.Quantity;
                    investiment.IdUser = item.IdUser;

                    if (investiment.PurchasePrice == null || investiment.PurchasePrice == 0)
                        investiment.PurchasePrice = item.PurchasePrice;
                    else
                        investiment.PurchasePrice = (investiment.PurchasePrice + item.PurchasePrice)/2;

                    if (investiment.PurchaseDate == null)
                        investiment.PurchaseDate = item.PurchaseDate;
                    else
                        if (investiment.PurchaseDate < item.PurchaseDate)
                        investiment.PurchaseDate = item.PurchaseDate;
                }
            }
            return investiment;
        }

        public void SellInvestiment(int id)
        {
            _repository.Delete(id);
        }


        public Infrastructure.Models.Investiment ConvertToInfraModel(Domain.Entities.Investiment i)
        {
            return new Infrastructure.Models.Investiment()
            {
                IdUser = i.IdUser,
                Symbol = i.Symbol,
                Quantity = i.Quantity,
                PurchaseDate = i.PurchaseDate,
                PurchasePrice = i.PurchasePrice
            };
        }

        public Domain.Entities.Investiment ConvertToModel(Infrastructure.Models.Investiment i)
        {
            return new Domain.Entities.Investiment()
            {
                IdUser = i.IdUser,
                Symbol = i.Symbol,
                Quantity = i.Quantity,
                PurchaseDate = i.PurchaseDate,
                PurchasePrice = i.PurchasePrice
            };
        }

    }
}
