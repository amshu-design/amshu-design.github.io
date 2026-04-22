
// Project: Private Vault App (.NET MAUI)
// Author: Amshika Gautam
// Course: Computer Programming and Analysis
// Description: 
// This application allows users to securely store,
// view, and manage personal vault items.

namespace PrivateVaultApp
{
    public partial class MainPage : ContentPage
    {
        string masterPassword = "1234";

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            if (passwordEntry.Text == masterPassword)
            {
                await Navigation.PushAsync(new VaultPage());
            }
            else
            {
                messageLabel.TextColor = Colors.Red;
                messageLabel.Text = "Wrong Password";
            }
        }
    }
}