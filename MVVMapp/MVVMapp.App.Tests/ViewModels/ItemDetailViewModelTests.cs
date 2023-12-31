﻿using Microsoft.Extensions.Logging;
using MVVMapp.App.Models;
using MVVMapp.App.Services;
using MVVMapp.App.ViewModels;
using NSubstitute.ExceptionExtensions;
using System.Collections.ObjectModel;

namespace MVVMapp.App.Tests.ViewModels
{
    public class ItemDetailViewModelTests
    {
        ILogger<ItemDetailViewModel> logger;
        readonly IDataStore<Item> dataStore;

        public ItemDetailViewModelTests()
        {
            using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = loggerFactory.CreateLogger<ItemDetailViewModel>();
            dataStore = new MockDataStore();
        }

        [Fact]
        public async void LoadItemIdTests()
        {
            // Arrange
            ItemDetailViewModel vm = new(dataStore, logger);
            var items = await dataStore.GetItemsAsync(true);
            foreach (var item in items)
            {
                // Act
                await vm.LoadItemId(item.Id);
                // Assert
                Assert.Equal(item.Name, vm.Name);
            }
        }

        [Fact]
        public async void LoadItemWithWrongIdTest()
        {
            ItemDetailViewModel vm = new(dataStore, logger);
            await vm.LoadItemId(Guid.NewGuid().ToString());
            Assert.True(string.IsNullOrEmpty(vm.Name));
        }

        [Fact]
        public async void LoadItemIdFailureTest()
        {
            ItemDetailViewModel vm = new(dataStore, logger);
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => vm.LoadItemId(null));
            Assert.Equal("Value cannot be null. (Parameter 'itemId')", ex.Message);
        }
    }
}
