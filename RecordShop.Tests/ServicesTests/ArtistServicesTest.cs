using AutoMapper;
using Moq;
using RecordShop.Business.Services;
using RecordShop.Common.Dto.Music;
using RecordShop.Common.Models;
using RecordShop.DataAccess.Models.Music;
using RecordShop.DataAccess.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.Tests.ServicesTests
{
    internal class ArtistServicesTest
    {
        private static Mock<IArtistRepository> repo = new Mock<IArtistRepository>();
        private IMapper _mapper;
        private ArtistService artistService;

        [SetUp]
        public void SetUp()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Artist, ArtistReadDto>().ReverseMap();
                cfg.CreateMap<Artist, ArtistWriteDto>().ReverseMap();
            });
            _mapper = config.CreateMapper();
            artistService = new ArtistService(_mapper, repo.Object);
        }
        [Test]
        public async Task GetAllAsync()
        {
            //arrange
            repo.Setup(r => r.GetAllAsync().Result).Returns(new List<Artist>());
            //act
            var result = await artistService.GetAllAsync();
            //assert
            repo.Verify(r => r.GetAllAsync(), Times.Once());
            Assert.That(result, Is.TypeOf<List<ArtistReadDto>>());
        }
        [Test]
        public async Task GetByIdAsync()
        {
            //arrange
            repo.Setup(r => r.GetByIdAsync(8).Result).Returns(new Artist() { Id = 8 });
            //act
            var result = await artistService.GetByIdAsync(8);
            //assert
            repo.Verify(r => r.GetByIdAsync(8), Times.Once());
            Assert.That(result, Is.TypeOf<ArtistReadDto>());
        }
        [Test]
        public async Task CreateAsync()
        {
            ArtistWriteDto artistDto = new ArtistWriteDto()
            {
                Name = "Test"
            };
            repo.Setup(r => r.CreateAsync(It.IsAny<Artist>()).Result).Returns(new OperationResult() { IsSuccess = true});
            //act
            var result = await artistService.CreateAsync(artistDto);
            //assert
            repo.Verify(r => r.CreateAsync(It.IsAny<Artist>()), Times.Once());
            Assert.That(result, Is.TypeOf<OperationResult>());
        }
        [Test]
        public async Task UpdateAsync()
        {
            ArtistWriteDto artistDto = new ArtistWriteDto()
            {
                Name = "Test"
            };
            repo.Setup(r => r.UpdateAsync(1,It.IsAny<Artist>()).Result).Returns(new OperationResult() { IsSuccess = true });
            //act
            var result = await artistService.UpdateAsync(1,artistDto);
            //assert
            repo.Verify(r => r.UpdateAsync(1,It.IsAny<Artist>()), Times.Once());
            Assert.That(result, Is.TypeOf<OperationResult>());
        }
        [Test]
        public async Task DeleteAsync()
        {
            repo.Setup(r => r.DeleteAsync(1).Result).Returns(true);
            //act
            var result = await artistService.DeleteAsync(1);
            //assert
            repo.Verify(r => r.DeleteAsync(1), Times.Once());
            Assert.IsTrue(result.IsSuccess);
        }

    }
}
