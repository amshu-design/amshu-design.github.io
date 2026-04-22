using System.Collections.Generic;

namespace PrivateVaultApp;

public partial class VaultPage : ContentPage
{
    List<VaultItem> items = new List<VaultItem>();

    public VaultPage()
    {
        InitializeComponent();

        items.Add(new VaultItem { Title = "Email", SecretText = "mypassword123" });
        items.Add(new VaultItem { Title = "Bank", SecretText = "secure456" });

        vaultList.ItemsSource = items;
    }

    private void OnAddClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(titleEntry.Text) &&
            !string.IsNullOrWhiteSpace(secretEntry.Text))
        {
            items.Add(new VaultItem
            {
                Title = titleEntry.Text,
                SecretText = secretEntry.Text
            });

            vaultList.ItemsSource = null;
            vaultList.ItemsSource = items;

            titleEntry.Text = "";
            secretEntry.Text = "";
        }
    }
}

public class VaultItem
{
    public string? Title { get; set; }
    public string? SecretText { get; set; }
}