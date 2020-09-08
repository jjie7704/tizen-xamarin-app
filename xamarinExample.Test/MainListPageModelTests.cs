using Moq;
using NUnit.Framework;
using System;
using xamarinExample.Models;
using xamarinExample.Services;
using xamarinExample.ViewModels;

namespace xamarinExample.Test
{
    public class MainListPageModelTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SelectedProperty_Selected_NavigateToBunchPageAsyncShouldBeCalled()
        {
            Mock<INavigationService> mockNavigationService = new Mock<INavigationService>();
            Mock<IRepository> mockRepository = new Mock<IRepository>();
            var mainListPageModel = new MainListPageModel(mockNavigationService.Object, mockRepository.Object);
            var bunch = new Bunch("mango", "banana");
            mockNavigationService.Setup(x => x.NavigateToBunchPageAsync(bunch));
            mainListPageModel.Selected = bunch;

            mockNavigationService.Verify(x => x.NavigateToBunchPageAsync(bunch), Times.Once());
        }
    }
}