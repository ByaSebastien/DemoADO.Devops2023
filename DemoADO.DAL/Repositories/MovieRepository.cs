using DemoADO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoADO.DAL.Repositories
{
    public class MovieRepository : BaseRepository<int, Movie>, IMovieRepository
    {
        public MovieRepository() : base("Id", "MOVIE")
        {
        }

        public override bool Insert(Movie entity)
        {
            throw new NotImplementedException();
        }

        public override bool Update(int id, Movie entity)
        {
            throw new NotImplementedException();
        }

        protected override Movie Convert(IDataRecord dataRecord)
        {
            throw new NotImplementedException();
        }
    }
}
