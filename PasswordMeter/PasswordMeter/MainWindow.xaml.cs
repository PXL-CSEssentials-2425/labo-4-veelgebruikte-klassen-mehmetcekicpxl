using Microsoft.VisualBasic;
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

namespace PasswordMeter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Input velden: userNameTextBox en passwordTextBox
        /// Output veld: resultTextBlock
        /// </summary>

        public MainWindow()
        {
            InitializeComponent();
        }

        private void passwordMeterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = userNameTextBox.Text;
            username = username.Trim();
            string password = passwordTextBox.Text;
            password = password.Trim();

        

;

            int passwordStrength = 0;
           

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                resultTextBlock.Text = "please enter a username and password";
                return;
            }
            if (password.Contains(username))
            {
                resultTextBlock.Text = "password can not contain username";
                return;
            }
            else
            {
                passwordStrength++;
            }
            if (password.Length < 10)
            {
                resultTextBlock.Text = "password must be at least 10 characters long";
                return;
            }
            else
            {
                passwordStrength++;
            }
            bool hasDigit = false;
            bool hasUpper = false;
            bool hasLower = false;


            foreach (char character in password.ToCharArray())
            {
                if(char.IsDigit(character))
                {
                    hasDigit = true;
                }
                if (char.IsUpper(character)) 
                {
                    hasUpper = true;
                }
                if (char.IsLower(character)) 
                {
                    hasLower = true;
                }


            }
            if (hasDigit)
            {
                passwordStrength++;
            }
            if (hasLower)
            {
                passwordStrength++; 
            }
            if (hasUpper)
            {
                passwordStrength++;
            }
            switch (passwordStrength)
            { 
                case 5:
                    resultTextBlock.Text = "strong password";
                    resultTextBlock.Foreground = Brushes.Green;
                    break;
                case 4:
                    resultTextBlock.Text = "medium password";
                    resultTextBlock.Foreground= Brushes.Orange;
                    break;
                default:
                    resultTextBlock.Text = "weak password";
                    resultTextBlock.Foreground= Brushes.Red;
                    break;
            }


            if (passwordStrength <4)
            {
                Random rnd = new Random();
                StringBuilder passwordBuilder = new StringBuilder();

                // 5 letters from username:
                for (int i = 0; i < 5; i++)
                {
                    int randomPosition = rnd.Next(0, username.Length);
                    string randomChar = password.Substring(randomPosition, 1);

                    passwordBuilder.Append(randomChar.ToLower());
                }

                // 5 random digits
                for (int i = 0; i < 5; i++)
                {
                    int randomNumber = rnd.Next(0, 10);
                    passwordBuilder.Append(randomNumber);
                }

                // 2 letters from username
                for (int i = 0; i < 2; i++)
                {
                    int randomPosition = rnd.Next(0, username.Length);
                    string randomChar = password.Substring(randomPosition, 1);

                    passwordBuilder.Append(randomChar.ToUpper());
                }

                // random number of exclamation marks
                for (int i = 0; i < rnd.Next(1, 6); i++)
                {
                    passwordBuilder.Append("!");
                }

                // resultTextBlock.Text = passwordBuilder.ToString();
                MessageBoxResult result = MessageBox.Show("willekurig wachtwoord gebruiken ?", "zwak password",MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result==MessageBoxResult.Yes)
                {
                    passwordTextBox.Text = passwordBuilder.ToString();
                }
                string input = Interaction.InputBox("type close to exit", "afsluiten", "close");
                if (input.Equals("close", StringComparison.CurrentCultureIgnoreCase))
                {
                    this.Close();
                }
            }
                 

            




           
        }
    }
}
