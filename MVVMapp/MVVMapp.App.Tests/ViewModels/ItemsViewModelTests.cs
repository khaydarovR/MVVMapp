using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Core.UnitTests;
using MVVMapp.App.Models;
using MVVMapp.App.Services;
using MVVMapp.App.ViewModels;
using MVVMapp.App.Views;
using NSubstitute;

namespace MVVMapp.App.Tests.ViewModels
{
    public class ItemsViewModelTests : ShellTestBase
    {
        ILogger<ItemsViewModel> logger;
        readonly IDataStore<Item> dataStore;

        public ItemsViewModelTests()
        {
            TestShell shell = new TestShell();
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            var abougPage = new ShellItem { Route = "AboutPage" };
            var page = MakeSimpleShellSection("Readme", "content");
            abougPage.Items.Add(page);
            shell.Items.Add(abougPage);

            Application app = Substitute.For<Application>();
            app.MainPage = shell;

            using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = loggerFactory.CreateLogger<ItemsViewModel>();
            dataStore = new MockDataStore();
        }

        [Fact]
        public void LoadItemsTest()
        {
            // Arrange
            ItemsViewModel vm = new(dataStore, logger);
            // Act
            vm.LoadItemsCommand.Execute(vm);
            // Assert
            Assert.Equal(6, vm.Items.Count);
        }

        //[Fact]
        //public void OnAddItemCommandTest()
        //{
        //    ItemsViewModel vm = new(dataStore, logger);
        //    vm.AddItemCommand.Execute(vm);
        //}
    }
}
