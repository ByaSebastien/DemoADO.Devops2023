using DemoADO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoADO.DAL.Repositories
{
    public abstract class BaseRepository<TKey, TEntity> : IBaseRepository<TKey, TEntity> where TEntity : class
    {
        private readonly string _connectionString = "Server=DESKTOP-EHN422D;Database=DemoADO;Trusted_Connection=true;";
        protected readonly IDbConnection _connection;
        private readonly string _columnIdName;
        private readonly string _tableName;

        public BaseRepository(string columnIdName,string tablename)
        {
            _connection = new SqlConnection(_connectionString);
            _columnIdName = columnIdName;
            _tableName = tablename;
        }

        protected void GenerateParameter(IDbCommand command, string name, object? value)
        {
            IDataParameter parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value ?? DBNull.Value;
            command.Parameters.Add(parameter);
        }

        protected abstract TEntity Convert(IDataRecord dataRecord);

        protected void OpenConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
            _connection.Open();
        }



        public TEntity GetOne(TKey id)
        {
            using (IDbCommand command = _connection.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM {_tableName} WHERE {_columnIdName} = @id";

                GenerateParameter(command, "@id", id);

                OpenConnection();

                TEntity entity;

                using (IDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        entity = Convert(reader);
                    }
                    else
                    {
                        throw new KeyNotFoundException();
                    }
                }
                _connection.Close();
                return entity;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            using (IDbCommand command = _connection.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM {_tableName}";

                OpenConnection();

                List<TEntity> entities = new List<TEntity>();

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TEntity entity = Convert(reader);
                        entities.Add(entity);

                        // Return avec yield return

                        //yield Convert(reader);
                    }
                }
                _connection.Close();
                return entities;
            }
        }


        public abstract bool Insert(TEntity entity);

        public abstract bool Update(TKey id, TEntity entity);

        public bool Delete(TKey id)
        {
            using (IDbCommand command = _connection.CreateCommand())
            {
                command.CommandText = $"DELETE FROM {_tableName} " +
                                      $"WHERE {_columnIdName} = @id";
                GenerateParameter(command, "@id", id);

                OpenConnection();
                int nbRow = command.ExecuteNonQuery();
                _connection.Close();
                return nbRow == 1;
            }
        }
    }
}
