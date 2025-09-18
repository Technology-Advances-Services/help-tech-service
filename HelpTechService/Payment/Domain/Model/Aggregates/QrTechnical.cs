using TimeZoneConverter;
using HelpTechService.IAM.Domain.Model.Aggregates;
using HelpTechService.Payment.Domain.Model.ValueObjects;

namespace HelpTechService.Payment.Domain.Model.Aggregates
{
    public class QrTechnical
    {
        public int Id { get; set; }
        public int TechnicalId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string QrUrl { get; set; } = null!;
        public string State { get; set; } = null!;

        public virtual Technical Technical { get; } = null!;

        public QrTechnical()
        {
            this.Id = 0;
            this.TechnicalId = 0;
            this.QrUrl = string.Empty;
            this.State = string.Empty;
        }

        public static DateTime GetLimaNow()
        {
            DateTime utcNow = DateTime.UtcNow;

            var limaZone = TZConvert.GetTimeZoneInfo("America/Lima");

            return TimeZoneInfo.ConvertTimeFromUtc(utcNow, limaZone);
        }
    }
}