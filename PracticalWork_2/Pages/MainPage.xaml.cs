using Microsoft.Maui.Controls;
using System;
using PracticalWork_2.Core;

namespace PracticalWork_2.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            InputEntry.Text += button.Text;
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            InputEntry.Text = string.Empty; // Clear the input
        }

        private async void OnConvertClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            string conversionType = button.Text;
            string input = InputEntry.Text;

            if (string.IsNullOrEmpty(input))
            {
                await DisplayAlert("Error", "Please enter a value to convert.", "OK");
                return;
            }

            string result = string.Empty;
            int operations = 0;

            try
            {
                // Choose the correct conversion based on the button pressed
                switch (conversionType)
                {
                    case "DecimalToBinary":
                        result = new DecimalToBinary("Decimal to binary", "Binary").Change(input);
                        InputEntry.Text = string.Empty;
                        operations++;
                        break;
                    case "DecimalToTwoComplement":
                        result = new DecimalToTwoComplement("Decimal to binary (TwoComplement)", "TwoComplement").Change(input);
                        InputEntry.Text = string.Empty;
                        operations++;
                        break;
                    case "DecimalToOctal":
                        result = new DecimalToOctal("Decimal to octal", "Octal").Change(input);
                        InputEntry.Text = string.Empty;
                        operations++;

                        break;
                    case "DecimalToHexadecimal":
                        result = new DecimalToHexadecimal("Decimal to hexadecimal", "Hexadecimal").Change(input);
                        InputEntry.Text = string.Empty;
                        operations++;
                        break;
                    case "BinaryToDecimal":
                        result = new BinaryToDecimal("Binary to decimal", "Decimal").Change(input);
                        InputEntry.Text = string.Empty;
                        operations++;
                        break;
                    case "TwoComplementToDecimal":
                        result = new TwoComplementToDecimal("Binary(TwoComplement) to Decimal", "Decimal").Change(input);
                        InputEntry.Text = string.Empty;
                        operations++;
                        break;
                    case "OctalToDecimal":
                        result = new OctalToDecimal("Octal to Decimal", "Decimal").Change(input);
                        InputEntry.Text = string.Empty;
                        operations++;
                        break;
                    case "HexadecimalToDecimal":
                        result = new HexadecimalToDecimal("Hexadecimal to Decimal", "Decimal").Change(input);
                        InputEntry.Text = string.Empty;
                        operations++;
                        break;
                }

                await DisplayAlert("Result", $"Result: {result}", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Conversion failed: {ex.Message}", "OK");
            }
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

        private void OnExitClicked(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private async void OnOperationsClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(UserInfoPage));

        }
    }
}
