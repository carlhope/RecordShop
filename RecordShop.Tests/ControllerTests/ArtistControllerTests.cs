using Microsoft.AspNetCore.Mvc;
using Moq;
using RecordShop.Api.Controllers;
using RecordShop.Business.Services.IServices;
using RecordShop.Common.Dto.Music;
using RecordShop.DataAccess.Models.Music;

namespace RecordShop.Tests;

public class ArtistControllerTests
{
    Mock<IGenericService<Artist, ArtistDto>> _artistService = new Mock<IGenericService<Artist, ArtistDto>>();
    private ArtistController _controller;

    [SetUp]
    public void Setup()
    {
        _controller = new ArtistController(_artistService.Object);
    }

    [Test]
    public async Task GetAllArtists()
    {
        // Arrange
        _artistService.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<ArtistDto>());

        // Act
        var result = await _controller.GetAll();

        // Assert
        _artistService.Verify(r => r.GetAllAsync(), Times.Once());
        Assert.IsInstanceOf<OkObjectResult>(result);
        var okResult = result as OkObjectResult;
        Assert.IsInstanceOf<IEnumerable<ArtistDto>>(okResult.Value);
        Assert.IsAssignableFrom<List<ArtistDto>>(okResult.Value);

    }
}
