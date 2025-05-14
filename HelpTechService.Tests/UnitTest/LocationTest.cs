using NUnit.Framework;
using Moq;
using System.Threading.Tasks;

namespace HelpTechService.Tests.UnitTest
{
    [TestFixture]
    public class LocationServiceTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void Department_Constructor_WithParameters_ShouldInitializeProperties()
        {
            // Arrange
            var id = 1;
            var name = "Human Resources";

            // Act
            var department = new Department(id, name);

            // Assert
            Assert.AreEqual(1, department.Id);
            Assert.AreEqual("Human Resources", department.Name);
        }

        [Test]
        public void District_Constructor_WithParameters_ShouldInitializeProperties()
        {
            // Arrange
            var id = 1;
            var departmentsId = 2;
            var name = "Central District";

            // Act
            var district = new District(id, departmentsId, name);

            // Assert
            Assert.AreEqual(1, district.Id);
            Assert.AreEqual(2, district.DepartmentsId);
            Assert.AreEqual("Central District", district.Name);
        }
    }
}
