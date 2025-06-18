using System;
using System.IO;
using Microsoft.Maui.Controls;

namespace PracticalWork_2.Pages
{
    public partial class RegisterPage : ContentPage
    {
        private string userFilePath;

        public RegisterPage()
        {
            InitializeComponent();
            userFilePath = Path.Combine(AppContext.BaseDirectory, "Users.csv");
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            string name = NameEntry.Text?.Trim();
            string username = UsernameEntry.Text?.Trim();
            string email = EmailEntry.Text?.Trim();
            string password = PasswordEntry.Text;
            string operations = "0";
            string confirmPassword = ConfirmPasswordEntry.Text;
            bool isTermsAccepted = PolicyCheckBox.IsChecked;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                await DisplayAlert("Error", "All fields are required.", "OK");
                return;
            }

            if (password.Length < 6)
            {
                await DisplayAlert("Error", "Password must be at least 6 characters.", "OK");
                return;
            }

            if (password != confirmPassword)
            {
                await DisplayAlert("Error", "Passwords do not match.", "OK");
                return;
            }

            if (!isTermsAccepted)
            {
                await DisplayAlert("Error", "You must accept the protection policy.", "OK");
                return;
            }

            bool userExists = false;

            if (File.Exists(userFilePath))
            {
                using (var reader = new StreamReader(userFilePath))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var parts = line.Split(',');

                        if (parts.Length >= 2 && parts[1] == username)
                        {
                            userExists = true;
                            break;
                        }
                    }
                }
            }

            if (userExists)
            {
                await DisplayAlert("Error", "Username already exists.", "OK");
                return;
            }

            // Save new user to CSV file
            string newUserLine = $"{name},{username},{email},{password},{operations}";
            File.AppendAllText(userFilePath, newUserLine + Environment.NewLine);

            await DisplayAlert("Success", "Registration complete. You can now log in.", "OK");
            await Shell.Current.GoToAsync("//LoginPage");
        }

        private async void OnBackToLoginClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

        private async void OnExitClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Exit", "Please close the app manually", "OK");
        }
    }
}
