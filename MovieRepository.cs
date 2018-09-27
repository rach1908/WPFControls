using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX4_WPFControls
{
    public class MovieRepository
    {
        ObservableCollection<Movie> movies = new ObservableCollection<Movie>
        {
            new Movie("Sci-Fi", "2.35:1", true, "Justin Lin", new DateTime(2016,07,22), "Star Trek: Beyond", 1),
            new Movie("Epic Space Opera", "2.39:1", true, "Ryan Johnson", new DateTime(2017,12,15), "Star Wars: The Last Jedi", 1)
        };

        public ObservableCollection<Movie> GetAll()
        {
            return movies;
        }

        public void AddNew(Movie movie)
        {
            movies.Add(movie);
        }
        public void Update(Movie movieToUpdate)
        {
            foreach (Movie movie in movies)
            {
                if (movie.Id == movieToUpdate.Id)
                {
                    movies.Remove(movie);
                    movies.Add(movieToUpdate);
                    break;
                }
            }
        }
    }
}
