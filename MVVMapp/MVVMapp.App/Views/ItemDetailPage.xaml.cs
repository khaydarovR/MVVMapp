using Microsoft.Maui;
using Microsoft.Maui.Controls;
using MVVMapp.App.ViewModels;
using System.ComponentModel;

namespace MVVMapp.App.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}