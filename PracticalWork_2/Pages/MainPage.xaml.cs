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
            if (sender is Button button)
            {
                InputEntry.Text += button.Text;
            }
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            InputEntry.Text = string.Empty;
        }

        private async void OnConvertClicked(object sender, EventArgs e)
        {
            if (sender is not Button button)
                return;

            string conversionType = button.Text;
            string input = InputEntry.Text;
            string bitsText = BitsEntry.Text;

            if (string.IsNullOrEmpty(input))
            {
                await DisplayAlert("Error", "Please enter a value to convert.", "OK");
                return;
            }

            // Optional: Validate bitsEntry is a number, even if not used
            if (!string.IsNullOrWhiteSpace(bitsText) && (!int.TryParse(bitsText, out int bits) || bits <= 0))
            {
                await DisplayAlert("Error", "Number of bits must be a positive integer.", "OK");
                return;
            }

            try
            {
                string result = conversionType switch
                {
                    "DecimalToBinary" => new DecimalToBinary("Decimal to binary", "Binary").Change(input),
                    "DecimalToTwoComplement" => new DecimalToTwoComplement("Decimal to binary (TwoComplement)", "TwoComplement").Change(input),
                    "DecimalToOctal" => new DecimalToOctal("Decimal to octal", "Octal").Change(input),
                    "DecimalToHexadecimal" => new DecimalToHexadecimal("Decimal to hexadecimal", "Hexadecimal").Change(input),
                    "BinaryToDecimal" => new BinaryToDecimal("Binary to decimal", "Decimal").Change(input),
                    "TwoComplementToDecimal" => new TwoComplementToDecimal("Binary(TwoComplement) to Decimal", "Decimal").Change(input),
                    "OctalToDecimal" => new OctalToDecimal("Octal to Decimal", "Decimal").Change(input),
                    "HexadecimalToDecimal" => new HexadecimalToDecimal("Hexadecimal to Decimal", "Decimal").Change(input),
                    _ => throw new InvalidOperationException("Invalid conversion type.")
                };

                // Show result in the input entry
                InputEntry.Text = result;
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

        private async void OnExitClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Exit", "Please close the app manually", "OK");
        }

        private async void OnOperationsClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(UserInfoPage));
        }
    }
}
