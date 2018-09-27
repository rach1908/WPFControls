using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX4_WPFControls
{
    public class Movie
    {
        private int id;
        private string title;
        private DateTime releaseDate;
        private string director;
        private bool isColor;
        private string format;
        private string genre;

        public Movie(string title, string genre, string format, bool isColor, string director, DateTime releaseDate,  int id)
        {
            Title = title;
            Genre = genre;
            Format = format;
            IsColor = isColor;
            Director = director;
            ReleaseDate = releaseDate;
            Id = id;
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Director
        {
            get { return director; }
            set { director = value; }
        }

        public DateTime ReleaseDate
        {
            get { return releaseDate; }
            set { releaseDate = value; }
        }

        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        public string Format
        {
            get { return format; }
            set { format = value; }
        }

        public bool IsColor
        {
            get { return isColor; }
            set { isColor = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

    }
}
