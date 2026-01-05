using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
using Moodly.ViewModels;
using System;
using System.Linq;
using System.Diagnostics;

namespace Moodly.Views.Shared; // zmieñ Moodle -> Moodly.Views przy nowej stronie

public partial class AddMoodView : UserControl
{
    public AddMoodView()
    {
        InitializeComponent();
        DataContext = new AddMoodViewModel();
        // przypisz event po za³adowaniu UserControl
        //Function.SelectButton(this, "moodBtn");
        this.Loaded += AddClickClass_Loaded;
    }

    private void AddClickClass_Loaded(object? sender, RoutedEventArgs e)
    {
        // teraz przyciski istniej¹ w drzewie wizualnym
        this.GetVisualDescendants()
            .OfType<Button>()
            .Where(b => b.Classes.Contains("moodBtn"))
            .ToList()
            .ForEach(b => b.Click += MoodButton_Click);
    }

    private Button? _selectedButton;
    private void MoodButton_Click(object? sender, RoutedEventArgs e)
    {
        Debug.WriteLine("Button clicked");

        // Usuñ klasê "selected" z poprzedniego przycisku
        if (_selectedButton is not null)
        {
            _selectedButton.Classes.Remove("selected");
        }
        
        // Dodaj klasê "selected" do klikniêtego przycisku
        Button btn = sender as Button;
        btn.Classes.Add("selected");
        _selectedButton = btn;

            //// Powiadom ViewModel
            //if (DataContext is AddMoodViewModel vm)
            //    vm.SelectedMood = clickedButton.CommandParameter?.ToString();
    }

}