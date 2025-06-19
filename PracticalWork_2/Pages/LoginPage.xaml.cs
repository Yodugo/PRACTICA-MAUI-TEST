using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace PracticalWork_2.Pages
{
    public partial class LoginPage : ContentPage
    {
        private string userFilePath;

        public LoginPage()
        {
            InitializeComponent();
            userFilePath = Path.Combine(AppContext.BaseDirectory, "Users.csv");
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text?.Trim();
            string password = PasswordEntry.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Error", "Please enter both username and password.", "OK");
                return;
            }

            if (!File.Exists(userFilePath))
            {
                await DisplayAlert("Error", "No users found. Please register first.", "OK");
                return;
            }

            string name = null;
            bool isAuthenticated = false;


            using (var reader = new StreamReader(userFilePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var parts = line.Split(',');

                    if (parts.Length >= 4 && parts[1] == username && parts[3] == password)
                    {
                        name = parts[0];
                        isAuthenticated = true;
                        break;
                    }
                }
                reader.Close();
            }


            if (isAuthenticated)
            {
                await DisplayAlert("Success", $"Welcome, {name}!", "OK");
                await Shell.Current.GoToAsync("//MainPage");
            }
            else
            {
                await DisplayAlert("Error", "Invalid username or password.", "OK");

            }
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//RegisterPage");
        }

        private async void OnExitClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Exit", "Please close the app manually", "OK");
        }

        private async void OnForgotPasswordClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("RecoverPasswordPage");
        }
    }
}
