using Domain.Entity;
using Domain.Exceptions;
using System.Reflection.Metadata;

namespace TestDomain.Domein_BL_UnitTests {
    public class UnitTestItem {
        Dictionary<Part, double> test = new Dictionary<Part, double>() { { new Part("part1", "kilo"), 2 } };
        List<string> photo = new List<string> { "Photo1", "Photo2" };

        [Fact]
        public void SetId_Valid() {
            Item t = new Item(test, 1, "Item1", photo);

            Assert.Equal(1, t.Id);
            t.SetId(2);
            Assert.Equal(2, t.Id);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void SetId_Invalid(int number) {
            Item t = new Item(test, 1, "Item1", photo);

            Assert.Throws<ItemException>(() => t.SetId(number));
            Assert.Equal(1, t.Id);
        }


        [Theory]
        [InlineData("title")]
        [InlineData("newTitle")]
        public void SetTitle_Valid(string title) {
            Item t = new Item(test, 1, "Item1", photo);

            t.SetTitle(title);
            Assert.Equal(title, t.Title);
        }


        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public void SetTitle_InValid(string title) {
            Item t = new Item(test, 1, "Item1", photo);

            Assert.Throws<ItemException>(() => t.SetTitle(title));
        }

        [Fact]
        public void SetPhoto_Valid() {
            Item t = new Item(test, 1, "Item1", photo);
            List<string> photosBackup = new List<string>(photo);

            Assert.Equal(2, photo.Count());
            t.Photos.Add("Photo3");
            Assert.Equal(3, photo.Count());
            Assert.Equal("Photo3", photo[2]);
            Assert.Equal(photosBackup, photo.Take(photo.Count - 1).ToList());
        }

        [Fact]
        public void SetPhoto_Invalid() {
            Item t = new Item(test, 1, "Item1", photo);

            List<string> invalidPhoto = new List<string>();
            Assert.Throws<ItemException>(() => t.SetPhotos(invalidPhoto));
        }
    }
}