using System;

using Apartments.WebUI.Messages.Enums;

namespace Apartments.WebUI.Messages.Base {
  public class BaseMessage : IMessage {

    #region Constructors

    public BaseMessage(String message, MessageType type, String icon, String color) {
      Message = message;
      Type = type;
      Icon = icon;
      Color = color;
    }

    #endregion

    #region Public Methods

    public String Message { get; }
    public MessageType Type { get; }
    public String Icon { get; }
    public String Color { get; }

    #endregion

  }
}