using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EX4_WPFControls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Mr.AddNew(new Movie("Star Trek: Beyond", "Sci-Fi", "2.35:1", true, "Justin Lin", new DateTime(2016, 07, 22), 1));
            Mr.AddNew(new Movie("Star Wars: The Last Jedi", "Epic Space Opera", "2.39:1", true, "Ryan Johnson", new DateTime(2017, 12, 15), 1));
        }
        private MovieRepository mr = new MovieRepository();
        private List<string> genres = new List<string>(){
            "Sci-Fi",
            "Epic Space Opera",
            "Fantasy",
            "Romance",
            "Kids",
            "Thriller",
            "Action and Adventure",
            "Horror",
            "Comedy",
            "Western",
            "Musical",
            "Drama",
            "Sports"
        };

        public List<string> Genres
        {
            get { return genres; }
            set { genres = value; }
        }

        public MovieRepository Mr { get => mr; set => mr = value; }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btn_deleteSelected_Click(object sender, RoutedEventArgs e)
        {
            Mr.RemoveMovie(dgr_movies.SelectedItem as Movie);
        }


        private void btn_new_Click(object sender, RoutedEventArgs e)
        {
            if (tbx_title != null && dtp_releaseDate != null && tbx_instructor != null && cbx_genre.SelectedItem != null)
            {
                string genre = cbx_genre.SelectedItem.ToString();
                string format;
                if (rbtn_ratio1.IsChecked == true)
                {
                    format = "16:9";
                }
                else if (rbtn_ratio2.IsChecked == true)
                {
                    format = "3:4";
                }
                else
                {
                    format = "22:9";
                }
                bool isColor;
                if (chx_color.IsChecked == true)
                {
                    isColor = true;
                }
                else
                {
                    isColor = false;
                }
                string director = tbx_instructor.Text;
                DateTime releaseDate = dtp_releaseDate.SelectedDate.Value;
                string title = tbx_title.Text;
                int id = 1;
                Movie m = new Movie(title, genre, format, isColor, director, releaseDate, id);
                Mr.AddNew(m);
            }
        }

    }
}
