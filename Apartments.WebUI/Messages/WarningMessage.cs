using System;

using Apartments.WebUI.Messages.Base;
using Apartments.WebUI.Messages.Enums;

namespace Apartments.WebUI.Messages {
  public class WarningMessage : BaseMessage {

    #region Constants

    private const MessageType TYPE = MessageType.Warning;
    private const String ICON = "exclamation-triangle";
    private const String COLOR = "warning";

    #endregion

    #region Constructors

    public WarningMessage(String message) : base(message, TYPE, ICON, COLOR) {
    }

    #endregion

  }
}