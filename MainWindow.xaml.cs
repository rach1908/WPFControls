using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            Mr.AddNew(new Movie("Star Trek: Beyond", "Sci-Fi", "16:9", true, "Justin Lin", new DateTime(2016, 07, 22), 1));
            Mr.AddNew(new Movie("Star Wars: The Last Jedi", "Epic Space Opera", "3:4", true, "Ryan Johnson", new DateTime(2017, 12, 15), 1));
        }
        private MovieRepository mr = new MovieRepository();

        public MovieRepository Mr { get => mr; set => mr = value; }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (dgr_movies.SelectedItem != null)
            {
                (dgr_movies.SelectedItem as Movie).Title = tbx_title.Text;
                (dgr_movies.SelectedItem as Movie).ReleaseDate = dpr_releaseDate.SelectedDate.Value;
                (dgr_movies.SelectedItem as Movie).Director = tbx_instructor.Text;
                (dgr_movies.SelectedItem as Movie).IsColor = chx_color.IsChecked.Value;
                if (rbtn_ratio1.IsChecked == true)
                {
                    (dgr_movies.SelectedItem as Movie).Format = "16:9";
                }
                else if (rbtn_ratio2.IsChecked == true)
                {
                    (dgr_movies.SelectedItem as Movie).Format = "3:4";
                }
                else
                {
                    (dgr_movies.SelectedItem as Movie).Format = "22:9";
                }
                (dgr_movies.SelectedItem as Movie).Genre = (cbx_genre.SelectedItem as ComboBoxItem).Content.ToString();
                SearchList();
            }
        }

        private void btn_deleteSelected_Click(object sender, RoutedEventArgs e)
        {
            Mr.RemoveMovie(dgr_movies.SelectedItem as Movie);
            SearchList();
        }


        private void btn_new_Click(object sender, RoutedEventArgs e)
        {
            if (tbx_title != null && dpr_releaseDate != null && tbx_instructor != null && cbx_genre.SelectedItem != null)
            {
                string genre = (cbx_genre.SelectedItem as ComboBoxItem).Content.ToString();
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
                DateTime releaseDate = dpr_releaseDate.SelectedDate.Value;
                string title = tbx_title.Text;
                int id = 1;
                Movie m = new Movie(title, genre, format, isColor, director, releaseDate, id);
                Mr.AddNew(m);
                SearchList();
            }
        }

        private void dgr_movies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgr_movies.SelectedItem != null)
            {
                //change radiobox selection
                if ((dgr_movies.SelectedItem as Movie).Format == "16:9")
                {
                    rbtn_ratio1.IsChecked = true;
                }
                else if ((dgr_movies.SelectedItem as Movie).Format == "3:4")
                {
                    rbtn_ratio2.IsChecked = true;
                }
                else if ((dgr_movies.SelectedItem as Movie).Format == "22:9")
                {
                    rbtn_ratio3.IsChecked = true;
                }

                //change combobox selection

                var comboItem = cbx_genre.Items.OfType<ComboBoxItem>().FirstOrDefault(x => x.Content.ToString() == ((sender as DataGrid).SelectedItem as Movie).Genre);

                int index = cbx_genre.Items.IndexOf(comboItem);

                cbx_genre.SelectedIndex = index;

            }
        }

        private void tbx_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchList();
        }


        private void dpr_searchFrom_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchList();
        }

        private void dpr_searchTo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchList();
        }

        private void SearchList()
        {
            if (tbx_search.Text == "" && dpr_searchFrom.SelectedDate == null && dpr_searchTo.SelectedDate == null)
            {
                dgr_movies.ItemsSource = mr.Movies;
            }
            else
            {
                ObservableCollection<Movie> searchResults = new ObservableCollection<Movie>();
                if (tbx_search.Text != "")
                {
                    string searchTerm = tbx_search.Text;
                    /*
                    Til ære for Jens-Ole, dette stykke kode står til minde om hans brave kamp.
                    ObservableCollection<Movie> searchResults = new ObservableCollection<Movie>(mr.Movies.Where(x => x.Title.ToLower().Contains(searchTerm)));
                    */
                    for (int i = 0; i < mr.Movies.Count; i++)
                    {
                        Movie m = Mr.Movies[i];
                        if (m.Title.ToLower().Contains(searchTerm))
                        {
                            searchResults.Add(m);
                        }

                    }
                }
                if (dpr_searchFrom.SelectedDate != null)
                {
                    DateTime from = dpr_searchFrom.SelectedDate.Value;
                    if (tbx_search.Text == "")
                    {
                        for (int i = 0; i < Mr.Movies.Count; i++)
                        {
                            Movie m = Mr.Movies[i];
                            if (m.ReleaseDate >= from)
                            {
                                searchResults.Add(m);
                            }
                        }
                    }
                    else if (tbx_search.Text != "")
                    {
                        if (searchResults.Count != 0)
                        {
                            for (int i = 0; i < searchResults.Count; i++)
                            {
                                Movie m = searchResults[i];
                                if (m.ReleaseDate < from)
                                {
                                    searchResults.Remove(m);
                                }
                            }
                        }
                    }
                }

                if (dpr_searchTo.SelectedDate != null)
                {
                    DateTime to = dpr_searchTo.SelectedDate.Value;
                    if (dpr_searchFrom.SelectedDate == null && tbx_search.Text == "")
                    {
                        for (int i = 0; i < Mr.Movies.Count; i++)
                        {
                            Movie m = Mr.Movies[i];
                            if (m.ReleaseDate <= to)
                            {
                                searchResults.Add(m);
                            }
                        }
                    }
                    else
                    {
                        if (searchResults.Count != 0)
                        {
                            for (int i = 0; i < searchResults.Count; i++)
                            {
                                Movie m = searchResults[i];
                                if (m.ReleaseDate > to)
                                {
                                    searchResults.Remove(m);
                                }
                            }
                        }
                    }
                }

                dgr_movies.ItemsSource = searchResults;
            }
        }


    }
}
