using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Globalization;

namespace Moodly.ViewModels;

public partial class CalendarViewModel : ObservableObject
{
    [ObservableProperty]
    private DateTime _currentDate = DateTime.Now;

    [ObservableProperty]
    private string _monthYearDisplay = "";

    public ObservableCollection<DayViewModel> Days { get; } = new();

    public CalendarViewModel()
    {
        UpdateMonthYearDisplay();
        GenerateDaysForCurrentMonth();

        // Debug:
        Console.WriteLine($"MonthYearDisplay: {MonthYearDisplay}");
        Console.WriteLine($"Days count: {Days.Count}");
    }

    private void UpdateMonthYearDisplay()
    {
        var culture = new CultureInfo("pl-PL");
        MonthYearDisplay = CurrentDate.ToString("MMMM yyyy", culture);
        MonthYearDisplay = char.ToUpper(MonthYearDisplay[0]) + MonthYearDisplay.Substring(1);
    }

    private void GenerateDaysForCurrentMonth()
    {
        Days.Clear();

        var firstDayOfMonth = new DateTime(CurrentDate.Year, CurrentDate.Month, 1);
        var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

        // Znajdź poniedziałek przed pierwszym dniem miesiąca
        var startDate = firstDayOfMonth;
        while (startDate.DayOfWeek != DayOfWeek.Monday)
        {
            startDate = startDate.AddDays(-1);
        }

        // Generuj 42 dni (6 tygodni × 7 dni)
        for (int i = 0; i < 42; i++)
        {
            var date = startDate.AddDays(i);
            var isCurrentMonth = date.Month == CurrentDate.Month;
            var isToday = date.Date == DateTime.Today;

            var dayViewModel = new DayViewModel
            {
                Date = date,
                DayNumber = date.Day,
                IsCurrentMonth = isCurrentMonth,
                IsToday = isToday,
                BackgroundColor = isCurrentMonth ? "#FFC0CB" : "#F0F0F0",
                TextColor = isCurrentMonth ? "#000000" : "#AAAAAA"
            };

            Days.Add(dayViewModel);
        }
    }

    partial void OnCurrentDateChanged(DateTime value)
    {
        UpdateMonthYearDisplay();
        GenerateDaysForCurrentMonth();
        OnPropertyChanged(nameof(CanGoPrevious));
        OnPropertyChanged(nameof(CanGoNext));
    }

    [RelayCommand]
    private void NavigateToPreviousMonth()
    {
        // Sprawdź czy można iść wstecz (nie wcześniej niż 2020?)
        if (CurrentDate.Year > 2020 || (CurrentDate.Year == 2020 && CurrentDate.Month > 1))
        {
            CurrentDate = CurrentDate.AddMonths(-1);
            UpdateMonthYearDisplay();
            GenerateDaysForCurrentMonth();
        }
    }

    [RelayCommand]
    private void NavigateToNextMonth()
    {
        // Nie pozwalaj iść do przyszłości
        var nextMonth = CurrentDate.AddMonths(1);
        if (nextMonth <= DateTime.Now)
        {
            CurrentDate = nextMonth;
            UpdateMonthYearDisplay();
            GenerateDaysForCurrentMonth();
        }
    }

    public bool CanGoPrevious
    {
        get
        {
            var minDate = new DateTime(2020, 1, 1);
            var previousMonth = CurrentDate.AddMonths(-1);
            return previousMonth >= minDate;
        }
    }

    public bool CanGoNext
    {
        get
        {
            var nextMonth = CurrentDate.AddMonths(1);
            return nextMonth <= DateTime.Now;
        }
    }
}