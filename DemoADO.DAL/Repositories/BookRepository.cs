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
    public class BookRepository : BaseRepository<string,Book>, IBookRepository
    {

        public BookRepository() :base("ISBN","BOOK") { } 

        protected override Book Convert(IDataRecord dataRecord)
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


        public override bool Insert(Book book)
        {
            using(IDbCommand command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO BOOK(ISBN, TITLE, AUTHOR, DESCRIPTION, CATEGORY)" +
                                      "VALUES (@isbn, @title, @author, @description, @category)";
                GenerateParameter(command, "@isbn", book.Isbn);
                GenerateParameter(command, "@title", book.Title);
                GenerateParameter(command, "@author", book.Author);
                GenerateParameter(command, "@description", book.Description);
                GenerateParameter(command, "@category", book.Category);

                OpenConnection();
                int nbRow = command.ExecuteNonQuery();
                _connection.Close();
                return nbRow == 1;
            }
        }

        public override bool Update(string isbn,Book book)
        {
            using (IDbCommand command = _connection.CreateCommand())
            {
                command.CommandText = "UPDATE BOOK " +
                                      "SET TITLE = @title," +
                                          "AUTHOR = @author," +
                                          "DESCRIPTION = @description," +
                                          "CATEGORY = @category" +
                                      "WHERE ISBN = @isbn";
                GenerateParameter(command, "@isbn", isbn);
                GenerateParameter(command, "@title", book.Title);
                GenerateParameter(command, "@author", book.Author);
                GenerateParameter(command, "@description", book.Description);
                GenerateParameter(command, "@category", book.Category);

                OpenConnection();
                int nbRow = command.ExecuteNonQuery();
                _connection.Close();
                return nbRow == 1;
            }
        }
    }
}
