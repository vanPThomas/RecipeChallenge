using Domain.Entity;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDomain.Domein_BL_UnitTests {
    public class UnitTestChallenge {
        Challenge chal = new Challenge(1, "Challenge1", "BestChallenge", "Picture1", new List<Prize> { new Prize(1, "Logo1", "Prijs1", "BestePrijs", "Company1") }, DateTime.Now);

        [Fact]
        public void SetId_Valid() {
            chal.SetId(2);

            Assert.Equal(2, chal.Id);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void SetId_Invalid(int id) {
            Assert.Throws<ChallengeException>(() => chal.SetId(id));
        }

        [Fact]
        public void SetName_Valid() {
            chal.SetName("naam");

            Assert.Equal("naam", chal.Name);
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public void SetName_Invalid(string name) {
            Assert.Throws<ChallengeException>(() => chal.SetName(name));
        }

        [Fact]
        public void SetDescription_Valid() {
            chal.SetDescription("Text");

            Assert.Equal("Text", chal.Description);
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public void SetDescription_Invalid(string desc) {
            Assert.Throws<ChallengeException>(() => chal.SetDescription(desc));
        }

        [Fact]
        public void SetDefaultPicture_Valid() {
            chal.SetDefaultPicture("Text");

            Assert.Equal("Text", chal.DefaultPicture);
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public void SetDefaultPicture_Invalid(string picture) {
            Assert.Throws<ChallengeException>(() => chal.SetDefaultPicture(picture));
        }

        [Fact]
        public void SetPrizes_valid() {
            List<Prize> prizes = new List<Prize> { new Prize(2, "logo", "name", "description", "company"), new Prize(3, "logo3", "name3", "description3", "company3") };

            Assert.True(chal.Prizes.Count == 1);

            chal.SetPrizes(prizes);

            Assert.True(chal.Prizes.Count == 2);
            Assert.Equal("logo", chal.Prizes[0].Logo);
            Assert.Equal("name", chal.Prizes[0].Name);
            Assert.Equal("description", chal.Prizes[0].Description);
            Assert.Equal("company", chal.Prizes[0].Company);
        }

        [Fact]
        public void SetPrizes_Invalid() {
            List<Prize> prizes = new List<Prize>();

            Assert.Throws<ChallengeException>(() => chal.SetPrizes(prizes));
        }
    }
}
