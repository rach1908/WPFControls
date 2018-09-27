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
        private ObservableCollection<Movie> movies = new ObservableCollection<Movie>();

        public ObservableCollection<Movie> Movies
        {
            get { return movies; }
            set { movies = value; }
        }


        public ObservableCollection<Movie> GetAll()
        {
            return movies;
        }

        public void AddNew(Movie movie)
        {
            movies.Add(movie);
        }

        public void RemoveMovie(Movie movie)
        {
            if (movies.Contains(movie))
            {
                movies.Remove(movie);
            }
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
