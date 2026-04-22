using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using System.Linq.Expressions;

namespace PrivateVaultApp;

public partial class VaultPage : ContentPage
{
    private List<VaultItem> items = new List<VaultItem>();
    private string filePath = Path.Combine(FileSystem.AppDataDirectory, "vault.json");

    public VaultPage()
    {
        InitializeComponent();
        LoadData();
    }
    private async void SaveData()
    {
        try

        {
            var json = JsonSerializer.Serialize(items);
            File.WriteAllText(filePath, json);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to save data: {ex.Message}", "OK");
        }
    }

   private async void LoadData()
    {
        try
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                items = JsonSerializer.Deserialize<List<VaultItem>>(json) ?? new List<VaultItem>();

            }
            vaultList.ItemsSource = items;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to load data: {ex.Message}", "OK");
            items = new List<VaultItem>();
                vaultList.ItemsSource = items;
        }
    }

    private async void OnAddClicked(object sender, EventArgs e)
    {
        try
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
                await DisplayAlert("Success", "Vault item added successfully.", "OK");
            }
        }
               catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to add item: {ex.Message}", "OK");
        }
    }

    private async Task OnDeleteClicked(object sender, EventArgs e)
    {
        try {
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
                catch (Exception ex)
        {
           await DisplayAlert("Error", $"Failed to delete item: {ex.Message}", "OK");
        }
    }


    private void OnTogglePassword(object sender, EventArgs e)
    {
        try { 
        secretEntry.IsPassword = !secretEntry.IsPassword;

       var button = sender as Button;
        if (button != null)
        {
            button.Text = secretEntry.IsPassword ? "Show" : "Hide";
        }
        }
        catch (Exception)
        {
        }
}
public class VaultItem
{
    public string? Title { get; set; }
    public string? SecretText { get; set; }
}