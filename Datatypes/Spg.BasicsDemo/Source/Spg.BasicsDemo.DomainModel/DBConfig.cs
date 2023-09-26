using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.BasicsDemo.DomainModel
{
    public class DBConfig
    {
        private string _connectionString;

        public DBConfig() 
        {
            _connectionString = "Data Source = 123.123.123.123/instance Catalog:Mydatabase User Id=martin pwd=geheim!";
        }

        public void ConnectToDb()
        {
            // DB Connection Stuff by using Connection String
        }
    }
}
