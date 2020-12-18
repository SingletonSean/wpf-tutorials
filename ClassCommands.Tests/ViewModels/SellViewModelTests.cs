using ClassCommands.Exceptions;
using ClassCommands.Services;
using ClassCommands.Stores;
using ClassCommands.ViewModels;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassCommands.Tests.ViewModels
{
    [TestFixture]
    public class SellViewModelTests
    {
        private SellViewModel _viewModel;

        private Mock<IOwnedItemsStore> _mockOwnedItemsStore;
        private Mock<IPriceService> _mockPriceService;

        [SetUp]
        public void SetUp()
        {
            _mockOwnedItemsStore = new Mock<IOwnedItemsStore>();
            _mockPriceService = new Mock<IPriceService>();

            _viewModel = new SellViewModel(_mockOwnedItemsStore.Object, _mockPriceService.Object);
        }

        [Test]
        public void ExecuteCalculatePriceCommand_WithUnknownItem_SetsErrorMessage()
        {
            _mockPriceService.Setup(s => s.GetPrice(It.IsAny<string>())).Throws(new ItemPriceNotFoundException(It.IsAny<string>()));

            _viewModel.CalculatePriceCommand.Execute(null);

            Assert.IsNotNull(_viewModel.ErrorMessage);
        }
    }
}
