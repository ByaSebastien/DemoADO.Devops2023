using DemoADO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoADO.DAL.Repositories
{
    public class BookRepository
    {
        private readonly string _connectionString = "Server=DESKTOP-EHN422D;Database=DemoADO;Trusted_Connection=true;";
        private readonly IDbConnection _connection;

        public BookRepository()
        {
            _connection = new SqlConnection(_connectionString);
        }

        public IEnumerable<Book> GetAll()
        {
            using (IDbCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM BOOK";

                _connection.Open();

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                    }
                }
            }
        }
    }
}
