using Microsoft.Maui.Controls;
using System;
using System.IO;

namespace PracticalWork_2.Pages
{
    public partial class RecoverPasswordPage : ContentPage
    {
        public RecoverPasswordPage()
        {
            InitializeComponent();
        }

        private async void OnSendClicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text?.Trim();

            if (string.IsNullOrEmpty(email))
            {
                await DisplayAlert("Error", "Please enter your email.", "OK");
                return;
            }

            string filePath = Path.Combine(AppContext.BaseDirectory, "Users.csv");

            if (!File.Exists(filePath))
            {
                await DisplayAlert("Error", "User database not found.", "OK");
                return;
            }

            string foundUsername = null;
            string foundPassword = null;

            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var parts = line.Split(',');

                    if (parts.Length >= 4 && parts[2].Equals(email, StringComparison.OrdinalIgnoreCase))
                    {
                        foundUsername = parts[1];
                        foundPassword = parts[3];
                        break;
                    }
                }
                reader.Close();
            }

            if (foundUsername != null && foundPassword != null)
            {
                await DisplayAlert("Password Recovery", $"Username: {foundUsername}\nPassword: {foundPassword}", "OK");
                await Shell.Current.GoToAsync("//LoginPage");
            }
            else
            {
                await DisplayAlert("Not Found", "Email not found.", "OK");
            }
        }

        private async void OnBackToLoginClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
