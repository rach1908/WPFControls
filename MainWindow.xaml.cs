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
        }

        public MovieRepository mr = new MovieRepository();

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (tbx_title != null && dtp_releaseDate != null &&tbx_instructor !=null && cbx_genre != null)
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
                Movie m = new Movie(genre, format, isColor, director, releaseDate, title, id);
                mr.AddNew(m);
            }
        }
    }
}
