using System;

namespace Apartments.BLL.Base.Helpers {
  public interface IEmailSender {

    void SendEmail(String subject, String body);

  }
}
