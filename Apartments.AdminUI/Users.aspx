<%@ Page Title="Users" Language="C#" MasterPageFile="~/Site.Desktop.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Apartments.AdminUI.Users" %>

<asp:Content ID="contHead" ContentPlaceHolderID="cphSiteDesktopMasterHead" runat="server">
</asp:Content>

<asp:Content ID="contBody" ContentPlaceHolderID="cphSiteDesktopMasterBody" runat="server">
  <div class="container">

    <asp:GridView
      runat="server"
      ID="gvUsers"
      CssClass="table mt-4"
      ItemType="RWA_Library.Model.User"
      DataKeyNames="Id"
      AutoGenerateColumns="false"
      AllowSorting="true"
      HeaderStyle-ForeColor="Black"
      OnSorting="SortByColumn">
      <Columns>
        <asp:BoundField DataField="Id" meta:resourcekey="gvbfId" ReadOnly="True" SortExpression="Id" />
        <asp:BoundField DataField="Username" meta:resourcekey="gvbfUserName" SortExpression="UserName" />
        <asp:BoundField DataField="Email" meta:resourcekey="gvbfEmail" SortExpression="Email" />
        <asp:BoundField DataField="PhoneNumber" meta:resourcekey="gvbfPhoneNumber" SortExpression="PhoneNumber" />
        <asp:BoundField DataField="Address" meta:resourcekey="gvbfAddress" SortExpression="Address" />
      </Columns>
    </asp:GridView>

  </div>
</asp:Content>
