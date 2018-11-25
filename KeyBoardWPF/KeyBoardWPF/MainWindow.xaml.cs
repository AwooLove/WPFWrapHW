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

namespace WpfApp7
{
    public partial class MainWindow : Window
    {
        Dictionary<string, string> letters;
        public MainWindow()
        {
            InitializeComponent();
            letters = new Dictionary<string, string>();
            letters.Add("Space", " ");
            letters.Add("Q", "q");
            letters.Add("W", "w");
            letters.Add("E", "e");
            letters.Add("R", "r");
            letters.Add("T", "t");
            letters.Add("Y", "y");
            letters.Add("U", "u");
            letters.Add("I", "i");
            letters.Add("O", "o");
            letters.Add("P", "p");
            letters.Add("A", "a");
            letters.Add("S", "s");
            letters.Add("D", "d");
            letters.Add("F", "f");
            letters.Add("G", "g");
            letters.Add("H", "h");
            letters.Add("J", "j");
            letters.Add("K", "k");
            letters.Add("L", "l");
            letters.Add("Z", "z");
            letters.Add("X", "x");
            letters.Add("C", "c");
            letters.Add("V", "v");
            letters.Add("B", "b");
            letters.Add("N", "n");
            letters.Add("M", "m");
        }
        Brush prewColor;
        List<string> randLetter;
        int i = 0, failKeyBoard = 0;

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (var item in Board.Children)
            {
                Console.WriteLine(e.Key.ToString());
                if (item is Border)
                {
                    if (((Border)item).Name == e.Key.ToString())
                    {
                        if (e.IsDown)
                        {
                            prewColor = ((Border)item).Background;
                        }

                        ((Border)item).Background = new SolidColorBrush(Colors.Red);
                        if (Stop.IsEnabled == true && ((Border)item).Name == randLetter[i].ToUpper())
                        {
                            UserWriteLetter.Text += letters[e.Key.ToString()];
                            i++;
                        }
                        else if (Stop.IsEnabled == true && e.Key.ToString() == "Space" && randLetter[i] == " " && ((Border)item).Name == "Space")
                        {
                            UserWriteLetter.Text += " ";
                            i++;
                        }
                        else if (Stop.IsEnabled == true)
                        {
                            failKeyBoard++;
                            userFails.Content = failKeyBoard.ToString();
                        };
                    }
                }
            }
        }
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (var item in Board.Children)
            {
                if (item is Border)
                {
                    if (((Border)item).Name == e.Key.ToString())
                    {
                        ((Border)item).Background = prewColor;
                    }
                }
            }
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Start.IsEnabled = false;
            Stop.IsEnabled = true;
            randLetter = new List<string> { "a", "g", "d", "m", "q", "i", " ", "s", "l", "q", "p" };
            for (int i = 0; i < randLetter.Count; i++)
            {
                RandLetter.Text += randLetter[i];
            }
        }
        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            Stop.IsEnabled = false;
            Start.IsEnabled = true;
            RandLetter.Text = "";
            UserWriteLetter.Text = "";
            i = 0;
            userFails.Content = "0";
            failKeyBoard = 0;
        }
    }
}

