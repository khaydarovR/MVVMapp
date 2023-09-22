using MVVMapp.App.ViewModels;

namespace MVVMapp.App.Views;

public partial class SchedulePage : ContentPage
{
    ScheduleViewModel _viewModel;

    public SchedulePage(ScheduleViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = _viewModel = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }
}