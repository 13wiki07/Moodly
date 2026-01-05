using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Moodly.ViewModels;
using Moodly.Views;
using System.Linq;

namespace Moodly;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        // Tworzymy wspólny ViewModel
        var viewModel = new MainViewModel();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
            DisableAvaloniaDataAnnotationValidation();

            // DLA DESKTOP: u¿ywamy Desktop layout
            var desktopView = new Views.Desktop.MainViewDesktop();
            desktopView.DataContext = viewModel;

            desktop.MainWindow = new MainWindow
            {
                Content = desktopView  // Wa¿ne: Content a nie DataContext!
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            // DLA ANDROID: u¿ywamy Android layout
            var androidView = new Views.Android.MainViewAndroid();
            androidView.DataContext = viewModel;

            singleViewPlatform.MainView = androidView;
        }

        base.OnFrameworkInitializationCompleted();
    }
    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}