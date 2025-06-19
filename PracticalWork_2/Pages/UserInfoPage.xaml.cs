using Microsoft.Maui.Controls;
using System;
using System.IO;

namespace PracticalWork_2.Pages
{
    public partial class UserInfoPage : ContentPage
    {
        public string Username { get; set; }

        public UserInfoPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void OnInfoClicked(object sender, EventArgs e)
        {
            string inputUsername = UsernameEntry.Text?.Trim();

            if (string.IsNullOrEmpty(inputUsername))
            {
                await DisplayAlert("Error", "Please enter your username.", "OK");
                return;
            }

            string filePath = Path.Combine(AppContext.BaseDirectory, "Users.csv");

            if (!File.Exists(filePath))
            {
                await DisplayAlert("Error", "User database not found.", "OK");
                return;
            }

            string name = null;
            string usernameFound = null;
            string password = null;
            string operations = null;

            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var parts = line.Split(',');

                    if (parts.Length >= 5 && parts[1].Equals(inputUsername, StringComparison.OrdinalIgnoreCase))
                    {
                        name = parts[0];
                        usernameFound = parts[1];
                        password = parts[3];
                        operations = parts[4];
                        break;
                    }
                }
                reader.Close();
            }

            if (usernameFound != null)
            {
                await DisplayAlert("User info", $"Name: {name}\nUsername: {usernameFound}\nPassword: {password}\nNº Operations: {operations}", "OK");
            }
            else
            {
                await DisplayAlert("Not Found", "Username not found.", "OK");
            }
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

        private async void OnExitClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Exit", "Please close the app manually", "OK");
        }
    }
}
