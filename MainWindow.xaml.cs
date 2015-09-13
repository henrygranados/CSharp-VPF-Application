using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int sum = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        // This method allows to drag around window application
        private void MyApplication_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        // This method closes window
        private void closeWindow(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();      
        }
        //This method handles the "Click to add new coins button"
        private void AddNewCoins(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = System.Windows.Visibility.Visible;
        }
        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            //Hides InputBox.
            InputBox.Visibility = System.Windows.Visibility.Collapsed;

            // Resets InputBox.
            InputTextBox.Text = String.Empty;
        }
        //This method handles input text entered by user
        private void ClickToAddMoreCoins(object sender, RoutedEventArgs e)
        {

            //Hides InputBox and takes input text from user.
            InputBox.Visibility = System.Windows.Visibility.Collapsed;

            // Ensuring that input from user is a integer number
            String input = InputTextBox.Text;
            int result = 0;
            if (int.TryParse(input, out result))
            {
                if (sum + result > 30)
                {
                    MessageBoxResult answer = MessageBox.Show("You cannot enter more than 30 coins. Do you want to end?", "Message", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (answer == MessageBoxResult.Yes)
                    {
                        Application.Current.Shutdown();
                    }
                    InputTextBox.Text = String.Empty;
                }
                else
                {
                    // Resets InputBox.
                    sum += result;
                    try
                    {
                        CoinListBox.Items.RemoveAt(0);
                    }
                    catch
                    { }
                    CoinListBox.Items.Add(sum);
                }
            }
            else
            {
                MessageBox.Show("Please enter a number of coins");
            }
            InputTextBox.Text = String.Empty;
        }
    }
}
