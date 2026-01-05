using Avalonia.Controls;
using Avalonia.Interactivity;
using CommunityToolkit.Mvvm.Input;
using Moodly.ViewModels;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Input;
using Moodly.Views.Shared;

namespace Moodly.ViewModels
{

    public class AddMoodViewModel : INotifyPropertyChanged
    {
        private DateTimeOffset _selectedDate;
        private int selectedMood;
        private string _note;

        public DateTimeOffset SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged();
            }
        }
        public string Note
        {
            get => _note;
            set
            {
                _note = value;
                OnPropertyChanged();
            }
        }

        public IRelayCommand<string> MoodClickCommand { get; }

        public AddMoodViewModel()
        {
            MoodClickCommand = new RelayCommand<string>(param =>
            {
                selectedMood = Convert.ToInt32(param);
            });
        }
        #region przykładowa właściwość powiązana z widokiem
        private string _text = "Hello Avalonia";

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }
        #endregion

        // odświeżanie widoku
        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}



