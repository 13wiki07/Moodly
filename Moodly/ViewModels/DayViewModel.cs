using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Moodly.ViewModels;

public partial class DayViewModel : ObservableObject
{
    [ObservableProperty]
    private int _dayNumber;

    [ObservableProperty]
    private DateTime _date;

    [ObservableProperty]
    private bool _isCurrentMonth = true;

    [ObservableProperty]
    private bool _isToday = false;

    [ObservableProperty]
    private string _backgroundColor = "#FFC0CB"; // Różowy

    [ObservableProperty]
    private string _textColor = "#000000"; // Czarny

    [ObservableProperty]
    private string _borderColor = "Transparent";

    [ObservableProperty]
    private int _borderThickness = 1;

    // Komenda gdy klikniemy dzień
    [RelayCommand]
    private void DayClicked()
    {
        // Tu będziemy emitować event do CalendarViewModel
        Console.WriteLine($"Clicked day: {Date.ToShortDateString()}");
    }

    // Oblicz kolory na podstawie właściwości
    partial void OnIsCurrentMonthChanged(bool value)
    {
        TextColor = value ? "#000000" : "#AAAAAA"; // Wyszarzone jeśli nie z tego miesiąca
    }

    partial void OnIsTodayChanged(bool value)
    {
        BorderColor = value ? "#000000" : "Transparent";
        BorderThickness = value ? 2 : 1;
    }
}