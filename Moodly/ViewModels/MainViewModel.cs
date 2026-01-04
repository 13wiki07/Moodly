using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Moodly.Views.Shared;
using Moodly.ViewModels;  // dla AddMoodViewModel

namespace Moodly.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private Control _currentView;

    [ObservableProperty]
    private string _greeting = "Welcome to Moodly!";

    // Cache ViewModels
    private readonly CalendarViewModel _calendarViewModel = new();
    private readonly HomeView _homeView = new();

    // Cache dla AddMood z ViewModel
    private AddMoodView? _addMoodView;
    private AddMoodViewModel? _addMoodViewModel;

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
        var calendarView = new CalendarView();
        calendarView.DataContext = _calendarViewModel;
        CurrentView = calendarView;
        Greeting = "Calendar";
    }

    [RelayCommand]
    private void NavigateToAddMood()
    {
        _addMoodViewModel ??= new AddMoodViewModel();

        if (_addMoodView == null)
        {
            _addMoodView = new AddMoodView();
            _addMoodView.DataContext = _addMoodViewModel; // ← TO JEST WAŻNE!
        }

        CurrentView = _addMoodView;
        Greeting = "Add Mood";
    }
}