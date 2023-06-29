using Enriquez_Jomiel_MOVIE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Enriquez_Jomiel_MOVIE.Repository
{
    public class MoviesRepository
    {
        public static IEnumerable<TBL_MOVIES> GetAllMovies()
        {
            MOVIEDBEntities entities = new MOVIEDBEntities();
            var movies = from entMovies in entities.TBL_MOVIES select entMovies;
            return (IEnumerable<TBL_MOVIES>)movies;
        }

        public static TBL_MOVIES GetMovie(Guid? MovieID)
        {
            MOVIEDBEntities entities = new MOVIEDBEntities();
            var movie = (from entMovies in entities.TBL_MOVIES.Where(m => m.MOVIEID == MovieID) select entMovies).FirstOrDefault();
            return (TBL_MOVIES)movie;
        }
    }
}