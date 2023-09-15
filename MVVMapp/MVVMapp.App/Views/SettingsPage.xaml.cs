using MVVMapp.App.ViewModels;

namespace MVVMapp.App.Views;

public partial class SelfSettingsPage : ContentPage
{
    SettingsViewModel _viewModel;

    public SelfSettingsPage(SettingsViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = _viewModel = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.OnAppearing();
    }
}