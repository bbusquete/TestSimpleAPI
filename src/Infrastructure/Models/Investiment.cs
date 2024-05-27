using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;

namespace Infrastructure.Models
{
    [TableName("Investiments")]
    [PrimaryKey("Id")]
    public class Investiment
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string Symbol { get; set; }
        public decimal Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }

        //public static explicit operator Investiment(global::Domain.Entities.Investiment v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
