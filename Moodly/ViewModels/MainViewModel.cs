using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Moodly.Views.Shared;

namespace Moodly.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private Control _currentView;

    [ObservableProperty]
    private string _greeting = "Welcome to Moodly!"; // CommunityToolkit zapewnia potem autogenerowane Greeting :o

    // Cache Views - tworzymy raz, używamy wiele razy
    private readonly HomeView _homeView = new();
    private readonly CalendarView _calendarView = new();
    private readonly AddMoodView _addMoodView = new();

    public MainViewModel()
    {
        CurrentView = _homeView;
        Greeting = "Home";
    }

    [RelayCommand]
    private void NavigateToHome()
    {
        CurrentView = _homeView;
        Greeting = "Home";
    }

    [RelayCommand]
    private void NavigateToCalendar()
    {
        CurrentView = _calendarView;
        Greeting = "Calendar";
    }

    [RelayCommand]
    private void NavigateToAddMood()
    {
        CurrentView = _addMoodView;
        Greeting = "Add Mood";
    }
}