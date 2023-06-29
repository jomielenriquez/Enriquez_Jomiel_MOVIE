using Enriquez_Jomiel_MOVIE.Models;
using Enriquez_Jomiel_MOVIE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Enriquez_Jomiel_MOVIE.Controllers
{
    public class MoviesController : Controller
    {
        static string ErrorMessage = string.Empty;
        static TBL_MOVIES holdMovies = new TBL_MOVIES();
        // GET: Movies
        public ActionResult ListScreen()
        {
            App app = new App();
            app.MovieList = MoviesRepository.GetAllMovies();

            return View(app);
        }

        public ActionResult EditScreen(Guid? MovieID)
        {
            App app = new App();
            app.CategoryList = CategoryRepository.GetAllCategories();

            if (MovieID == null)
            {
                ViewBag.EditScreenHeader = "Add Movie";
                //new
                app.SelectedMovie = null;
            }
            else
            {
                ViewBag.EditScreenHeader = "Edit Movie";
                //Update
                app.SelectedMovie = MoviesRepository.GetMovie(MovieID);
            }
            
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                app.ErrorMessage = ErrorMessage;
                app.SelectedMovie = holdMovies;
            }

            return View(app);
        }

        [HttpPost]
        public ActionResult Update(TBL_MOVIES SelectedMovie)
        {
            var result = string.Empty;
            Data data = new Data();
            if (SelectedMovie.MOVIEID == new Guid())
            {
                result = data.Save(SelectedMovie, new List<string> { "MOVIEID" }, "MOVIEID");
            }
            else
            {
                //Update
                TBL_MOVIES Movies = SelectedMovie;
                TBL_MOVIES filter = new TBL_MOVIES();
                filter.MOVIEID = Movies.MOVIEID;
                Movies.MOVIEID = new Guid();
                result = data.Update(Movies, filter);
            }
            if (result != "Success")
            {
                Guid x;
                if (!Guid.TryParse(result, out x)) // check if return value is not UID
                {
                    ErrorMessage = result;
                    holdMovies = SelectedMovie as TBL_MOVIES;
                    return Redirect(Request.UrlReferrer.ToString());
                }
            }
            ErrorMessage = string.Empty;
            holdMovies = new TBL_MOVIES();
            return RedirectToAction("ListScreen");
        }
        [HttpPost]
        public ActionResult Delete(App app)
        {
            Data data = new Data();
            string message = data.Delete(new TBL_MOVIES(), app.AreChecked, "MOVIEID");

            return RedirectToAction("ListScreen");
        }
    }
}