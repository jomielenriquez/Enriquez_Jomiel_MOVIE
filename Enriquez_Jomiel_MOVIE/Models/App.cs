using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Enriquez_Jomiel_MOVIE.Models
{
    public class App
    {
        public IEnumerable<TBL_MOVIES> MovieList { get; set; }
        public TBL_MOVIES SelectedMovie { get; set; }
        public IEnumerable<TBL_CATEGORIES> CategoryList { get; set; }
        public List<string> AreChecked { get; set; }
        public string ErrorMessage { get; set; }
    }
}