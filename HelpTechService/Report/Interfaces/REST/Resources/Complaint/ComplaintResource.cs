namespace HelpTechService.Report.Interfaces.REST.Resources.Complaint
{
    public record ComplaintResource
        (int TypeComplaintId, int JobId,
        string Sender, DateTime RegistrationDate,
        string Description, string ComplaintState);
}