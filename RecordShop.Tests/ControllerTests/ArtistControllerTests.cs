using Microsoft.AspNetCore.Mvc;
using Moq;
using RecordShop.Api.Controllers;
using RecordShop.Business.Services.IServices;
using RecordShop.Common.Dto.Music;
using RecordShop.DataAccess.Models.Music;

namespace RecordShop.Tests;

public class ArtistControllerTests
{
    Mock<IArtistService> _artistService = new Mock<IArtistService>();
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
        _artistService.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<ArtistReadDto>());

        // Act
        var result = await _controller.GetAll();

        // Assert
        _artistService.Verify(r => r.GetAllAsync(), Times.Once());
        Assert.IsInstanceOf<OkObjectResult>(result);
        var okResult = result as OkObjectResult;
        Assert.IsInstanceOf<IEnumerable<ArtistReadDto>>(okResult.Value);
        Assert.IsAssignableFrom<List<ArtistReadDto>>(okResult.Value);

    }
}
