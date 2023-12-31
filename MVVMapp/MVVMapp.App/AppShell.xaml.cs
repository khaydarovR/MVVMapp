using MVVMapp.App.ViewModels;
using MVVMapp.App.Views;
using System.Diagnostics;

namespace MVVMapp.App
{
    public partial class AppShell : Shell
    {
        public static AppShell? CurrentAppShell { get; private set; } = default!;

        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(SelfSettingsPage), typeof(SelfSettingsPage));
            Routing.RegisterRoute(nameof(SchedulePage), typeof(SchedulePage));
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(ItemsPage), typeof(ItemsPage));
            CurrentAppShell = this;
        }

        /// <summary>
        /// Logout
        /// </summary>
        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Current.GoToAsync("//LoginPage");
        }

        protected override void OnNavigating(ShellNavigatingEventArgs args)
        {
            base.OnNavigating(args);

            if (args.Current != null)
            {
                Debug.WriteLine($"AppShell: source={args.Current.Location}, target={args.Target.Location}");
            }
        }

        public void SetRootPageTitle(string name)
        {

        }
    }
}