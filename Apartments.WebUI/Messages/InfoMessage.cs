using System;

using Apartments.WebUI.Messages.Base;
using Apartments.WebUI.Messages.Enums;

namespace Apartments.WebUI.Messages {
  public class InfoMessage : BaseMessage {

    #region Constants

    private const MessageType TYPE = MessageType.Info;
    private const String ICON = "info-circle";
    private const String COLOR = "primary";

    #endregion

    #region Constructors

    public InfoMessage(String message) : base(message, TYPE, ICON, COLOR) {
    }

    #endregion

  }
}