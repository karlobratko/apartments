using System;

using Apartments.WebUI.Messages.Base;
using Apartments.WebUI.Messages.Enums;

namespace Apartments.WebUI.Messages {
  public class DangerMessage : BaseMessage {

    #region Constants

    private const MessageType TYPE = MessageType.Danger;
    private const String ICON = "exclamation-triangle";
    private const String COLOR = "danger";

    #endregion

    #region Constructors

    public DangerMessage(String message) : base(message, TYPE, ICON, COLOR) {
    }

    #endregion

  }
}