using HelpTechService.Location.Domain.Model.Aggregates;

namespace HelpTechService.Tests.UnitTest
{
    public class LocationTest
    {
        [SetUp]
        public void SetUp() { }

        [Test]
        public void Department_Constructor_WithParameters_ShouldInitializeProperties()
        {
            // Arrange
            var id = 1;
            var name = "LIMA";

            // Act
            var department = new Department(id, name);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(department.Id, Is.EqualTo(id));
                Assert.That(department.Name, Is.EqualTo(name));
            });
        }

        [Test]
        public void District_Constructor_WithParameters_ShouldInitializeProperties()
        {
            // Arrange
            var id = 1;
            var departmentId = 2;
            var name = "LA VICTORIA";

            // Act
            var district = new District(id, departmentId, name);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(district.Id, Is.EqualTo(id));
                Assert.That(district.DepartmentsId, Is.EqualTo(departmentId));
                Assert.That(district.Name, Is.EqualTo(name));
            });
        }
    }
}