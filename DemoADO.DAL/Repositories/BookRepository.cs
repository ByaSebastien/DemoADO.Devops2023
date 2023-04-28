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

        private void GenerateParameter(IDbCommand command, string name, object value)
        {
            IDataParameter parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value ?? DBNull.Value;
            command.Parameters.Add(parameter);
        }

        private Book Convert(IDataRecord dataRecord)
        {
            return new Book()
            {
                Isbn = (string)dataRecord["isbn"],
                Title = (string)dataRecord["Title"],
                Author = (string)dataRecord["Author"],
                Description = dataRecord["Description"] == DBNull.Value ? null : (string)dataRecord["Description"],
                Category = (string)dataRecord["Category"],
            };
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
                        Book book = Convert(reader);
                        books.Add(book);

                        // Return avec yield return

                        //yield Convert(reader);
                    }
                }
                _connection.Close();
                return books;
            }
        }

        public Book GetOne(string isbn)
        {
            using (IDbCommand command = _connection.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM BOOK WHERE ISBN = @isbn";

                GenerateParameter(command, "@isbn", isbn);

                OpenConnection();

                Book book;

                using(IDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        book = Convert(reader);
                    }
                    else
                    {
                        throw new KeyNotFoundException();
                    }
                }
                _connection.Close();
                return book;
            }
        }
    }
}
