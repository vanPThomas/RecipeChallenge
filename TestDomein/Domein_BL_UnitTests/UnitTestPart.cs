using Domain.Entity;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDomain.Domein_BL_UnitTests {
    public class UnitTestPart {
        Part p = new Part("Part1", "kilo");

        [Fact]
        public void SetName_Valid() {
            p.SetName("name");

            Assert.Equal("name", p.Name);
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public void SetName_Invalid(string name) {
            Assert.Throws<PartException>(() => p.SetName(name));
        }

        [Fact]
        public void SetUnitOfMeasurement_Valid() {
            p.SetUnitOfMeasurement("UnitOfMeasurement");

            Assert.Equal("UnitOfMeasurement", p.UnitOfMeasurement);
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public void SetUnitOfMeasurement_Invalid(string unit) {
            Assert.Throws<PartException>(() => p.SetUnitOfMeasurement(unit));
        }
    }
}
