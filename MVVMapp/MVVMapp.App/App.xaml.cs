using MVVMapp.App.Services;
using MVVMapp.App.Views;

namespace MVVMapp.App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(SelfSettingsPage), typeof(SelfSettingsPage));
            Routing.RegisterRoute(nameof(SchedulePage), typeof(SchedulePage));

            MainPage = new AppShell();
        }
        private async void OnMenuItemClicked(System.Object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}