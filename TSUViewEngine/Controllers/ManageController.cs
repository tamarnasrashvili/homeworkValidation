using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TSUViewEngine.Models;
using static TSUViewEngine.Models.MovieRepository;

namespace TSUViewEngine.Controllers
{
	public class ManageController : Controller
	{
		private readonly IMovieRepository _movieRepository;
		private const string MovieFormPartialView = "~/Views/Manage/MovieForm.cshtml";

		public ManageController(IMovieRepository movieRepository)
		{
			_movieRepository = movieRepository;
		}

		public IActionResult Movie()
		{
			return View(GetMovieModel());
		}

        #region CreateMovie
        public IActionResult CreateMovie()
		{
			return PartialView(MovieFormPartialView, new Movie());
		}

		[HttpPost]
		public IActionResult CreateMovie(Movie movie)
		{
			_movieRepository.Create(movie);
			return PartialView("~/Views/Manage/TableRows.cshtml", GetMovieModel());
		}
        #endregion

        #region EditMovie
        public IActionResult EditMovie(int id)
		{
			Movie movie = new Movie();
			if(id > 0)
			{
				movie = _movieRepository.GetMovieById(id);
			}
			return PartialView(MovieFormPartialView, movie);
		}
		[HttpPost]
		public IActionResult EditMovie(Movie movie)
		{
			_movieRepository.Edit(movie);
			return PartialView("~/Views/Manage/TableRows.cshtml", GetMovieModel());
		}
		#endregion


		private MovieVM GetMovieModel()
		{
			MovieVM model = new MovieVM();
			model.Movies = _movieRepository.Movies(string.Empty);
			return model;
		}
    }
}