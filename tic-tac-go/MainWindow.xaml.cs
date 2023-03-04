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
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            reset();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var mouseWasDownOn = e.Source as FrameworkElement;

            if (txt_challenge.Text.Equals(""))
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
                txt_challenge.Text = "";
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
                txt_challenge.Text = "";
            }
        }
        private bool checkForWin()
        {
            return false;
        }
        private void reset()
        {
            var rnd = new Random();
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

        }

        private void btn_Reset_Click(object sender, RoutedEventArgs e)
        {
            reset();
        }
    }

}
