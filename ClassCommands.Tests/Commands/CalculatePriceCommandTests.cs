using ClassCommands.Commands;
using ClassCommands.Exceptions;
using ClassCommands.Services;
using ClassCommands.ViewModels;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassCommands.Tests.Commands
{
    [TestFixture]
    public class CalculatePriceCommandTests
    {
        private CalculatePriceCommand _command;

        private Mock<ICalculatePriceViewModel> _mockViewModel; 
        private Mock<IPriceService> _mockPriceService;

        [SetUp]
        public void SetUp()
        {
            _mockViewModel = new Mock<ICalculatePriceViewModel>();
            _mockPriceService = new Mock<IPriceService>();

            _command = new CalculatePriceCommand(_mockViewModel.Object, _mockPriceService.Object);
        }

        [Test]
        public void Execute_WithUnknownItem_SetsErrorMessage()
        {
            _mockPriceService.Setup(s => s.GetPrice(It.IsAny<string>())).Throws(new ItemPriceNotFoundException(It.IsAny<string>()));

            _command.Execute(null);

            _mockViewModel.VerifySet(v => v.ErrorMessage = It.IsAny<string>());
        }
    }
}
