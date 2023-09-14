using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using MVVMapp.App.Models;
using MVVMapp.App.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MVVMapp.App.Views
{
    public partial class NewItemPage : ContentPage
    {
        public NewItemPage(NewItemViewModel viewModel)
        {
            InitializeComponent();
            if (viewModel == null) { throw new ArgumentNullException(nameof(viewModel)); }
            BindingContext = viewModel;
        }
    }
}