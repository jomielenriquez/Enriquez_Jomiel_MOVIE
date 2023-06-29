using Enriquez_Jomiel_MOVIE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Enriquez_Jomiel_MOVIE.Repository
{
    public class CategoryRepository
    {
        public static IEnumerable<TBL_CATEGORIES> GetAllCategories()
        {
            MOVIEDBEntities entities = new MOVIEDBEntities();
            var categories = from entCategories in entities.TBL_CATEGORIES select entCategories;
            return (IEnumerable<TBL_CATEGORIES>)categories;
        }
    }
}