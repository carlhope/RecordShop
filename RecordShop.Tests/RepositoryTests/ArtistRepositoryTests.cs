using Microsoft.EntityFrameworkCore;
using RecordShop.DataAccess;
using RecordShop.DataAccess.Models.Music;
using RecordShop.DataAccess.Repositories;

namespace RecordShop.Tests.RepositoryTests
{
    public class ArtistRepositoryTests
    {
        private ApplicationDbContext _db;
        private ArtistRepository _artistRepository;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _db = new ApplicationDbContext(options);
            _artistRepository = new ArtistRepository(_db);
        }
        [TearDown]
        public void TearDown()
        {
            _db.Database.EnsureDeleted();
            _db.Dispose();
        }

        [Test]
        public async Task GetAllTestEmptyDb()
        {
            //arrange
            List<Artist>? artists = await _artistRepository.GetAllAsync();
            //No data added since _db creation in Setup, therefore should always be empty
            Assert.That(artists.Count(), Is.EqualTo(0));

        }
        [Test]
        public async Task GetAllTestWithData()
        {
            //arrange
            Artist Test = new Artist()
            {
                Name = "Test",
            };
            _db.Add(Test);
            await _db.SaveChangesAsync();
            List<Artist>? artists = await _artistRepository.GetAllAsync();
            //No data added since _db creation in Setup, therefore should always be empty
            Assert.AreEqual(1, artists.Count);

        }
        [Test]
        public async Task GetByIdTestWhereNotExist()
        {
            //arrange
            Artist? artist = await _artistRepository.GetByIdAsync(1);
            //currently no records. should return null
            Assert.IsNull(artist);

        }
        [Test]
        public async Task GetByIdTestWhereExist()
        {
            //arrange
            Artist Test = new Artist()
            {
                Name = "Test",
            };
            _db.Add(Test);
            await _db.SaveChangesAsync();
            Artist? artist = await _artistRepository.GetByIdAsync(1);
            Assert.IsNotNull(artist);
            Assert.That(artist.Id, Is.EqualTo(1));

        }
        [Test]
        public async Task DeleteTestWhereNotExists()
        {
            //arrange
            //act
            var actual = await _artistRepository.DeleteAsync(4);
            //currently no records with matching id. should return false
            Assert.IsFalse(actual);

        }
        [Test]
        public async Task DeleteTestWhereExist()
        {
            //arrange
            Artist Test = new Artist()
            {
                Name = "Test",
            };
            _db.Add(Test);
            await _db.SaveChangesAsync();
            //act
            var actual = await _artistRepository.DeleteAsync(1);
            //currently no records with matching id. should return false
            Assert.IsTrue(actual);

        }
        [Test]
        public async Task CreateTest()
        {
            //arrange
            Artist artist = new Artist()
            {
                Name = "Testing"
            };
            Artist artist2 = new Artist()
            {
                Name = "Test2ing"
            };
            //act
            var actual = await _artistRepository.CreateAsync(artist);
            var actual2 = await _artistRepository.CreateAsync(artist2);
           
            //assert
            Assert.IsTrue(actual.IsSuccess);
            Assert.That(artist.Name, Is.EqualTo("Testing"));
            Assert.IsTrue(actual2.IsSuccess);
            Assert.That(artist2.Id, Is.EqualTo(2));

        }
        [Test]
        public async Task CreateTestBadData()
        {
            //arrange
            Artist artist = new Artist()
            {
                Id = -9,
                Name = "Testing"
            };
            Artist artist2 = new Artist()
            {
                Name = ""
            };
            //act
            var actual = await _artistRepository.CreateAsync(artist);
            var actual2 = await _artistRepository.CreateAsync(artist2);
            var artistresult = _artistRepository.GetByIdAsync(artist.Id);

            //assert
            Assert.IsTrue(actual.IsSuccess);
            Assert.IsFalse(actual2.IsSuccess);
            Assert.Greater(artistresult.Id, 0);
            

        }
        [Test]
        public async Task UpdateArtistWithValidData()
        {
            //arrange
            Artist artist = new Artist()
            {
                Name = "Testing"
            };
            Artist artist2 = new Artist()
            {
                Name = "Test2ing"
            };
            await _artistRepository.CreateAsync(artist);
            var artist2result = await _artistRepository.CreateAsync(artist2);
            //act
            Artist newArtistData = new Artist()
            {
                Name = "Hello World!",
                Id = 98
            };
            await _artistRepository.UpdateAsync(2, newArtistData);
            var actual = await _artistRepository.GetByIdAsync(2);

            //assert
            Assert.IsTrue(artist2result.IsSuccess);
            Assert.That(actual.Name, Is.EqualTo("Hello World!"));
            Assert.That(actual.Id, Is.EqualTo(2));



        }
    }
}