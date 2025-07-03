using Microsoft.EntityFrameworkCore;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System.Net;
using System.Net.Mail;
using HelpTechService.Attention.Domain.Model.Aggregates;
using HelpTechService.Attention.Domain.Model.Entities;
using HelpTechService.Attention.Domain.Model.ValueObjects.Job;
using HelpTechService.Attention.Domain.Repositories;
using HelpTechService.IAM.Domain.Model.Aggregates;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Configuration;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace HelpTechService.Attention.Infrastructure.Persistence.EFC.Repositories
{
    internal class JobRepository
        (HelpTechContext context) :
        BaseRepository<Job>(context),
        IJobRepository
    {
        public async Task<bool> AssignJobDetailAsync
            (int id, DateTime workDate, decimal time,
            decimal laborBudget, decimal materialBudget) =>
            await Context.Set<Job>().Where(j => j.Id == id)
            .ExecuteUpdateAsync(j => j
            .SetProperty(u => u.AnswerDate, DateTime.Now)
            .SetProperty(u => u.WorkDate, workDate)
            .SetProperty(u => u.Time, time)
            .SetProperty(u => u.LaborBudget, laborBudget)
            .SetProperty(u => u.MaterialBudget, materialBudget)
            .SetProperty(u => u.AmountFinal, laborBudget + materialBudget))
            > 0;

        public async Task<bool> UpdateJobStateAsync
            (int id, EJobState jobState)
        {
            var newJobState = jobState == EJobState.ENPROCESO ?
                "EN PROCESO" : jobState.ToString();

            if (jobState == EJobState.COMPLETADO)
            {
                var job = await
                    (from jo in Context.Set<Job>()
                     join ag in Context.Set<Agenda>()
                     on jo.AgendasId equals ag.Id
                     join co in Context.Set<Consumer>()
                     on jo.ConsumersId equals co.Id
                     where jo.Id == id
                     select new Job
                     (
                         jo.Id,
                         jo.AgendasId,
                         jo.ConsumersId.ToString(),
                         jo.RegistrationDate,
                         jo.AnswerDate,
                         jo.WorkDate,
                         jo.Address,
                         jo.Description,
                         jo.Time ?? 0,
                         jo.LaborBudget ?? 0,
                         jo.MaterialBudget ?? 0,
                         Enum.Parse<EJobState>(jo.State.Replace(" ", "")),
                         new(ag.Technical),
                         co
                     )).FirstOrDefaultAsync();

                var result = await SendEmailWithCompleteState(job ?? new());

                if (result is false) return false;
            }

            return await Context.Set<Job>().Where(j => j.Id == id)
                .ExecuteUpdateAsync(j => j
                .SetProperty(u => u.State, newJobState)) > 0;
        }

        new public async Task<Job?> FindByIdAsync(int id) =>
            await (from jo in Context.Set<Job>()
                   join ag in Context.Set<Agenda>()
                   on jo.AgendasId equals ag.Id
                   join co in Context.Set<Consumer>()
                   on jo.ConsumersId equals co.Id
                   where jo.Id == id
                   select new Job
                   (
                      jo.Id,
                      jo.AgendasId,
                      jo.ConsumersId.ToString(),
                      jo.RegistrationDate,
                      jo.AnswerDate,
                      jo.WorkDate,
                      jo.Address,
                      jo.Description,
                      jo.Time ?? 0,
                      jo.LaborBudget ?? 0,
                      jo.MaterialBudget ?? 0,
                      Enum.Parse<EJobState>(jo.State.Replace(" ", "")),
                      new(ag.Technical),
                      co
                   )).AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<Job>> FindByTechnicalIdAsync
            (int technicalId) =>
            await (from jo in Context.Set<Job>()
                   join ag in Context.Set<Agenda>()
                   on jo.AgendasId equals ag.Id
                   join co in Context.Set<Consumer>()
                   on jo.ConsumersId equals co.Id
                   where ag.TechnicalsId == technicalId
                   select new Job
                   (
                      jo.Id,
                      jo.AgendasId,
                      jo.ConsumersId.ToString(),
                      jo.RegistrationDate,
                      jo.AnswerDate,
                      jo.WorkDate,
                      jo.Address,
                      jo.Description,
                      jo.Time ?? 0,
                      jo.LaborBudget ?? 0,
                      jo.MaterialBudget ?? 0,
                      Enum.Parse<EJobState>(jo.State.Replace(" ", "")),
                      new(ag.Technical),
                      co
                   )).AsNoTrackingWithIdentityResolution()
            .ToListAsync();

        public async Task<IEnumerable<Job>> FindByConsumerIdAsync
            (int consumerId) =>
            await (from jo in Context.Set<Job>()
                   join ag in Context.Set<Agenda>()
                   on jo.AgendasId equals ag.Id
                   join co in Context.Set<Consumer>()
                   on jo.ConsumersId equals co.Id
                   where jo.ConsumersId == consumerId
                   select new Job
                   (
                      jo.Id,
                      jo.AgendasId,
                      jo.ConsumersId.ToString(),
                      jo.RegistrationDate,
                      jo.AnswerDate,
                      jo.WorkDate,
                      jo.Address,
                      jo.Description,
                      jo.Time ?? 0,
                      jo.LaborBudget ?? 0,
                      jo.MaterialBudget ?? 0,
                      Enum.Parse<EJobState>(jo.State.Replace(" ", "")),
                      new(ag.Technical),
                      co
                   )).AsNoTrackingWithIdentityResolution()
            .ToListAsync();

        public async Task<IEnumerable<Job>> FindByTechnicalIdAndStateAsync
            (int technicalId, EJobState jobState)
        {
            var newJobState = jobState == EJobState.ENPROCESO ?
                "EN PROCESO" : jobState.ToString();

            return await (from jo in Context.Set<Job>()
                          join ag in Context.Set<Agenda>()
                          on jo.AgendasId equals ag.Id
                          join co in Context.Set<Consumer>()
                          on jo.ConsumersId equals co.Id
                          where jo.State == newJobState &&
                          ag.TechnicalsId == technicalId
                          select new Job
                          (
                             jo.Id,
                             jo.AgendasId,
                             jo.ConsumersId.ToString(),
                             jo.RegistrationDate,
                             jo.AnswerDate,
                             jo.WorkDate,
                             jo.Address,
                             jo.Description,
                             jo.Time ?? 0,
                             jo.LaborBudget ?? 0,
                             jo.MaterialBudget ?? 0,
                             Enum.Parse<EJobState>(jo.State.Replace(" ", "")),
                             new(ag.Technical),
                             co
                          )).AsNoTrackingWithIdentityResolution()
                          .ToListAsync();
        }

        public async Task<IEnumerable<Job>> FindByConsumerIdAndStateAsync
            (int consumerId, EJobState jobState)
        {
            var newJobState = jobState == EJobState.ENPROCESO ?
                "EN PROCESO" : jobState.ToString();

            return await (from jo in Context.Set<Job>()
                          join ag in Context.Set<Agenda>()
                          on jo.AgendasId equals ag.Id
                          join co in Context.Set<Consumer>()
                          on jo.ConsumersId equals co.Id
                          where jo.State == newJobState &&
                          jo.ConsumersId == consumerId
                          select new Job
                          (
                             jo.Id,
                             jo.AgendasId,
                             jo.ConsumersId.ToString(),
                             jo.RegistrationDate,
                             jo.AnswerDate,
                             jo.WorkDate,
                             jo.Address,
                             jo.Description,
                             jo.Time ?? 0,
                             jo.LaborBudget ?? 0,
                             jo.MaterialBudget ?? 0,
                             Enum.Parse<EJobState>(jo.State.Replace(" ", "")),
                             new(ag.Technical),
                             co
                          )).AsNoTrackingWithIdentityResolution()
                          .ToListAsync();
        }

        #region Email

        private static async Task<bool> SendEmailWithCompleteState(Job job)
        {
            try
            {
                byte[] pdfData = GenerateServiceTicket(job);

                if (pdfData.Length == 0)
                    return false;

                var attachment = new Attachment(new MemoryStream(pdfData), "Comprobante.pdf", "application/pdf");

                using var message = new MailMessage
                {
                    From = new MailAddress("smartassistance2025@gmail.com"),
                    Subject = "COMPROBANTE DE SERVICIO",
                    Body = $@"
                        <!DOCTYPE html>
                        <html lang='es-pe'>
                        <head>
                            <meta charset='UTF-8'>
                            <style>
                                body {{
                                    font-family: 'Segoe UI', sans-serif;
                                    background-color: #f7f7f7;
                                    color: #333;
                                    padding: 20px;
                                }}
                                .container {{
                                    background-color: #ffffff;
                                    border-radius: 8px;
                                    padding: 30px;
                                    max-width: 600px;
                                    margin: auto;
                                    box-shadow: 0 4px 8px rgba(0,0,0,0.1);
                                }}
                                h2 {{
                                    color: #2c3e50;
                                }}
                                .info {{
                                    margin-top: 20px;
                                    font-size: 15px;
                                }}
                                .info p {{
                                    margin: 6px 0;
                                }}
                                .footer {{
                                    margin-top: 30px;
                                    font-size: 13px;
                                    color: #777;
                                    text-align: center;
                                }}
                            </style>
                        </head>
                        <body>
                            <div class='container'>

                                <h2>Comprobante de Servicio</h2>
                                <p>Gracias por confiar en <strong>HelpTech</strong>. A continuación, encontrará un resumen del servicio técnico completado.</p>
                                
                                <div class='info'>
                                    <p><strong>Trabajo ID:</strong> {job.Id}</p>
                                    <p><strong>Fecha de Atención:</strong> {job.WorkDate:dd/MM/yyyy}</p>
                                    <p><strong>Técnico:</strong> {job.Agenda.Technical.Firstname} {job.Agenda.Technical.Lastname}</p>
                                    <p><strong>Cliente:</strong> {job.Consumer.Firstname} {job.Consumer.Lastname}</p>
                                    <p><strong>Dirección:</strong> {job.Address}</p>
                                    <p><strong>Descripción del Servicio:</strong> {job.Description}</p>
                                    <p><strong>Mano de Obra:</strong> S/. {job.LaborBudget}</p>
                                    <p><strong>Materiales:</strong> S/. {job.MaterialBudget}</p>
                                    <p><strong>Monto Total:</strong> S/. {job.AmountFinal:F2}</p>
                                </div>
                                
                                <p>Adjuntamos el comprobante en PDF para su respaldo.</p>
                                
                                <div class='footer'>
                                    Este correo ha sido enviado automáticamente por HelpTech. Por favor, no responda a este mensaje.
                                </div>
                            </div>
                        </body>
                        </html>",
                    IsBodyHtml = true
                };

                message.To.Add(job.Consumer.Email);
                message.Attachments.Add(attachment);

                using var smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("smartassistance2025@gmail.com", "proh yvnn krpi mhog"),
                    EnableSsl = true
                };

                await smtp.SendMailAsync(message);

                return true;
            }
            catch (Exception) { return false; }
        }
        private static byte[] GenerateServiceTicket(Job job)
        {
            using var stream = new MemoryStream();
            var document = new PdfDocument();
            var page = document.AddPage();
            page.Size = PdfSharpCore.PageSize.A4;

            var gfx = XGraphics.FromPdfPage(page);

            var titleFont = new XFont("Segoe UI", 18, XFontStyle.Bold);
            var headerFont = new XFont("Segoe UI", 12, XFontStyle.Bold);
            var textFont = new XFont("Segoe UI", 12, XFontStyle.Regular);
            var grayBrush = new XSolidBrush(XColors.DarkSlateGray);

            double y = 40;

            gfx.DrawString("Comprobante de Servicio", titleFont, grayBrush,
                new XRect(0, y, page.Width, 30), XStringFormats.TopCenter);
            y += 50;

            gfx.DrawLine(XPens.Gray, 40, y, page.Width - 40, y);
            y += 20;

            gfx.DrawString("Trabajo ID:", headerFont, XBrushes.Black, 40, y);
            gfx.DrawString(job.Id.ToString(), textFont, XBrushes.Black, 160, y);
            y += 25;

            gfx.DrawString("Fecha de atención:", headerFont, XBrushes.Black, 40, y);
            gfx.DrawString(job.WorkDate?.ToString("dd/MM/yyyy"), textFont, XBrushes.Black, 160, y);
            y += 25;

            gfx.DrawString("Técnico:", headerFont, XBrushes.Black, 40, y);
            gfx.DrawString(job.Agenda.Technical.Firstname + " " + job.Agenda.Technical.Lastname, textFont, XBrushes.Black, 160, y);
            y += 25;

            gfx.DrawString("Cliente:", headerFont, XBrushes.Black, 40, y);
            gfx.DrawString(job.Consumer.Firstname + " " + job.Consumer.Lastname, textFont, XBrushes.Black, 160, y);
            y += 25;

            gfx.DrawString("Dirección:", headerFont, XBrushes.Black, 40, y);
            gfx.DrawString(job.Address, textFont, XBrushes.Black, 160, y);
            y += 25;

            gfx.DrawString("Descripción:", headerFont, XBrushes.Black, 40, y);
            gfx.DrawString(job.Description, textFont, XBrushes.Black, 160, y);
            y += 25;

            gfx.DrawString("Mano de Obra:", headerFont, XBrushes.Black, 40, y);
            gfx.DrawString($"S/ {job.LaborBudget}", textFont, XBrushes.Black, 160, y);
            y += 25;

            gfx.DrawString("Materiales:", headerFont, XBrushes.Black, 40, y);
            gfx.DrawString($"S/ {job.MaterialBudget}", textFont, XBrushes.Black, 160, y);
            y += 25;

            gfx.DrawLine(XPens.LightGray, 40, y, page.Width - 40, y);
            y += 20;

            gfx.DrawString("Monto total:", headerFont, XBrushes.Black, 40, y);
            gfx.DrawString($"S/. {job.AmountFinal:F2}", new XFont("Segoe UI", 14, XFontStyle.Bold), XBrushes.DarkGreen, 160, y);
            y += 50;

            gfx.DrawString("Gracias por confiar en HelpTech", new XFont("Segoe UI", 12, XFontStyle.Italic), XBrushes.Gray, 40, y);

            document.Save(stream, false);

            return stream.ToArray();
        }

        #endregion
    }
}