using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;

using Apartments.BLL.Base.Helpers;

namespace Apartments.BLL.Helpers {
  public class EmailSender : IEmailSender {
    private readonly MailAddress _from;
    private readonly MailAddress _to;

    public EmailSender(String to) 
      : this(from: ConfigurationManager.AppSettings["Email.From.Email"],
             to: to) {
    }

    public EmailSender(MailAddress to)
      : this(from: new MailAddress(ConfigurationManager.AppSettings["Email.From.Email"]),
             to: to) {
    }

    public EmailSender(String from, String to)
      : this(from: new MailAddress(from),
             to: new MailAddress(to)) {
    }

    public EmailSender(MailAddress from, MailAddress to) {
      _from = from;
      _to = to;
    }

    public void SendEmail(String subject, String body) {
      using (var message = new MailMessage(_from, _to) {
        Subject = subject,
        Body = body,
        IsBodyHtml = true
      })
      using (var smtpClient = new SmtpClient()) {
        smtpClient.Host = ConfigurationManager.AppSettings["Email.SmtpClient.Host"];
        smtpClient.Port = Int32.Parse(ConfigurationManager.AppSettings["Email.SmtpClient.Port"]);
        smtpClient.EnableSsl = true;
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpClient.Credentials = new NetworkCredential(userName: ConfigurationManager.AppSettings["Email.SmtpClient.Credentials.Username"],
                                                       password: ConfigurationManager.AppSettings["Email.SmtpClient.Credentials.Password"]);
        smtpClient.Send(message);
      }
    }
  }
}
