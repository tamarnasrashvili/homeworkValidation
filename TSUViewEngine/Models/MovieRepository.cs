using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSUViewEngine.Models
{
    public class MovieRepository
    {
        public interface IMovieRepository
        {
            IEnumerable<Movie> Movies(string searchTitle);
            void Create(Movie movie);
            void Edit(Movie movie);
            Movie GetMovieById(int id);
            IEnumerable<Movie> SliderMovies();
        }


        public class MoviRepository : IMovieRepository
        {
            private List<Movie> Data = new List<Movie>()
            {
                new Movie(1,"https://static.imovies.cc/movies/covers/510/810/878455810-1143c333ad1fe5518a337aa6a8037fa7.jpg","დახსნა"),
                new Movie(2,"https://static.imovies.cc/movies/covers/510/276/878369276-9fd3b3ece2f8bc926ab4f55e626d5d34.jpg","შურისმაძიებლები"),
                new Movie(3,"https://static.imovies.cc/m_posters/856/141944530346.jpg","დაცემა"),
                new Movie(4,"https://static.imovies.cc/movies/covers/510/590/450141590-296ce197dea98dcdec7c542b09e9d651.jpg","მაკბეტი"),
                new Movie(5,"https://static.imovies.cc/movies/covers/510/667/878411667-7eb5f22f50d6585fd44e8b36f59667e3.jpg","შავი წყლები"),
                new Movie(6,"https://static.imovies.cc/movies/covers/510/152/878450152-da3c582696f3c7d1ba72d277e09f8819.jpg","პლატფორმა"),
                new Movie(7,"https://static.imovies.cc/m_posters/856/156214127525.jpg","ამოიღე დანები"),

            };

            public MoviRepository()
            {
            }

            public IEnumerable<Movie> Movies(string searchTitle)
            {
                return Data.Where(x => string.IsNullOrEmpty(searchTitle) 
                || (!string.IsNullOrEmpty(searchTitle) && x.Title.ToUpper().Contains(searchTitle.ToUpper())));
            }

            public void Create(Movie movie)
            {
                var mv = Data.OrderBy(x => x.Id).LastOrDefault();
                movie.Id = mv != null ? mv.Id + 1 : 1;
                Data.Add(movie);
            }

            public void Edit(Movie movie)
            {
                var m = Data.Where(x => x.Id == movie.Id).First();

                m.Thumb = movie.Thumb;
                m.Title = movie.Title;
            }

            public Movie GetMovieById(int id)
            {
                return Data.Find(x => x.Id == id);
            }

            public IEnumerable<Movie> SliderMovies()
            {
                return Data.OrderByDescending(x => x.Id).Take(3).ToList();
            }
        }
    }
}
