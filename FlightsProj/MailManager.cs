using System;
using System.Net.Mail;

namespace FlightsProj
{
    public class MailManager : IDisposable
    {
        private readonly SmtpClient _smtpClient;

        public MailManager(string gmailFromTextBox, string gmailPasswordTextBox)
        {
            _smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(gmailFromTextBox, gmailPasswordTextBox),
                Port = 587,
                EnableSsl = true
            };
        }

        public void SendMessage(string gmailFromTextBox, string gmailToTextBox, string attachementPathTextBox)
        {
            MailMessage flightsMessage = new MailMessage(gmailFromTextBox, gmailToTextBox, "Flights", DateTime.Now.ToShortDateString() + "\t" + DateTime.Now.ToShortTimeString());

            //Attachement
            Attachment flightsTextFile = new Attachment(attachementPathTextBox);
            flightsMessage.Attachments.Add(flightsTextFile);

            //Sending
            _smtpClient.Send(flightsMessage);

            flightsMessage.Dispose();
            flightsTextFile.Dispose();
        }

        public void Dispose()
        {
            _smtpClient.Dispose();
        }
    }
}
