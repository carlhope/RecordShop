using AutoMapper;
using Moq;
using RecordShop.Business.Services;
using RecordShop.Common.Dto.Music;
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
        private static Mock<IGenericRepository<Artist>> repo = new Mock<IGenericRepository<Artist>>();
        private IMapper _mapper;
        private ArtistService artistService;

        [SetUp]
        public void SetUp()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Artist, ArtistDto>().ReverseMap();
            });
            _mapper = config.CreateMapper();
            artistService = new ArtistService(_mapper, repo.Object);
        }
        [Test]
        public void GetAllAsync()
        {
            //arrange
            repo.Setup(r => r.GetAllAsync().Result).Returns(new List<Artist>());
            //act
            artistService.GetAllAsync().Wait();
            //assert
            repo.Verify(r => r.GetAllAsync(), Times.Once());
        }
        [Test]
        public void GetByIdAsync()
        {
            //arrange
            repo.Setup(r => r.GetByIdAsync(8).Result).Returns(new Artist() { Id = 8 });
            //act
            artistService.GetByIdAsync(8).Wait();
            //assert
            repo.Verify(r => r.GetByIdAsync(8), Times.Once());
        }

    }
}
