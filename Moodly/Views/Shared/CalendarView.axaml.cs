using Avalonia.Controls;
using Moodly.ViewModels;
using System;

namespace Moodly.Views.Shared;

public partial class CalendarView : UserControl
{
    public CalendarView()
    {
        InitializeComponent();

        // Tymczasowo ustaw DataContext dla testu
        DataContext = new CalendarViewModel();

        // Lub sprawdŸ:
        Loaded += (s, e) =>
        {
            Console.WriteLine($"DataContext type: {DataContext?.GetType().Name}");
            Console.WriteLine($"MonthYearDisplay: {(DataContext as CalendarViewModel)?.MonthYearDisplay}");
        };
    }
}

