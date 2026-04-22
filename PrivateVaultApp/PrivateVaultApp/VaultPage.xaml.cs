using System.Text.Json;
using System.IO;
using System.Collections.Generic;

namespace PrivateVaultApp;

public partial class VaultPage : ContentPage
{
    List<VaultItem> items = new List<VaultItem>();

    string filePath = Path.Combine(FileSystem.AppDataDirectory, "vault.json");
    void SaveData()
    {
        var json = JsonSerializer.Serialize(items);
        File.WriteAllText(filePath, json);
    }

    void LoadData()
    {
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            items = JsonSerializer.Deserialize<List<VaultItem>>(json) ?? new List<VaultItem>();
            
        }
        vaultList.ItemsSource = items;
    }

    public VaultPage()
    {
        InitializeComponent();
        LoadData();
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

            SaveData();
            vaultList.ItemsSource = null;
            vaultList.ItemsSource = items;
            titleEntry.Text = "";
            secretEntry.Text = "";
        }
    }

    private void OnDeleteClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var item = button?.BindingContext as VaultItem;
        if (item != null)
        {
            items.Remove(item);
            SaveData();
            vaultList.ItemsSource = null;
            vaultList.ItemsSource = items;
        }
    }
}


public class VaultItem
{
    public string? Title { get; set; }
    public string? SecretText { get; set; }
}