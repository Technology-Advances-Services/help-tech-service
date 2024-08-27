namespace HelpTechService.Report.Interfaces.REST.Resources.Complaint
{
    public record RegisterComplaintResource
        (int TypeComplaintId, int JobId,
        string Sender, string Description);
}