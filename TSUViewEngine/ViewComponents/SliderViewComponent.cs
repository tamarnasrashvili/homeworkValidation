using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static TSUViewEngine.Models.MovieRepository;

namespace TSUViewEngine.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {

        private readonly IMovieRepository movieRepository;
        public SliderViewComponent(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }
        public IViewComponentResult Invoke()
        {
            var model = movieRepository.SliderMovies();
            return View(model);
        }
    }
}
