using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;

namespace Infrastructure.Models
{
    [TableName("Users")]
    [PrimaryKey("Id")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        //public static explicit operator Investiment(global::Domain.Entities.Investiment v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
