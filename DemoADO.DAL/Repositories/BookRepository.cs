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
    public class BookRepository : IBookRepository
    {
        private readonly string _connectionString = "Server=DESKTOP-EHN422D;Database=DemoADO;Trusted_Connection=true;";
        private readonly IDbConnection _connection;

        public BookRepository()
        {
            _connection = new SqlConnection(_connectionString);
        }

        private void OpenConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
            _connection.Open();
        }

        public IEnumerable<Book> GetAll()
        {
            using (IDbCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM BOOK";

                OpenConnection();

                List<Book> books = new List<Book>();

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Book book = new Book()
                        {
                            Isbn = (string)reader["isbn"],
                            Title = (string)reader["Title"],
                            Author = (string)reader["Author"],
                            Description = reader["Description"] == DBNull.Value ? null : (string)reader["Description"],
                            Category = (string)reader["Category"],
                        };
                        books.Add(book);

                        // Return avec yield return

                        //yield return new Book()
                        //{
                        //    Isbn = (string)reader["isbn"],
                        //    Title = (string)reader["Title"],
                        //    Author = (string)reader["Author"],
                        //    Description = reader["Description"] == DBNull.Value ? null : (string)reader["Description"],
                        //    Category = (string)reader["Category"],
                        //};
                    }
                }
                _connection.Close();
                return books;
            }
        }
    }
}
