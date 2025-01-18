using Microsoft.EntityFrameworkCore;
using RecordShop.Common.Enums;
using RecordShop.DataAccess;
using RecordShop.DataAccess.Models.Inventory;
using RecordShop.DataAccess.Models.Music;
using RecordShop.DataAccess.Repositories;

namespace RecordShop.Tests.RepositoryTests
{
    public class InventoryRepositoryTests
    {
        private ApplicationDbContext _db;
        private InventoryRepository _inventoryRepository;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _db = new ApplicationDbContext(options);
            _inventoryRepository = new InventoryRepository(_db);
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
            IEnumerable<InventoryItem>? items = await _inventoryRepository.GetAllAsync();
            //No data added since _db creation in Setup, therefore should always be empty
            Assert.That(items.Count(), Is.EqualTo(0));

        }
        [Test]
        public async Task GetAllTestWithData()
        {
            //arrange
            InventoryItem Test = new InventoryItem()
            {
                Id = 1,
                MusicProductId = 1,
                Price = 1.00M,
                Quantity = 1,
            };
            _db.Add(Test);
            await _db.SaveChangesAsync();
            IEnumerable<InventoryItem>? items = await _inventoryRepository.GetAllAsync();
            //No data added since _db creation in Setup, therefore should always be empty
            Assert.AreEqual(1, items.ToList().Count);

        }
        [Test]
        public async Task GetAllWithStock()
        {
            Artist artist = new Artist()
            {
                Id = 1,
                Name = "Test",
                MusicRecords = []
            };
            Album album = new Album()
            {
                Id = 1,
                Title = "Test",
                Description = "Test",
                Artist = null,
                Genres = new List<AlbumGenre> { new AlbumGenre() { Id = 1, Genre=Genre.Pop,AlbumId=1 } }

            };
            ArtistAlbumJunction junction = new ArtistAlbumJunction()
            {
                Artist = artist,
                MusicRecord = album,
            };
            MusicProduct musicProduct = new MusicProduct()
            {
                Id = 1,
                MusicAlbum = album,
                MediaType = AlbumMediaType.CD,
                ReleaseDate = DateOnly.MinValue
            };
            //arrange
            InventoryItem Test = new InventoryItem()
            {
                Id = 1,
                MusicProduct = musicProduct,
                Price = 1.00M,
                Quantity = 2,
            };
            _db.Add(Test);
            await _db.SaveChangesAsync();
            IEnumerable<InventoryItem>? items = await _inventoryRepository.GetAllInStock();
            //No data added since _db creation in Setup, therefore should always be empty
            Assert.AreEqual(1, items.ToList().Count);

        }
        [Test]
        public async Task GetByIdTestWhereNotExist()
        {
            //arrange
            InventoryItem? item = await _inventoryRepository.GetByIdAsync(1);
            //currently no records. should return null
            Assert.IsNull(item);

        }
        //[Test]
        //public async Task GetByIdTestWhereExist()
        //{
        //    //arrange
        //    Artist Test = new Artist()
        //    {
        //        Name = "Test",
        //    };
        //    _db.Add(Test);
        //    await _db.SaveChangesAsync();
        //    Artist? artist = await _artistRepository.GetByIdAsync(1);
        //    Assert.IsNotNull(artist);
        //    Assert.That(artist.Id, Is.EqualTo(1));

        //}
        [Test]
        public async Task DeleteTestWhereNotExists()
        {
            //arrange
            //act
            var actual = await _inventoryRepository.DeleteAsync(4);
            //currently no records with matching id. should return false
            Assert.IsFalse(actual);

        }
        //[Test]
        //public async Task DeleteTestWhereExist()
        //{
        //    //arrange
        //    Artist Test = new Artist()
        //    {
        //        Name = "Test",
        //    };
        //    _db.Add(Test);
        //    await _db.SaveChangesAsync();
        //    //act
        //    var actual = await _artistRepository.DeleteAsync(1);
        //    //currently no records with matching id. should return false
        //    Assert.IsTrue(actual);

        //}
        //[Test]
        //public async Task CreateTest()
        //{
        //    //arrange
        //    Artist artist = new Artist()
        //    {
        //        Name = "Testing"
        //    };
        //    Artist artist2 = new Artist()
        //    {
        //        Name = "Test2ing"
        //    };
        //    //act
        //    var actual = await _artistRepository.CreateAsync(artist);
        //    var actual2 = await _artistRepository.CreateAsync(artist2);
           
        //    //assert
        //    Assert.IsTrue(actual.IsSuccess);
        //    Assert.That(artist.Name, Is.EqualTo("Testing"));
        //    Assert.IsTrue(actual2.IsSuccess);
        //    Assert.That(artist2.Id, Is.EqualTo(2));

        //}
        //[Test]
        //public async Task CreateTestBadData()
        //{
        //    //arrange
        //    Artist artist = new Artist()
        //    {
        //        Id = -9,
        //        Name = "Testing"
        //    };
        //    Artist artist2 = new Artist()
        //    {
        //        Name = ""
        //    };
        //    //act
        //    var actual = await _artistRepository.CreateAsync(artist);
        //    var actual2 = await _artistRepository.CreateAsync(artist2);
        //    var artistresult = _artistRepository.GetByIdAsync(artist.Id);

        //    //assert
        //    Assert.IsTrue(actual.IsSuccess);
        //    Assert.IsFalse(actual2.IsSuccess);
        //    Assert.Greater(artistresult.Id, 0);
            

        //}
        //[Test]
        //public async Task UpdateArtistWithValidData()
        //{
        //    //arrange
        //    Artist artist = new Artist()
        //    {
        //        Name = "Testing"
        //    };
        //    Artist artist2 = new Artist()
        //    {
        //        Name = "Test2ing"
        //    };
        //    await _artistRepository.CreateAsync(artist);
        //    var artist2result = await _artistRepository.CreateAsync(artist2);
        //    //act
        //    Artist newArtistData = new Artist()
        //    {
        //        Name = "Hello World!",
        //        Id = 98
        //    };
        //    await _artistRepository.UpdateAsync(2, newArtistData);
        //    var actual = await _artistRepository.GetByIdAsync(2);

        //    //assert
        //    Assert.IsTrue(artist2result.IsSuccess);
        //    Assert.That(actual.Name, Is.EqualTo("Hello World!"));
        //    Assert.That(actual.Id, Is.EqualTo(2));



        //}
    }
}