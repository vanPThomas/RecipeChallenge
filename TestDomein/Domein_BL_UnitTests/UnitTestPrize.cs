using Domain.Entity;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDomain.Domein_BL_UnitTests {
    public class UnitTestPrize {
        Prize p = new Prize(1, "Logo", "Prijs1", "BestePrijs", "Company1");

        [Fact]
        public void SetId_Valid() {
            p.SetId(2);

            Assert.Equal(2, p.Id);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void SetId_Invalid(int id) {
            Assert.Throws<PrizeException>(() => p.SetId(id));
        }

        [Fact]
        public void SetName_valid() {
            p.SetName("name");

            Assert.Equal("name", p.Name);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void SetName_Invalid(string name) {
            Assert.Throws<PrizeException>(() => p.SetName(name));
        }

        [Fact]
        public void SetDescription_valid() {
            p.SetDescription("Description");

            Assert.Equal("Description", p.Description);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void SetDescription_Invalid(string desc) {
            Assert.Throws<PrizeException>(() => p.SetDescription(desc));
        }

        [Fact]
        public void SetCompany_valid() {
            p.SetCompany("Company");

            Assert.Equal("Company", p.Company);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void SetCompany_Invalid(string company) {
            Assert.Throws<PrizeException>(() => p.SetCompany(company));
        }
    }
}
