using MVVMapp.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMapp.App.Tests.ViewModels
{
    public class AboutViewModelTests
    {
        [Fact]
        public void SetTitleTest()
        {
            string AboutTitle = "AboutTest";
            AboutViewModel viewModel = new();
            viewModel.Title = AboutTitle;
            Assert.Equal(AboutTitle, viewModel.Title);
        }
    }
}
