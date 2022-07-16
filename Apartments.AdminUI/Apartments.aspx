<%@ Page Title="Apartments" Language="C#" MasterPageFile="~/Site.Desktop.Master" AutoEventWireup="true" CodeBehind="Apartments.aspx.cs" Inherits="Apartments.AdminUI.Apartments" %>

<asp:Content ID="contHead" ContentPlaceHolderID="cphSiteDesktopMasterHead" runat="server">
</asp:Content>

<asp:Content ID="contBody" ContentPlaceHolderID="cphSiteDesktopMasterBody" runat="server">
  <div class="container">
    <div class="row d-flex justify-content-between">
      <div class="col-6 col-lg-4">
        <div class="form-floating mb-3">
          <asp:DropDownList runat="server" ID="ddlStatus" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ReloadGridView">
          </asp:DropDownList>
          <asp:Label runat="server" meta:resourcekey="lblStatus" AssociatedControlID="ddlStatus"></asp:Label>
        </div>
      </div>
      <div class="col-6 col-lg-4">
        <div class="form-floating mb-3">
          <asp:DropDownList runat="server" ID="ddlSort" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ReloadGridView">
            <asp:ListItem meta:resourcekey="liDefaultSort" Selected="True" Value="Id"></asp:ListItem>
            <asp:ListItem meta:resourcekey="liName"></asp:ListItem>
            <asp:ListItem meta:resourcekey="liCity" Value="City"></asp:ListItem>
            <asp:ListItem meta:resourcekey="liAddress" Value="Address"></asp:ListItem>
            <asp:ListItem meta:resourcekey="liMaxAdults" Value="MaxAdults"></asp:ListItem>
            <asp:ListItem meta:resourcekey="liMaxChildren" Value="MaxChildren"></asp:ListItem>
            <asp:ListItem meta:resourcekey="liTotalRooms" Value="TotalRooms"></asp:ListItem>
            <asp:ListItem meta:resourcekey="liPictures" Value="PicturesCount"></asp:ListItem>
            <asp:ListItem meta:resourcekey="liBeachDistance" Value="BeachDistance"></asp:ListItem>
            <asp:ListItem meta:resourcekey="liPrice" Value="Price"></asp:ListItem>
          </asp:DropDownList>
          <asp:Label runat="server" meta:resourcekey="lblSort" AssociatedControlID="ddlSort"></asp:Label>
        </div>
      </div>
    </div>
    <div class="row d-flex justify-content-between">
      <div class="col-6 col-lg-4 mb-3">
        <div class="form-floating">
          <asp:DropDownList runat="server" ID="ddlCity" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ReloadGridView">
          </asp:DropDownList>
          <asp:Label runat="server" meta:resourcekey="lblCity" AssociatedControlID="ddlCity"></asp:Label>
        </div>
      </div>
      <div class="col-6 col-lg-4 mb-3">
        <div class="form-floating">
          <asp:DropDownList runat="server" ID="ddlOrder" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ReloadGridView">
            <asp:ListItem meta:resourcekey="liOrderAsc" Selected="True" Value="Ascending"></asp:ListItem>
            <asp:ListItem meta:resourcekey="liOrderDesc" Value="Descending"></asp:ListItem>
          </asp:DropDownList>
          <asp:Label runat="server" meta:resourcekey="lblOrder" AssociatedControlID="ddlOrder"></asp:Label>
        </div>
      </div>
    </div>
    <div class="row d-flex justify-content-between">
      <div class="col-6 col-lg-4">
      </div>
      <div class="col-6 col-lg-4 d-flex justify-content-end">
        <asp:Button ID="btnCreate" CssClass="btn btn-outline-warning" runat="server" meta:resourcekey="btnCreate" OnClick="OpenCreateModal" />
      </div>
    </div>
  </div>
  <div class="container">

    <asp:GridView
      runat="server"
      ID="gvApartments"
      CssClass="table mt-4"
      ItemType="Apartments.AdminUI.Projections.ApartmentProjection"
      DataKeyNames="Id"
      AutoGenerateColumns="false"
      AllowSorting="true"
      HeaderStyle-ForeColor="Black"
      OnSorting="SortByColumn">
      <Columns>
        <asp:BoundField DataField="Id" meta:resourcekey="gvbfId" ReadOnly="True" SortExpression="Id" />
        <asp:BoundField meta:resourcekey="gvbfName" />
        <asp:BoundField DataField="City" meta:resourcekey="gvbfCity" SortExpression="City" />
        <asp:BoundField DataField="Address" meta:resourcekey="gvbfAddress" SortExpression="Address" />
        <asp:BoundField DataField="MaxAdults" meta:resourcekey="gvbfMaxAdults" SortExpression="MaxAdults" />
        <asp:BoundField DataField="MaxChildren" meta:resourcekey="gvbfMaxChildren" SortExpression="MaxChildren" />
        <asp:BoundField DataField="TotalRooms" meta:resourcekey="gvbfTotalRooms" SortExpression="TotalRooms" />
        <asp:BoundField DataField="PicturesCount" meta:resourcekey="gvbfPictures" SortExpression="Pictures" />
        <asp:BoundField DataField="BeachDistance" meta:resourcekey="gvbfBeachDistance" SortExpression="BeachDistance" />
        <asp:BoundField DataField="Price" meta:resourcekey="gvbfPrice" DataFormatString="{0:C}" SortExpression="Price" />
        <asp:TemplateField>
          <ItemTemplate>
            <asp:Button ID="btnEdit" CssClass="btn btn-warning" runat="server" meta:resourcekey="btnEdit" CommandArgument='<%# Eval("Id") %>' OnClick="OpenEditModal" />
            <asp:Button ID="btnDelete" CssClass="btn btn-outline-danger" runat="server" meta:resourcekey="btnDelete" CommandArgument='<%# Eval("Guid") %>' OnClick="OpenDeleteModal" />
          </ItemTemplate>
        </asp:TemplateField>
      </Columns>
    </asp:GridView>

    <asp:Panel runat="server" ID="pnlCreate" CssClass="modal d-block bg-black bg-opacity-50" Visible="false">

      <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
          <div class="modal-header">
            <h5 runat="server" meta:resourcekey="hCreateApartment" class="modal-title"></h5>
            <asp:Button runat="server" CssClass="btn-close" CausesValidation="false" OnClick="CloseCreateModal" />
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
                  <asp:DropDownList runat="server" ID="ddlCreateOwner" CssClass="form-select">
                  </asp:DropDownList>
                  <asp:Label runat="server" meta:resourcekey="lblOwner" AssociatedControlID="ddlCreateOwner"></asp:Label>
                  <asp:RequiredFieldValidator
                    ID="rfvCreateOwner"
                    InitialValue="-1"
                    runat="server"
                    ControlToValidate="ddlCreateCity"
                    Display="Dynamic"
                    meta:resourcekey="rfvCreateOwner"
                    ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="form-floating mb-3">
                  <asp:DropDownList runat="server" ID="ddlCreateCity" CssClass="form-select">
                    <asp:ListItem meta:resourcekey="liDefaultCity" Selected="True" Value="-1"></asp:ListItem>
                  </asp:DropDownList>
                  <asp:Label runat="server" meta:resourcekey="lblCity" AssociatedControlID="ddlCreateCity"></asp:Label>
                  <asp:RequiredFieldValidator
                    ID="rfvCreateCity"
                    InitialValue="-1"
                    runat="server"
                    ControlToValidate="ddlCreateCity"
                    Display="Dynamic"
                    meta:resourcekey="rfvCreateCity"
                    ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="form-floating mb-3">
                  <asp:TextBox runat="server" ID="txtCreateAddress" CssClass="form-control" MaxLength="250"></asp:TextBox>
                  <asp:Label runat="server" meta:resourcekey="lblAddress" AssociatedControlID="txtCreateAddress"></asp:Label>
                  <asp:RequiredFieldValidator
                    ID="rfvCreateAddress"
                    runat="server"
                    ControlToValidate="txtCreateAddress"
                    Display="Dynamic"
                    meta:resourcekey="rfvCreateAddress"
                    ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="form-floating mb-3">
                  <asp:TextBox runat="server" ID="txtCreateMaxAdults" Text="1" TextMode="Number" CssClass="form-control"></asp:TextBox>
                  <asp:Label runat="server" meta:resourcekey="lblMaxAdults" AssociatedControlID="txtCreateMaxAdults"></asp:Label>
                  <asp:RangeValidator
                    runat="server"
                    ID="rvCreateMaxAdults"
                    ControlToValidate="txtCreateMaxAdults"
                    Display="Dynamic"
                    MaximumValue="10"
                    MinimumValue="1"
                    Type="Integer"
                    meta:resourcekey="rvCreateMaxAdults"
                    ForeColor="Red"></asp:RangeValidator>
                  <asp:RequiredFieldValidator
                    ID="rfvCreateMaxAdults"
                    runat="server"
                    ControlToValidate="txtCreateMaxAdults"
                    Display="Dynamic"
                    meta:resourcekey="rfvCreateMaxAdults"
                    ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="form-floating mb-3">
                  <asp:TextBox runat="server" ID="txtCreateMaxChildren" Text="1" TextMode="Number" CssClass="form-control"></asp:TextBox>
                  <asp:Label runat="server" meta:resourcekey="lblMaxChildren" AssociatedControlID="txtCreateMaxChildren"></asp:Label>
                  <asp:RangeValidator
                    runat="server"
                    ID="rvCreateMaxChildren"
                    ControlToValidate="txtCreateMaxChildren"
                    Display="Dynamic"
                    MaximumValue="10"
                    MinimumValue="1"
                    Type="Integer"
                    meta:resourcekey="rvCreateMaxChildren"
                    ForeColor="Red"></asp:RangeValidator>
                  <asp:RequiredFieldValidator
                    ID="rfvCreateMaxChildren"
                    runat="server"
                    ControlToValidate="txtCreateMaxChildren"
                    Display="Dynamic"
                    meta:resourcekey="rfvCreateMaxChildren"
                    ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="form-floating mb-3">
                  <asp:TextBox runat="server" ID="txtCreateTotalRooms" Text="1" TextMode="Number" CssClass="form-control"></asp:TextBox>
                  <asp:Label runat="server" meta:resourcekey="lblTotalRooms" AssociatedControlID="txtCreateTotalRooms"></asp:Label>
                  <asp:RangeValidator
                    runat="server"
                    ID="rvCreateTotalRooms"
                    ControlToValidate="txtCreateTotalRooms"
                    Display="Dynamic"
                    MaximumValue="1000"
                    MinimumValue="1"
                    Type="Integer"
                    meta:resourcekey="rvCreateTotalRooms"
                    ForeColor="Red"></asp:RangeValidator>
                  <asp:RequiredFieldValidator
                    ID="rfvCreateTotalRooms"
                    runat="server"
                    ControlToValidate="txtCreateTotalRooms"
                    Display="Dynamic"
                    meta:resourcekey="rfvCreateTotalRooms"
                    ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="form-floating mb-3">
                  <asp:TextBox runat="server" ID="txtCreateBeachDistance" Text="1" TextMode="Number" CssClass="form-control"></asp:TextBox>
                  <asp:Label runat="server" meta:resourcekey="lblBeachDistance" AssociatedControlID="txtCreateBeachDistance"></asp:Label>
                  <asp:RangeValidator
                    runat="server"
                    ID="rvCreateBeachDistance"
                    ControlToValidate="txtCreateBeachDistance"
                    Display="Dynamic"
                    MaximumValue="10000"
                    MinimumValue="1"
                    Type="Integer"
                    meta:resourcekey="rvCreateBeachDistance"
                    ForeColor="Red"></asp:RangeValidator>
                  <asp:RequiredFieldValidator
                    ID="rfvCreateBeachDistance"
                    runat="server"
                    ControlToValidate="txtCreateBeachDistance"
                    Display="Dynamic"
                    meta:resourcekey="rfvCreateBeachDistance"
                    ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="form-floating mb-3">
                  <asp:TextBox runat="server" ID="txtCreatePrice" CssClass="form-control"></asp:TextBox>
                  <asp:Label runat="server" meta:resourcekey="lblPrice" AssociatedControlID="txtCreatePrice"></asp:Label>
                  <asp:RangeValidator
                    runat="server"
                    ID="rvCreatePrice"
                    ControlToValidate="txtCreatePrice"
                    Display="Dynamic"
                    MaximumValue="10000"
                    MinimumValue="1"
                    Type="Double"
                    meta:resourcekey="rvCreatePrice"
                    ForeColor="Red"></asp:RangeValidator>
                  <asp:RequiredFieldValidator
                    ID="rfvCreatePrice"
                    runat="server"
                    ControlToValidate="txtCreatePrice"
                    Display="Dynamic"
                    meta:resourcekey="rfvCreatePrice"
                    ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
              </div>
            </div>
          </div>
          <div class="modal-footer flex-row">
            <asp:Button meta:resourcekey="btnCancel" runat="server" CssClass="btn btn-outline-secondary" CausesValidation="false" OnClick="CloseCreateModal" />
            <asp:Button meta:resourcekey="btnSubmit" runat="server" CssClass="btn btn-warning" CausesValidation="true" OnClick="SubmitCreate" />
          </div>
        </div>
      </div>

    </asp:Panel>

    <asp:Panel runat="server" ID="pnlEdit" CssClass="modal d-block bg-black bg-opacity-50" Visible="false">

      <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
          <div class="modal-header">
            <h5 runat="server" meta:resourcekey="hUpdateApartment" class="modal-title"></h5>
            <asp:Button runat="server" CssClass="btn-close" CausesValidation="false" OnClick="CloseEditModal" />
          </div>
          <div class="modal-body">
            <div class="row">
              <div class="col">
                <div class="form-floating mb-3">
                  <asp:TextBox runat="server" ID="txtEditName" CssClass="form-control" MaxLength="250"></asp:TextBox>
                  <asp:Label runat="server" meta:resourcekey="lblName" AssociatedControlID="txtEditName"></asp:Label>
                </div>
                <div class="form-floating mb-3">
                  <asp:TextBox runat="server" ID="txtEditNameEng" CssClass="form-control" MaxLength="250"></asp:TextBox>
                  <asp:Label runat="server" meta:resourcekey="lblNameEng" AssociatedControlID="txtEditNameEng"></asp:Label>
                </div>
                <div class="form-floating mb-3">
                  <asp:DropDownList runat="server" ID="ddlEditCity" CssClass="form-select"></asp:DropDownList>
                  <asp:Label runat="server" meta:resourcekey="lblCity" AssociatedControlID="ddlEditCity"></asp:Label>
                </div>
                <div class="form-floating mb-3">
                  <asp:TextBox runat="server" ID="txtEditAddress" CssClass="form-control" MaxLength="250"></asp:TextBox>
                  <asp:Label runat="server" meta:resourcekey="lblAddress" AssociatedControlID="txtEditAddress"></asp:Label>
                </div>
                <div class="form-floating mb-3">
                  <asp:TextBox runat="server" ID="txtEditMaxAdults" TextMode="Number" CssClass="form-control"></asp:TextBox>
                  <asp:Label runat="server" meta:resourcekey="lblMaxAdults" AssociatedControlID="txtEditMaxAdults"></asp:Label>
                  <asp:RangeValidator
                    runat="server"
                    ID="rvEditMaxAdults"
                    ControlToValidate="txtEditMaxAdults"
                    Display="Dynamic"
                    MaximumValue="10"
                    MinimumValue="1"
                    Type="Integer"
                    meta:resourcekey="rvEditMaxAdults"
                    ForeColor="Red"></asp:RangeValidator>
                </div>
                <div class="form-floating mb-3">
                  <asp:TextBox runat="server" ID="txtEditMaxChildren" TextMode="Number" CssClass="form-control"></asp:TextBox>
                  <asp:Label runat="server" meta:resourcekey="lblMaxChildren" AssociatedControlID="txtEditMaxChildren"></asp:Label>
                  <asp:RangeValidator
                    runat="server"
                    ID="rvEditMaxChildren"
                    ControlToValidate="txtEditMaxChildren"
                    Display="Dynamic"
                    MaximumValue="10"
                    MinimumValue="1"
                    Type="Integer"
                    meta:resourcekey="rvEditMaxChildren"
                    ForeColor="Red"></asp:RangeValidator>
                </div>
                <div class="form-floating mb-3">
                  <asp:TextBox runat="server" ID="txtEditTotalRooms" TextMode="Number" CssClass="form-control"></asp:TextBox>
                  <asp:Label runat="server" meta:resourcekey="lblTotalRooms" AssociatedControlID="txtEditTotalRooms"></asp:Label>
                  <asp:RangeValidator
                    runat="server"
                    ID="rvEditTotalRooms"
                    ControlToValidate="txtEditTotalRooms"
                    Display="Dynamic"
                    MaximumValue="1000"
                    MinimumValue="1"
                    Type="Integer"
                    meta:resourcekey="rvEditTotalRooms"
                    ForeColor="Red"></asp:RangeValidator>
                </div>
                <div class="form-floating mb-3">
                  <asp:TextBox runat="server" ID="txtEditBeachDistance" TextMode="Number" CssClass="form-control"></asp:TextBox>
                  <asp:Label runat="server" meta:resourcekey="lblBeachDistance" AssociatedControlID="txtEditBeachDistance"></asp:Label>
                  <asp:RangeValidator
                    runat="server"
                    ID="rvEditBeachDistance"
                    ControlToValidate="txtEditBeachDistance"
                    Display="Dynamic"
                    MaximumValue="10000"
                    MinimumValue="1"
                    Type="Integer"
                    meta:resourcekey="rvEditBeachDistance"
                    ForeColor="Red"></asp:RangeValidator>
                </div>
                <div class="form-floating mb-3">
                  <asp:TextBox runat="server" ID="txtEditPrice" CssClass="form-control"></asp:TextBox>
                  <asp:Label runat="server" meta:resourcekey="lblPrice" AssociatedControlID="txtEditPrice"></asp:Label>
                  <asp:RangeValidator
                    runat="server"
                    ID="rvEditPrice"
                    ControlToValidate="txtEditPrice"
                    Display="Dynamic"
                    MaximumValue="10000"
                    MinimumValue="1"
                    Type="Double"
                    meta:resourcekey="rvEditPrice"
                    ForeColor="Red"></asp:RangeValidator>
                </div>
              </div>
            </div>
          </div>
          <div class="modal-footer flex-row">
            <asp:Button ID="btnTags" CssClass="btn btn-outline-warning" runat="server" meta:resourcekey="btnTag" CausesValidation="false" OnClick="OpenTagsModal" />
            <asp:Button ID="btnPictures" CssClass="btn btn-outline-warning" runat="server" meta:resourcekey="btnPictures" CausesValidation="false" OnClick="OpenPicturesModal" />
            <asp:Button ID="btnStatus" CssClass="btn btn-outline-warning me-auto" runat="server" meta:resourcekey="btnStatus" CausesValidation="false" OnClick="OpenStatusModal" />
            <asp:Button ID="btnCancel" meta:resourcekey="btnCancel" runat="server" CssClass="btn btn-outline-secondary" CausesValidation="false" OnClick="CloseEditModal" />
            <asp:Button ID="btnSubmit" meta:resourcekey="btnSubmit" runat="server" CssClass="btn btn-warning" CausesValidation="true" OnClick="SubmitEdit" />
          </div>
        </div>
      </div>

    </asp:Panel>

    <asp:Panel runat="server" ID="pnlTags" CssClass="modal d-block bg-black bg-opacity-50" Visible="false">

      <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
          <div class="modal-header">
            <h5 runat="server" meta:resourcekey="hTagApartment" class="modal-title"></h5>
            <asp:Button runat="server" CssClass="btn-close" CausesValidation="false" OnClick="ReturnToEditModal" />
          </div>
          <div class="modal-body">
            <div class="form-floating">
              <asp:DropDownList runat="server" ID="ddlTags" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="AssignTag">
                <asp:ListItem meta:resourcekey="liDefaultTag" Selected="True" Value="-1"></asp:ListItem>
              </asp:DropDownList>
              <asp:Label runat="server" meta:resourcekey="lblTags" AssociatedControlID="ddlTags"></asp:Label>
            </div>
            <asp:Repeater ID="rpTags" runat="server" OnItemCommand="UnassignTag">
              <HeaderTemplate>
                <div class="container d-flex flex-wrap gap-1 mt-3">
              </HeaderTemplate>
              <ItemTemplate>
                <asp:LinkButton
                  runat="server"
                  ID="lbRemove"
                  CommandName="Remove"
                  CommandArgument='<%# Eval("Guid") %>'
                  CssClass="btn btn-warning rounded-pill"
                  Font-Underline="false"
                  ForeColor="Black"
                  Text='<%# Eval("Name") %>'></asp:LinkButton>
              </ItemTemplate>
              <FooterTemplate>
                </div>
              </FooterTemplate>
            </asp:Repeater>
          </div>
          <div class="modal-footer flex-row">
            <asp:Button meta:resourcekey="btnBack" runat="server" CssClass="btn btn-outline-secondary" CausesValidation="false" OnClick="ReturnToEditModal" />
          </div>
        </div>
      </div>
    </asp:Panel>

    <asp:Panel runat="server" ID="pnlAddPictures" CssClass="modal d-block bg-black bg-opacity-50" Visible="false">

      <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
          <div class="modal-header">
            <h5 runat="server" meta:resourcekey="hApartmentPictures" class="modal-title"></h5>
            <asp:Button runat="server" CssClass="btn-close" CausesValidation="false" OnClick="BackToPicturesModal" />
          </div>
          <div class="modal-body d-flex flex-column">
            <div class="container mt-3">
              <div class="form-floating">
                <asp:TextBox runat="server" ID="txtPictureName" CssClass="form-control" MaxLength="250"></asp:TextBox>
                <asp:Label runat="server" meta:resourcekey="lblPictureName" AssociatedControlID="txtPictureName"></asp:Label>
                <asp:RequiredFieldValidator
                  ID="rfvPictureName"
                  runat="server"
                  ControlToValidate="txtPictureName"
                  Display="Dynamic"
                  meta:resourcekey="rfvPictureName"
                  ForeColor="Red"></asp:RequiredFieldValidator>
              </div>
              <div class="mb-4">
                <asp:Label runat="server" AssociatedControlID="fuUploadPicture" CssClass="form-label"></asp:Label>
                <asp:FileUpload ID="fuUploadPicture" runat="server" AllowMultiple="false" CssClass="form-control" />
              </div>
            </div>
          </div>
          <div class="modal-footer flex-row">
            <asp:Button meta:resourcekey="btnUploadPicture" runat="server" CssClass="btn btn-outline-warning" CausesValidation="true" OnClick="UploadPicture" />
            <asp:Button meta:resourcekey="btnBack" runat="server" CssClass="btn btn-outline-secondary" CausesValidation="false" OnClick="BackToPicturesModal" />
          </div>
        </div>
      </div>

    </asp:Panel>

    <asp:Panel runat="server" ID="pnlPictures" CssClass="modal d-block bg-black bg-opacity-50" Visible="false">

      <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
          <div class="modal-header">
            <h5 runat="server" meta:resourcekey="hApartmentPictures" class="modal-title"></h5>
            <asp:Button runat="server" CssClass="btn-close" CausesValidation="false" OnClick="ReturnToEditModal" />
          </div>
          <div class="modal-body d-flex flex-column">
            <asp:DropDownList runat="server" ID="ddlPictures" CssClass="form-select mb-3" AutoPostBack="true" OnSelectedIndexChanged="ShowSelectedPicture">
            </asp:DropDownList>
            <asp:Image runat="server" ID="imgApartmentPicture" CssClass="img-fluid" />
            <div class="d-flex">
              <asp:Button meta:resourcekey="btnDeletePicture" runat="server" CssClass="btn btn-outline-danger mt-2 mb-3" CausesValidation="false" OnClick="DeleteSelectedPicture" />
              <asp:Button meta:resourcekey="btnSelectPicture" ID="btnSelectPicture" runat="server" CssClass="btn btn-outline-warning ms-auto mt-2 mb-3" CausesValidation="false" OnClick="SetSelectedPictureAsRepresentative" />
            </div>
          </div>
          <div class="modal-footer flex-row">
            <asp:Button meta:resourcekey="btnAddPicture" ID="btnAddPicture" runat="server" CssClass="btn btn-warning" CausesValidation="false" OnClick="OpenUploadPictureModal" />
            <asp:Button meta:resourcekey="btnBack" runat="server" CssClass="btn btn-outline-secondary" CausesValidation="false" OnClick="ReturnToEditModal" />
          </div>
        </div>
      </div>

    </asp:Panel>

    <asp:Panel runat="server" ID="pnlStatus" CssClass="modal d-block bg-black bg-opacity-50" Visible="false">

      <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
          <div class="modal-header">
            <h5 runat="server" meta:resourcekey="hStatusApartment" class="modal-title"></h5>
            <asp:Button runat="server" CssClass="btn-close" CausesValidation="false" OnClick="ReturnToEditModal" />
          </div>
          <div class="modal-body">
            <div class="form-floating mb-3">
              <asp:DropDownList runat="server" ID="ddlUpdateStatus" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="OpenMoreOptions">
              </asp:DropDownList>
              <asp:Label runat="server" meta:resourcekey="lblStatus" AssociatedControlID="ddlUpdateStatus"></asp:Label>
            </div>

            <asp:Panel runat="server" ID="pnlReservation" CssClass="container mt-2" Visible="false">
              <div class="form-floating mb-3">
                <asp:TextBox ID="taDetails" runat="server" TextMode="MultiLine" Height="100px" CssClass="form-control" MaxLength="1000"></asp:TextBox>
                <asp:Label runat="server" meta:resourcekey="lblDetails" AssociatedControlID="taDetails"></asp:Label>
              </div>

              <div class="form-floating mb-3">
                <asp:DropDownList runat="server" ID="ddlUserType" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="SelectUserType">
                  <asp:ListItem meta:resourcekey="liDefaultUserType" Selected="True" Value="-1"></asp:ListItem>
                  <asp:ListItem meta:resourcekey="liRegisteredUser" Value="0"></asp:ListItem>
                  <asp:ListItem meta:resourcekey="liUnregisteredUser" Value="1"></asp:ListItem>
                </asp:DropDownList>
                <asp:Label runat="server" meta:resourcekey="lblUserType" AssociatedControlID="ddlUserType"></asp:Label>
              </div>

              <asp:Panel runat="server" ID="pnlRegisteredUser" CssClass="container mt-2" Visible="false">
                <div class="form-floating mb-3">
                  <asp:DropDownList runat="server" ID="ddlRegisteredUsers" CssClass="form-select">
                  </asp:DropDownList>
                  <asp:Label runat="server" meta:resourcekey="lblRegisteredUser" AssociatedControlID="ddlRegisteredUsers"></asp:Label>
                </div>
              </asp:Panel>

              <asp:Panel runat="server" ID="pnlUnregisteredUser" CssClass="container mt-2" Visible="false">
                <div class="form-floating mb-3">
                  <asp:TextBox runat="server" ID="txtUnregisteredUserFName" CssClass="form-control" MaxLength="250"></asp:TextBox>
                  <asp:Label runat="server" meta:resourcekey="lblUnregisteredUserFName" AssociatedControlID="txtUnregisteredUserFName"></asp:Label>
                  <asp:RequiredFieldValidator
                    ID="rfvUnregisteredUserFName"
                    runat="server"
                    ControlToValidate="txtUnregisteredUserFName"
                    Display="Dynamic"
                    meta:resourcekey="rfvUnregisteredUserFName"
                    ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="form-floating mb-3">
                  <asp:TextBox runat="server" ID="txtUnregisteredUserLName" CssClass="form-control" MaxLength="250"></asp:TextBox>
                  <asp:Label runat="server" meta:resourcekey="lblUnregisteredUserLName" AssociatedControlID="txtUnregisteredUserLName"></asp:Label>
                  <asp:RequiredFieldValidator
                    ID="rfvUnregisteredUserLName"
                    runat="server"
                    ControlToValidate="txtUnregisteredUserLName"
                    Display="Dynamic"
                    meta:resourcekey="rfvUnregisteredUserLName"
                    ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="form-floating mb-3">
                  <asp:TextBox runat="server" ID="txtUnregisteredUserEmail" TextMode="Email" MaxLength="250" CssClass="form-control"></asp:TextBox>
                  <asp:Label runat="server" meta:resourcekey="lblUnregisteredUserEmail" AssociatedControlID="txtUnregisteredUserEmail"></asp:Label>
                  <asp:RequiredFieldValidator
                    ID="rfvUnregisteredUserEmail"
                    runat="server"
                    ControlToValidate="txtUnregisteredUserEmail"
                    Display="Dynamic"
                    meta:resourcekey="rfvUnregisteredUserEmail"
                    ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="form-floating mb-3">
                  <asp:TextBox runat="server" ID="txtUnregisteredUserPhone" MaxLength="20" TextMode="Phone" CssClass="form-control"></asp:TextBox>
                  <asp:Label runat="server" meta:resourcekey="lblUnregisteredUserPhone" AssociatedControlID="txtUnregisteredUserPhone"></asp:Label>
                  <asp:RequiredFieldValidator
                    ID="rfvUnregisteredUserPhone"
                    runat="server"
                    ControlToValidate="txtUnregisteredUserPhone"
                    Display="Dynamic"
                    meta:resourcekey="rfvUnregisteredUserPhone"
                    ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="form-floating mb-3">
                  <asp:TextBox runat="server" ID="txtUnregisteredUserAddress" MaxLength="1000" CssClass="form-control"></asp:TextBox>
                  <asp:Label runat="server" meta:resourcekey="lblUnregisteredUserAddress" AssociatedControlID="txtUnregisteredUserAddress"></asp:Label>
                  <asp:RequiredFieldValidator
                    ID="rfvUnregisteredUserAddress"
                    runat="server"
                    ControlToValidate="txtUnregisteredUserAddress"
                    Display="Dynamic"
                    meta:resourcekey="rfvUnregisteredUserAddress"
                    ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
              </asp:Panel>
            </asp:Panel>
          </div>
          <div class="modal-footer flex-row">
            <asp:Button meta:resourcekey="btnBack" runat="server" CssClass="btn btn-outline-secondary" CausesValidation="false" OnClick="ReturnToEditModal" />
            <asp:Button meta:resourcekey="btnSave" runat="server" CssClass="btn btn-warning" CausesValidation="true" OnClick="SaveStatusChange" />
          </div>
        </div>
      </div>

    </asp:Panel>

    <asp:Panel runat="server" ID="pnlDelete" CssClass="modal d-block bg-black bg-opacity-50" Visible="false">

      <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content rounded-4 shadow">
          <div class="modal-body p-4 text-center">
            <h5 runat="server" class="mb-2" meta:resourcekey="hDeleteApartment"></h5>
            <p runat="server" class="mb-0" meta:resourcekey="pDeleteApartment"></p>
          </div>
          <asp:TextBox runat="server" Visible="false" TextMode="Number" ID="txtDeleteApartmentId"></asp:TextBox>
          <div class="modal-footer flex-nowrap p-0">
            <asp:Button meta:resourcekey="btnSubmitDelete" runat="server" CssClass="btn btn-lg btn-link link-danger fs-6 text-decoration-none col-6 m-0 rounded-0 border-right" CausesValidation="false" OnClick="SubmitDeleteApartment" />
            <asp:Button meta:resourcekey="btnCancelDelete" runat="server" CssClass="btn btn-lg btn-link link-secondary fs-6 text-decoration-none col-6 m-0 rounded-0" CausesValidation="false" OnClick="CancelDeleteApartment" />
          </div>
        </div>
      </div>

    </asp:Panel>

  </div>
</asp:Content>
