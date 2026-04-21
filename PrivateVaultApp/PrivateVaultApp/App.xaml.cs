using Microsoft.Extensions.DependencyInjection;

namespace PrivateVaultApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }
        string masterPassword = "1234";

        private void OnLoginClicked(object sender, EventArgs e)
        {
            if (passwordEntry.Text == masterPassword)
            {
                messageLabel.TextColor = Colors.Green;
                messageLabel.Text = "Access Granted ✅";
            }
            else
            {
                messageLabel.TextColor = Colors.Red;
                messageLabel.Text = "Wrong Password ❌";
            }
        }


        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}