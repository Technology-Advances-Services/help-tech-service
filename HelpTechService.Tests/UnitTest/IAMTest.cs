using NUnit.Framework;
using Moq;
using System.Threading.Tasks;

namespace HelpTechService.Tests.IntegrationTest
{
    [TestFixture]
    public class IAMServiceTests
    {
        private IAMService _sut;
        private Mock<IIAMRepository> _repoMock;
        private Mock<ILogger<IAMService>> _loggerMock;

        [SetUp]
        public void SetUp()
        {
            _repoMock = new Mock<IIAMRepository>();
            _loggerMock = new Mock<ILogger<IAMService>>();
            _sut = new IAMService(_repoMock.Object, _loggerMock.Object);
        }

        [TearDown]
        public void TearDown() => _sut = null;

        [Test]
        public async Task AuthenticateAsync_WithValidCredentials_ReturnsJwt()
        {
            // Arrange
            var creds = new LoginDto { UserName = "admin", Password = "P@ssw0rd" };
            var expected = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...";

            _repoMock.Setup(r => r.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>()))
                     .ReturnsAsync(expected);

            // Act
            var token = await _sut.AuthenticateAsync(creds);

            // Assert
            Assert.AreEqual(expected, token);
            _repoMock.Verify(r => r.AuthenticateAsync(creds.UserName, creds.Password), Times.Once);
        }
    }
}
using NUnit.Framework;
using Moq;
using System.Threading.Tasks;

namespace HelpTechService.Tests.UnitTest
{
    [TestFixture]
    public class IAMServiceTests
    {
        [SetUp]
        public void SetUp()
        {

        }


        [Test]
        public void Consumer_Constructor_WithParameters_ShouldInitializeProperties()
        {
            // Arrange
            var id = "0001";
            var districtId = 5;
            var profileUrl = "https://example.com/profile.jpg";
            var firstname = "John";
            var lastname = "Doe";
            var age = 30;
            var genre = "Male";
            var phone = 123456789;
            var email = "john.doe@example.com";
            var consumerState = EConsumerState.Active;

            // Act
            var consumer = new Consumer(
                id: id,
                districtId: districtId,
                profileUrl: profileUrl,
                firstname: firstname,
                lastname: lastname,
                age: age,
                genre: genre,
                phone: phone,
                email: email,
                consumerState: consumerState
            );

            // Assert
            Assert.AreEqual(1, consumer.Id); // "0001" convertido a 1
            Assert.AreEqual(5, consumer.DistrictsId);
            Assert.AreEqual("https://example.com/profile.jpg", consumer.ProfileUrl);
            Assert.AreEqual("JOHN", consumer.Firstname);
            Assert.AreEqual("DOE", consumer.Lastname);
            Assert.AreEqual(30, consumer.Age);
            Assert.AreEqual("Male", consumer.Genre);
            Assert.AreEqual(123456789, consumer.Phone);
            Assert.AreEqual("john.doe@example.com", consumer.Email);
            Assert.AreEqual("Active", consumer.State);
        }

        [Test]
        public void Job_Constructor_WithParameters_ShouldInitializeProperties()
        {
            // Arrange
            var id = "0001";
            var specialtyId = 3;
            var districtId = 2;
            var profileUrl = "https://example.com/technical.jpg";
            var firstname = "Jane";
            var lastname = "Smith";
            var age = 28;
            var genre = "Female";
            var phone = 987654321;
            var email = "jane.smith@example.com";
            var technicalAvailability = ETechnicalAvailability.Available;
            var technicalState = ETechnicalState.Active;

            // Act
            var technical = new Technical(
                id: id,
                specialtyId: specialtyId,
                districtId: districtId,
                profileUrl: profileUrl,
                firstname: firstname,
                lastname: lastname,
                age: age,
                genre: genre,
                phone: phone,
                email: email,
                technicalAvailability: technicalAvailability,
                technicalState: technicalState
            );

            // Assert
            Assert.AreEqual(1, technical.Id); // "0001" convertido a 1
            Assert.AreEqual(3, technical.SpecialtiesId);
            Assert.AreEqual(2, technical.DistrictsId);
            Assert.AreEqual("https://example.com/technical.jpg", technical.ProfileUrl);
            Assert.AreEqual("JANE", technical.Firstname);
            Assert.AreEqual("SMITH", technical.Lastname);
            Assert.AreEqual(28, technical.Age);
            Assert.AreEqual("Female", technical.Genre);
            Assert.AreEqual(987654321, technical.Phone);
            Assert.AreEqual("jane.smith@example.com", technical.Email);
            Assert.AreEqual("Available", technical.Availability);
            Assert.AreEqual("Active", technical.State);
        }
    }
}
