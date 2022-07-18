<%@ Page Title="Tags" Language="C#" MasterPageFile="~/Site.Desktop.Master" AutoEventWireup="true" CodeBehind="Tags.aspx.cs" Inherits="Apartments.AdminUI.Tags" %>

<asp:Content ID="contHead" ContentPlaceHolderID="cphSiteDesktopMasterHead" runat="server">
</asp:Content>

<asp:Content ID="contBody" ContentPlaceHolderID="cphSiteDesktopMasterBody" runat="server">
  <div class="container">
    <div class="row d-flex justify-content-between">
      <div class="col-6 col-lg-4">
      </div>
      <div class="col-6 col-lg-4 d-flex justify-content-end">
        <asp:Button CssClass="btn btn-outline-warning" runat="server" meta:resourcekey="btnCreate" OnClick="CreateTag" />
      </div>
    </div>
  </div>

  <div class="container">

    <asp:GridView
      runat="server"
      ID="gvTags"
      CssClass="table mt-4"
      ItemType="Apartments.AdminUI.Projections.TagProjection"
      DataKeyNames="Id"
      AutoGenerateColumns="false"
      AllowSorting="true"
      HeaderStyle-ForeColor="Black"
      OnSorting="SortByColumn"
      OnRowDataBound="DisableDeleteForUsedTags">
      <Columns>
        <asp:BoundField DataField="Id" meta:resourcekey="gvbfId" ReadOnly="True" SortExpression="Id" />
        <asp:BoundField meta:resourcekey="gvbfName" />
        <asp:BoundField meta:resourcekey="gvbfTypeName" />
        <asp:BoundField DataField="ApartmentCount" meta:resourcekey="gvbfApartmentCount" SortExpression="ApartmentCount" />
        <asp:TemplateField>
          <ItemTemplate>
            <asp:Button ID="btnDelete" CssClass="btn btn-outline-danger" runat="server" meta:resourcekey="btnDelete" CommandArgument='<%# Eval("Guid") %>' OnClick="DeleteTag" />
          </ItemTemplate>
        </asp:TemplateField>
      </Columns>
    </asp:GridView>

    <asp:Panel runat="server" ID="pnlCreate" CssClass="modal d-block bg-black bg-opacity-50" Visible="false">

      <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
          <div class="modal-header">
            <h5 runat="server" meta:resourcekey="hCreateTag" class="modal-title"></h5>
            <asp:Button runat="server" CssClass="btn-close" CausesValidation="false" OnClick="CancelCreateTag" />
          </div>
          <div class="modal-body">
            <div class="row">
              <div class="col">
                <div class="form-floating mb-3">
                  <asp:TextBox runat="server" ID="txtCreateNameCro" CssClass="form-control" MaxLength="250"></asp:TextBox>
                  <asp:Label runat="server" meta:resourcekey="lblCreateNameCro" AssociatedControlID="txtCreateNameCro"></asp:Label>
                  <asp:RequiredFieldValidator
                    ID="rfvCreateNameCro"
                    runat="server"
                    ControlToValidate="txtCreateNameCro"
                    Display="Dynamic"
                    meta:resourcekey="rfvCreateNameCro"
                    ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="form-floating mb-3">
                  <asp:TextBox runat="server" ID="txtCreateNameEng" CssClass="form-control" MaxLength="250"></asp:TextBox>
                  <asp:Label runat="server" meta:resourcekey="lblCreateNameEng" AssociatedControlID="txtCreateNameEng"></asp:Label>
                  <asp:RequiredFieldValidator
                    ID="rfvCreateNameEng"
                    runat="server"
                    ControlToValidate="txtCreateNameEng"
                    Display="Dynamic"
                    meta:resourcekey="rfvCreateNameEng"
                    ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="form-floating mb-3">
                  <asp:DropDownList runat="server" ID="ddlCreateType" CssClass="form-select">
                  </asp:DropDownList>
                  <asp:Label runat="server" meta:resourcekey="lblCreateType" AssociatedControlID="ddlCreateType"></asp:Label>
                  <asp:RequiredFieldValidator
                    ID="rfvCreateType"
                    InitialValue="-1"
                    runat="server"
                    ControlToValidate="ddlCreateType"
                    Display="Dynamic"
                    meta:resourcekey="rfvCreateType"
                    ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
              </div>
            </div>
          </div>
          <div class="modal-footer flex-row">
            <asp:Button meta:resourcekey="btnCancelCreate" runat="server" CssClass="btn btn-outline-secondary" CausesValidation="false" OnClick="CancelCreateTag" />
            <asp:Button meta:resourcekey="btnSubmitCreate" runat="server" CssClass="btn btn-warning" CausesValidation="true" OnClick="SubmitCreateTag" />
          </div>
        </div>
      </div>

    </asp:Panel>

    <asp:Panel runat="server" ID="pnlDelete" CssClass="modal d-block bg-black bg-opacity-50" Visible="false">

      <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content rounded-4 shadow">
          <div class="modal-body p-4 text-center">
            <h5 runat="server" class="mb-2" meta:resourcekey="hDeleteTag"></h5>
            <p runat="server" class="mb-0" meta:resourcekey="pDeleteTag"></p>
          </div>
          <asp:TextBox runat="server" Visible="false" TextMode="Number" ID="txtDeleteTagId"></asp:TextBox>
          <div class="modal-footer flex-nowrap p-0">
            <asp:Button meta:resourcekey="btnSubmitDelete" runat="server" CssClass="btn btn-lg btn-link link-danger fs-6 text-decoration-none col-6 m-0 rounded-0 border-right" CausesValidation="false" OnClick="SubmitDeleteTag" />
            <asp:Button meta:resourcekey="btnCancelDelete" runat="server" CssClass="btn btn-lg btn-link link-secondary fs-6 text-decoration-none col-6 m-0 rounded-0" CausesValidation="false" OnClick="CancelDeleteTag" />
          </div>
        </div>
      </div>

    </asp:Panel>

  </div>
</asp:Content>
