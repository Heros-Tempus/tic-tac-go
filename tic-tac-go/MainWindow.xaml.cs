using System;
using System.Collections.Generic;
using System.IO;
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

namespace tic_tac_go
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

        List<string> listA = new List<string>();
        List<string> listB = new List<string>();
        TextBlock selection;
        private bool game_over;

        public bool Game_over { get => game_over; set => game_over = value; }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            reset();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var mouseWasDownOn = e.Source as FrameworkElement;

            if (txt_challenge.Text.Equals("") || txt_challenge.Text.Equals("X Wins") || txt_challenge.Text.Equals("O Wins"))
                if (mouseWasDownOn != null)
                {
                    if (mouseWasDownOn.Tag != null)
                    {
                        string elementTag = mouseWasDownOn.Tag.ToString();
                        txt_challenge.Text = listB[Int32.Parse(elementTag)];
                        selection = (TextBlock)mouseWasDownOn;
                    }
                }

        }

        private void btn_X_Click(object sender, RoutedEventArgs e)
        {
            if (txt_challenge.Text != "")
            {
                selection.Text = "X";
                selection.TextDecorations = TextDecorations.Underline;
                selection.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE4572E"));
                txt_challenge.Text = "";
                Game_over = checkForWin("X");
            }
        }

        private void btn_NoDecision_Click(object sender, RoutedEventArgs e)
        {
            txt_challenge.Text = "";
        }

        private void btn_O_Click(object sender, RoutedEventArgs e)
        {
            if (txt_challenge.Text != "")
            {
                selection.Text = "O";
                selection.TextDecorations = TextDecorations.Underline;
                selection.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF6AE2D"));
                txt_challenge.Text = "";
                Game_over = checkForWin("O");
            }
        }
        private bool checkForWin(string x_o)
        {
            x_o = x_o + " Wins";
            var c = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00A896"));
            if (txt_0_0.Text == txt_0_1.Text && txt_0_1.Text == txt_0_2.Text && !txt_0_0.Text.Equals("_") && !Game_over)
            {
                txt_0_0.Background = c;
                txt_0_1.Background = c;
                txt_0_2.Background = c;
                txt_challenge.Text = x_o;
                return true;
            }
            if (txt_1_0.Text == txt_1_1.Text && txt_1_1.Text == txt_1_2.Text && !txt_1_0.Text.Equals("_") && !Game_over)
            {
                txt_1_0.Background = c;
                txt_1_1.Background = c;
                txt_1_2.Background = c;
                txt_challenge.Text = x_o;
                return true;
            }
            if (txt_2_0.Text == txt_2_1.Text && txt_2_1.Text == txt_2_2.Text && !txt_2_0.Text.Equals("_") && !Game_over)
            {
                txt_2_0.Background = c;
                txt_2_1.Background = c;
                txt_2_2.Background = c;
                txt_challenge.Text = x_o;
                return true;
            }
            if (txt_0_0.Text == txt_1_0.Text && txt_1_0.Text == txt_2_0.Text && !txt_0_0.Text.Equals("_") && !Game_over)
            {
                txt_0_0.Background = c;
                txt_1_0.Background = c;
                txt_2_0.Background = c;
                txt_challenge.Text = x_o;
                return true;
            }
            if (txt_0_1.Text == txt_1_1.Text && txt_1_1.Text == txt_2_1.Text && !txt_0_1.Text.Equals("_") && !Game_over)
            {
                txt_0_1.Background = c;
                txt_1_1.Background = c;
                txt_2_1.Background = c;
                txt_challenge.Text = x_o;
                return true;
            }
            if (txt_0_2.Text == txt_1_2.Text && txt_1_2.Text == txt_2_2.Text && !txt_0_2.Text.Equals("_") && !Game_over)
            {
                txt_0_2.Background = c;
                txt_1_2.Background = c;
                txt_2_2.Background = c;
                txt_challenge.Text = x_o;
                return true;
            }
            if (txt_0_0.Text == txt_1_1.Text && txt_1_1.Text == txt_2_2.Text && !txt_0_0.Text.Equals("_") && !Game_over)
            {
                txt_0_0.Background = c;
                txt_1_1.Background = c;
                txt_2_2.Background = c;
                txt_challenge.Text = x_o;
                return true;
            }
            if (txt_0_2.Text == txt_1_1.Text && txt_1_1.Text == txt_2_0.Text && !txt_0_2.Text.Equals("_") && !Game_over)
            {
                txt_0_2.Background = c;
                txt_1_1.Background = c;
                txt_2_0.Background = c;
                txt_challenge.Text = x_o;
                return true;
            }
            if (Game_over)
            {
                return true;
            }
            return false;
        }
        private void reset()
        {
            var rnd = new Random();
            var c = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF4343"));
            using (var reader = new StreamReader(@"challenges.csv"))
            {
                while (!reader.EndOfStream)
                {
                    listA.Add(reader.ReadLine());
                }
            }
            listB = (List<string>)listA.OrderBy(x => rnd.Next()).Take(9).ToList();
            txt_challenge.Text = "";
            txt_0_0.Text = "_";
            txt_0_1.Text = "_";
            txt_0_2.Text = "_";
            txt_1_0.Text = "_";
            txt_1_1.Text = "_";
            txt_1_2.Text = "_";
            txt_2_0.Text = "_";
            txt_2_1.Text = "_";
            txt_2_2.Text = "_";
            txt_0_0.TextDecorations = null;
            txt_0_1.TextDecorations = null;
            txt_0_2.TextDecorations = null;
            txt_1_0.TextDecorations = null;
            txt_1_1.TextDecorations = null;
            txt_1_2.TextDecorations = null;
            txt_2_0.TextDecorations = null;
            txt_2_1.TextDecorations = null;
            txt_2_2.TextDecorations = null;
            txt_0_0.Foreground = c;
            txt_0_1.Foreground = c;
            txt_0_2.Foreground = c;
            txt_1_0.Foreground = c;
            txt_1_1.Foreground = c;
            txt_1_2.Foreground = c;
            txt_2_0.Foreground = c;
            txt_2_1.Foreground = c;
            txt_2_2.Foreground = c;
            txt_0_0.Background = null;
            txt_0_1.Background = null;
            txt_0_2.Background = null;
            txt_1_0.Background = null;
            txt_1_1.Background = null;
            txt_1_2.Background = null;
            txt_2_0.Background = null;
            txt_2_1.Background = null;
            txt_2_2.Background = null;
            Game_over = false;
        }

        private void btn_Reset_Click(object sender, RoutedEventArgs e)
        {
            reset();
        }
    }

}
