using HelpTechService.Payment.Domain.Model.Aggregates;
using HelpTechService.Payment.Domain.Model.ValueObjects.QrTechnical;
using HelpTechService.Payment.Domain.Repositories;
using Moq;

namespace HelpTechService.Tests.UnitTest;


public class PaymentTest
{
    [Test]
    public async Task Upload_Qr_Must_To_Be_Working()
    {
        var qrTechnicalRepository = new Mock<IQrTechnicalRepository>();
        var qrCode = new QrTechnical("123", "http://dummy.png",EQrTechnicalState.ACTIVO);
        qrTechnicalRepository.Setup(x => x.AddAsync(qrCode)).Returns(Task.FromResult(qrCode));
        await qrTechnicalRepository.Object.AddAsync(qrCode);
        Assert.NotNull(qrCode.RegistrationDate);
        
    }

    [Test]
    public async Task Find_Qr_By_Technical_Must_To_Be_Working()
    {
        var qrTechnicalRepository = new Mock<IQrTechnicalRepository>();
        var qrCode = new QrTechnical("123", "http://dummy.png", EQrTechnicalState.ACTIVO);
        var qrCodes = new List<QrTechnical> { qrCode };
        qrTechnicalRepository
            .Setup(x => x.FindByTechnicalIdAsync(123))
            .Returns(Task.FromResult(qrCodes.AsEnumerable()));
    
        var response = await qrTechnicalRepository.Object.FindByTechnicalIdAsync(123);
        Assert.NotNull(response);
    }
}