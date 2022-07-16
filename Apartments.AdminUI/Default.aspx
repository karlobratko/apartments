<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Apartments.AdminUI.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

  <!-- BOOTSTRAP STYLE -->
  <link href="Content/bootstrap.min.css" rel="stylesheet" />

  <!-- INLINE STYLE -->
  <style>
    html,
    body {
      height: 100%;
    }

    body {
      display: flex;
      align-items: center;
      padding-top: 40px;
      padding-bottom: 40px;
      background-color: #f5f5f5;
    }

    .form-signin {
      width: 100%;
      max-width: 330px;
      padding: 15px;
      margin: auto;
    }

      .form-signin .checkbox {
        font-weight: 400;
      }

      .form-signin .form-floating:focus-within {
        z-index: 2;
      }

      .form-signin input[type="email"] {
        margin-bottom: -1px;
        border-bottom-right-radius: 0;
        border-bottom-left-radius: 0;
      }

      .form-signin input[type="password"] {
        margin-bottom: 10px;
        border-top-left-radius: 0;
        border-top-right-radius: 0;
      }

    .bd-placeholder-img {
      font-size: 1.125rem;
      text-anchor: middle;
      -webkit-user-select: none;
      -moz-user-select: none;
      user-select: none;
    }

    @media (min-width: 768px) {
      .bd-placeholder-img-lg {
        font-size: 3.5rem;
      }
    }
  </style>

  <title>Apartments</title>
</head>
<body class="text-center">
  <main class="form-signin">
    <form runat="server" id="loginForm">
      <h1 runat="server" meta:resourcekey="hTitle" class="h3 mb-3 fw-normal">Sign in</h1>

      <div class="form-floating">
        <asp:TextBox runat="server" ID="txtEmail" TextMode="Email" CssClass="form-control" MaxLength="256"></asp:TextBox>
        <asp:Label runat="server" meta:resourcekey="lblEmail" AssociatedControlID="txtEmail"></asp:Label>
        <asp:RequiredFieldValidator
          ID="rfvEmail"
          runat="server"
          ControlToValidate="txtEmail"
          Display="Dynamic"
          meta:resourcekey="rfvEmail"
          ForeColor="Red"></asp:RequiredFieldValidator>
      </div>
      <div class="form-floating">
        <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" MaxLength="100"></asp:TextBox>
        <asp:Label runat="server" meta:resourcekey="lblPassword" AssociatedControlID="txtPassword"></asp:Label>
        <asp:RequiredFieldValidator
          ID="rfvPassword"
          runat="server"
          ControlToValidate="txtPassword"
          Display="Dynamic"
          meta:resourcekey="rfvPassword"
          ForeColor="Red"></asp:RequiredFieldValidator>
      </div>

      <asp:Button runat="server" meta:resourcekey="btnLogin" class="w-100 btn btn-lg btn-warning" OnClick="LoginUser" CausesValidation="true" />
      <p class="mt-5 mb-3 text-muted">&copy; <%: DateTime.Now.Year %> Apartments, Inc</p>
    </form>
  </main>

  <!-- JQUERY SCRIPT -->
  <script src="Scripts/jquery-3.6.0.min.js"></script>
  <!-- BOOTSTRAP SCRIPT -->
  <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>
