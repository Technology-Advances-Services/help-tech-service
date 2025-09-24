using HelpTechService.IAM.Domain.Model.Aggregates;
using HelpTechService.Payment.Domain.Model.Commands.QrTechnical;
using HelpTechService.Payment.Domain.Model.ValueObjects.QrTechnical;
using TimeZoneConverter;

namespace HelpTechService.Payment.Domain.Model.Aggregates
{
    public class QrTechnical
    {
        public int Id { get; set; }
        public int TechnicalsId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string QrUrl { get; set; } = null!;
        public string State { get; set; } = null!;

        public virtual Technical Technical { get; } = null!;

        public QrTechnical()
        {
            this.Id = 0;
            this.TechnicalsId = 0;
            this.QrUrl = string.Empty;
            this.State = string.Empty;
        }
        public QrTechnical(string technicalId, string qrUrl,
            EQrTechnicalState qrTechnicalState)
        {
            this.TechnicalsId = int.TryParse
                (technicalId, out int technicalsId) != false ?
                int.Parse(technicalsId.ToString().TrimStart('0')) : 0;
            this.RegistrationDate = GetLimaNow();
            this.QrUrl = qrUrl;
            this.State = qrTechnicalState.ToString();
        }
        public QrTechnical(AddQrTechnicalCommand command)
        {
            this.TechnicalsId = int.TryParse
                (command.TechnicalId, out int technicalsId) != false ?
                int.Parse(technicalsId.ToString().TrimStart('0')) : 0;
            this.RegistrationDate = GetLimaNow();
            this.QrUrl = command.QrUrl;
            this.State = command.QrTechnicalState.ToString();
        }

        public static DateTime GetLimaNow()
        {
            DateTime utcNow = DateTime.UtcNow;

            var limaZone = TZConvert.GetTimeZoneInfo("America/Lima");

            return TimeZoneInfo.ConvertTimeFromUtc(utcNow, limaZone);
        }
    }
}