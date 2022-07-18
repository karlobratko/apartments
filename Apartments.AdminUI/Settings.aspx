<%@ Page Title="Settings" Language="C#" MasterPageFile="~/Site.Desktop.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="Apartments.AdminUI.Settings" %>

<asp:Content ID="contHead" ContentPlaceHolderID="cphSiteDesktopMasterHead" runat="server">
</asp:Content>
<asp:Content ID="contBody" ContentPlaceHolderID="cphSiteDesktopMasterBody" runat="server">

  <div class="container bg-light border rounded p-4">

    <div class="row align-items-start justify-content-center">

      <div class="col-3 d-flex justify-content-center">
        <div class="w-100">
          <asp:Label runat="server" ID="lblTheme" meta:resourcekey="lblTheme" CssClass="form-check-label" Text="Theme:" for="ddlTheme"></asp:Label>
          <asp:DropDownList runat="server" AutoPostBack="true" ID="ddlTheme" CssClass="form-select" OnSelectedIndexChanged="ddlTheme_SelectedIndexChanged">
            <asp:ListItem meta:resourcekey="liLight" Value="LightTheme" Text="Light" />
            <asp:ListItem meta:resourcekey="liDark" Value="DarkTheme" Text="Dark" />
          </asp:DropDownList>
        </div>
      </div>

      <div class="col-3 d-flex justify-content-center">
        <div class="w-100">
          <asp:Label runat="server" ID="lblLang" meta:resourcekey="lblLang" CssClass="form-check-label" for="ddlLang"></asp:Label>
          <asp:DropDownList runat="server" ID="ddlLang" AutoPostBack="true" CssClass="form-select" OnSelectedIndexChanged="ddlLang_SelectedIndexChanged">
            <asp:ListItem meta:resourcekey="liEng" Value="en" />
            <asp:ListItem meta:resourcekey="liCro" Value="hr" />
          </asp:DropDownList>
        </div>
      </div>

    </div>

  </div>

</asp:Content>
