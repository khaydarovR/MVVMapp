using MVVMapp.App.Models;
using MVVMapp.App.ViewModels;
using MVVMapp.App.Views;
using System.Diagnostics;

namespace MVVMapp.App.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage(ItemsViewModel viewModel)
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
}