using Localization.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Moq;
using Xunit;

namespace Tests;
public class LocalizationControllerTests
{
    private readonly Mock<IHtmlLocalizer<LocalizationController>> _mockLocalizer;
    private readonly LocalizationController _localizationController;

    public LocalizationControllerTests()
    {
        _mockLocalizer = new Mock<IHtmlLocalizer<LocalizationController>>();

        _localizationController = new LocalizationController(_mockLocalizer.Object);
    }

    [Fact]
    public void GivenEnglishLocale_WhenRequestingIndex_ReturnsEnglishHtmlString()
    {
        // Arrange
        var key = "Greeting";
        var localizedValue = "<h1>Hello! This is the localization test code!</h1>";
        var localizedString = new LocalizedHtmlString(key, localizedValue);

        _mockLocalizer.Setup(_ => _[key]).Returns(localizedString);

        // Act
        var result = (ViewResult)_localizationController.Index();

        // Assert
        Assert.Equal(localizedValue, ((LocalizedHtmlString)result.ViewData[key]).Value);
    }

    [Fact]
    public void GivenSpanishLocale_WhenRequestingIndex_ReturnsSpanishHtmlString()
    {
        // Arrange
        var key = "Greeting";
        var localizedValue = "<h1>¡Hola! ¡Este es el código de prueba de localización!</h1>";
        var localizedString = new LocalizedHtmlString(key, localizedValue);

        _mockLocalizer.Setup(_ => _[key]).Returns(localizedString);

        // Act
        var result = (ViewResult)_localizationController.Index();

        // Assert
        Assert.Equal(localizedValue, ((LocalizedHtmlString)result.ViewData[key]).Value);
    }


    [Fact]
    public void GivenVietnameseLocale_WhenRequestingIndex_ReturnsVietnameseHtmlString()
    {
        // Arrange
        var key = "Greeting";
        var localizedValue = "<h1>Xin chào! Đây là mã kiểm tra bản địa hóa!</h1>";
        var localizedString = new LocalizedHtmlString(key, localizedValue);

        _mockLocalizer.Setup(_ => _[key]).Returns(localizedString);

        // Act
        var result = (ViewResult)_localizationController.Index();

        // Assert
        Assert.Equal(localizedValue, ((LocalizedHtmlString)result.ViewData[key]).Value);
    }
}