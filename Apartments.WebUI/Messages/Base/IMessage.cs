using System;

using Apartments.WebUI.Messages.Enums;

namespace Apartments.WebUI.Messages.Base {
  public interface IMessage {
    String Message { get; }
    MessageType Type { get; }
    String Icon { get; }
    String Color { get; }
  }
}
