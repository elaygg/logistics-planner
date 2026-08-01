using Avalonia.Controls;
using Avalonia.Interactivity;
using LogisticsPlanner.Logics;
using System;
using System.IO;

namespace LogisticsPlanner;

public partial class MainWindow : Window
{
    // Shipping calculation service instance
    private readonly ShippingCalculatorService _service;

    public MainWindow()
    {
        InitializeComponent();

        string jsonPath = Path.Combine(AppContext.BaseDirectory, "tariffs.json");

        _service = new ShippingCalculatorService(jsonPath);

        // Bind the button click event
        CalculateBtn.Click += CalculateBtn_Click;
    }

    // Get shipping options when the calculate button is clicked
    private void CalculateBtn_Click(object? sender, RoutedEventArgs e)
    {
        try
        {   
            double weight = (double)(WeightInput.Value ?? 0);

            var selectedItem = ZoneInput.SelectedItem as ComboBoxItem;
            string zone = selectedItem?.Content?.ToString() ?? "Local";

            var results = _service.CalculateShipping(weight, zone);

            ResultsGrid.ItemsSource = results;

            if(results.Count == 0)
                StatusText.Text = "There are no available tariffs for the specified parameters.";
            else
                StatusText.Text = $"Found tariffs: {results.Count}";
        }
        catch (Exception ex)
        {
            StatusText.Text = $"Error: {ex.Message}";
        }
    }
}