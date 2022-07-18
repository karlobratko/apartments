using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.UI.WebControls;

using Apartments.AdminUI.Projections;
using Apartments.BLL.Base.Managers.DomainModels;
using Apartments.BLL.DomainModels;

namespace Apartments.AdminUI {
  public partial class Apartments : DefaultPage {
    public ApartmentDomainModel EditedApartment {
      get => ViewState["EditedApartment"] != null
        ? ViewState["EditedApartment"] as ApartmentDomainModel
        : null;
      set => ViewState["EditedApartment"] = value;
    }

    public String GridViewSortExpression {
      get => ViewState["SortExpression"] as String;
      set => ViewState["SortExpression"] = value;
    }

    public SortDirection GridViewSortDirection {
      get => ViewState["SortDirection"] != null && Enum.IsDefined(typeof(SortDirection), ViewState["SortDirection"] as String)
        ? (SortDirection)Enum.Parse(typeof(SortDirection), ViewState["SortDirection"] as String)
        : SortDirection.Ascending;
      set => ViewState["SortDirection"] = value.ToString();
    }

    protected void Page_Load(Object sender, EventArgs e) {
      if (!IsPostBack) {
        FillStatusDDL(ddlStatus);
        FillCityDDL(ddlCity);
        ReloadGridView(sender, e);
      }
    }

    private void FillCityDDL(DropDownList ddl) {
      ddl.Items.Clear();
      ddl.Items.Add(new ListItem() { Text = GetLocalResourceObject("liDefaultCity").ToString(), Value = "-1", Selected = true });
      ddl.Items.AddRange(((ICityDomainModelManager)Application["Cities"]).GetAllIfAvailable().Select(x => new ListItem() {
        Text = x.Name,
        Value = x.Id.ToString()
      }).ToArray());
    }

    private void FillStatusDDL(DropDownList ddl) {
      ddl.Items.Clear();
      ddl.Items.Add(new ListItem() { Text = GetLocalResourceObject("liDefaultStatus").ToString(), Value = "-1", Selected = true });
      ddl.Items.AddRange(((IStatusDomainModelManager)Application["Statuses"]).GetAllIfAvailable().Select(x => new ListItem() {
        Text = Thread.CurrentThread.CurrentUICulture.Name == "hr" ? x.Name : x.NameEng,
        Value = x.Id.ToString()
      }).ToArray());
    }

    IEnumerable<ApartmentProjection> ReadAllApartmentProjection()
      => from apartment in ((IApartmentDomainModelManager)Application["Apartments"]).GetAllIfAvailable()
         let status = ((IStatusDomainModelManager)Application["Statuses"]).GetById(apartment.StatusFK)
         let city = ((ICityDomainModelManager)Application["Cities"]).GetById(apartment.CityFK)
         let owner = ((IOwnerDomainModelManager)Application["Owners"]).GetById(apartment.OwnerFK)
         select new ApartmentProjection {
           Id = apartment.Id,
           Guid = apartment.Guid,
           OwnerFK = apartment.OwnerFK,
           Owner = owner.Name,
           StatusFK = apartment.StatusFK,
           CityFK = apartment.CityFK,
           City = city.Name,
           Address = apartment.Address,
           Name = Thread.CurrentThread.CurrentUICulture.Name == "hr" ? apartment.Name : apartment.NameEng,
           Price = apartment.Price,
           MaxAdults = apartment.MaxAdults,
           MaxChildren = apartment.MaxChildren,
           TotalRooms = apartment.TotalRooms,
           BeachDistance = apartment.BeachDistance,
           PicturesCount = ((IPictureDomainModelManager)Application["Pictures"]).GetByApartment(apartment).Count()
         };

    protected void ReloadGridView(Object sender, EventArgs e) {
      ClearGridViewSortState();

      IEnumerable<ApartmentProjection> apartments = ReadAllApartmentProjection();

      Int32 statusFK = Int32.Parse(ddlStatus.SelectedItem.Value);
      apartments = statusFK == -1
        ? apartments
        : apartments.Where(x => x.StatusFK == statusFK);

      Int32 cityFK = Int32.Parse(ddlCity.SelectedItem.Value);
      apartments = cityFK == -1
        ? apartments
        : apartments.Where(x => x.CityFK == cityFK);

      String sortExpression = ddlSort.SelectedItem.Value;
      var sortDirection = (SortDirection)Enum.Parse(typeof(SortDirection), ddlOrder.SelectedItem.Value);
      apartments = SortApartmentsByDynamicPropertyName(apartments, sortExpression, sortDirection);

      gvApartments.DataSource = apartments;
      gvApartments.DataBind();
    }

    protected void SortByColumn(Object sender, GridViewSortEventArgs e) {
      ClearGridViewForm();

      IEnumerable<ApartmentProjection> apartments = ReadAllApartmentProjection();
      gvApartments.DataSource = SortApartmentsByDynamicPropertyName(apartments, e.SortExpression, GetSortDirection(e.SortExpression));
      gvApartments.DataBind();
    }

    private IEnumerable<ApartmentProjection> SortApartmentsByDynamicPropertyName(IEnumerable<ApartmentProjection> apartments, String property, SortDirection direction)
      => direction == SortDirection.Ascending
        ? apartments.OrderBy(x => typeof(ApartmentProjection).GetProperty(property).GetValue(x))
        : apartments.OrderByDescending(x => typeof(ApartmentProjection).GetProperty(property).GetValue(x));

    private SortDirection GetSortDirection(String sortExpression) {
      String lastSortExpression = GridViewSortExpression;
      SortDirection sortDirection = SortDirection.Ascending;

      if (!String.IsNullOrEmpty(lastSortExpression)) {
        sortDirection = lastSortExpression == sortExpression
          ? GridViewSortDirection == SortDirection.Ascending ? SortDirection.Descending : SortDirection.Ascending
          : SortDirection.Ascending;
      }

      GridViewSortExpression = sortExpression;
      GridViewSortDirection = sortDirection;

      return sortDirection;
    }

    private void ClearGridViewSortState() {
      GridViewSortExpression = null;
      ViewState["SortDirection"] = null;
    }

    private void ClearGridViewForm() {
      ddlStatus.SelectedIndex = 0;
      ddlCity.SelectedIndex = 0;
      ddlSort.SelectedIndex = 0;
      ddlOrder.SelectedIndex = 0;
    }

    protected void OpenEditModal(Object sender, EventArgs e) {
      var btn = sender as Button;
      Int32 id = Int32.Parse(btn.CommandArgument);

      ApartmentDomainModel apartment = ((IApartmentDomainModelManager)Application["Apartments"]).GetById(id: id);
      EditedApartment = apartment;

      FillEditForm(apartment);
      pnlEdit.Visible = true;
    }

    protected void CloseEditModal(Object sender, EventArgs e) {
      EditedApartment = null;

      pnlEdit.Visible = false;
      ClearEditForm();
    }

    protected void SubmitEdit(Object sender, EventArgs e) {
      if (!IsValid) return;

      ApartmentDomainModel apartment = EditedApartment;
      if (apartment == null) return;

      apartment.Name = txtEditName.Text.Trim();
      apartment.NameEng = txtEditNameEng.Text.Trim();
      apartment.CityFK = Int32.Parse(ddlEditCity.SelectedItem.Value);
      apartment.Address = txtEditAddress.Text.Trim();
      apartment.Price = Decimal.Parse(txtEditPrice.Text);
      apartment.MaxAdults = Int32.Parse(txtEditMaxAdults.Text);
      apartment.MaxChildren = Int32.Parse(txtEditMaxChildren.Text);
      apartment.TotalRooms = Int32.Parse(txtEditTotalRooms.Text);
      apartment.BeachDistance = Int32.Parse(txtEditBeachDistance.Text);

      _ = ((IApartmentDomainModelManager)Application["Apartments"]).Edit(model: apartment);

      CloseEditModal(sender, e);
      ReloadGridView(sender, e);
    }

    private void FillEditForm(ApartmentDomainModel apartment) {
      txtEditName.Text = apartment.Name;
      txtEditNameEng.Text = apartment.NameEng;

      FillCityDDL(ddlEditCity);
      ddlEditCity.SelectedIndex = -1;
      ddlEditCity.Items.FindByValue(apartment.CityFK.ToString()).Selected = true;

      txtEditAddress.Text = apartment.Address;
      txtEditMaxAdults.Text = apartment.MaxAdults.ToString();
      txtEditMaxChildren.Text = apartment.MaxChildren.ToString();
      txtEditTotalRooms.Text = apartment.TotalRooms.ToString();
      txtEditBeachDistance.Text = apartment.BeachDistance.ToString();
      txtEditPrice.Text = apartment.Price.ToString("F2");
    }

    private void ClearEditForm() {
      txtEditName.Text = String.Empty;
      txtEditNameEng.Text = String.Empty;
      ddlEditCity.Items.Clear();
      txtEditAddress.Text = String.Empty;
      txtEditMaxAdults.Text = String.Empty;
      txtEditMaxChildren.Text = String.Empty;
      txtEditTotalRooms.Text = String.Empty;
      txtEditBeachDistance.Text = String.Empty;
      txtEditPrice.Text = String.Empty;
    }

    protected void OpenTagsModal(Object sender, EventArgs e) {
      if (EditedApartment is null) return;

      FillTagsForm();
      pnlEdit.Visible = false;
      pnlTags.Visible = true;
    }

    protected void ReturnToEditModal(Object sender, EventArgs e) {
      pnlRegisteredUser.Visible = false;
      pnlUnregisteredUser.Visible = false;
      pnlReservation.Visible = false;
      pnlStatus.Visible = false;
      pnlTags.Visible = false;
      pnlPictures.Visible = false;
      pnlEdit.Visible = true;
      ClearTagsForm();
      ClearStatusForm();
    }

    private void ClearTagsForm() {
      rpTags.DataBind();
      ddlTags.Items.Clear();
    }

    private void FillTagsForm() {
      IEnumerable<TagApartmentProjection> apartmentTags = from tagApartment in ((ITagApartmentDomainModelManager)Application["TagsApartments"]).GetByApartment(EditedApartment)
                                                          let tag = ((ITagDomainModelManager)Application["Tags"]).GetById(tagApartment.TagFK)
                                                          select new TagApartmentProjection {
                                                            Guid = tagApartment.Guid,
                                                            Name = Thread.CurrentThread.CurrentUICulture.Name == "hr" ? tag.Name : tag.NameEng,
                                                            ApartmentFK = tagApartment.ApartmentFK,
                                                            TagFK = tagApartment.TagFK,
                                                          };
      rpTags.DataSource = apartmentTags;
      rpTags.DataBind();

      FillTagsDDL();
    }

    private void FillTagsDDL() {
      ddlTags.Items.Clear();
      ddlTags.Items.Add(new ListItem() { Text = GetLocalResourceObject("liDefaultTag").ToString(), Value = "-1", Selected = true });
      ddlTags.Items.AddRange(((ITagDomainModelManager)Application["Tags"]).GetUnassigned(EditedApartment).Select(x => new ListItem() {
        Text = CultureInfo.CurrentUICulture.Name == "hr" ? x.Name : x.NameEng,
        Value = x.Id.ToString()
      }).ToArray());
    }

    protected void UnassignTag(Object source, RepeaterCommandEventArgs e) {
      if (e.CommandName == "Remove") {
        _ = ((ITagApartmentDomainModelManager)Application["TagsApartments"]).Remove(Guid.Parse(e.CommandArgument.ToString()));

        FillTagsForm();
      }
    }

    protected void AssignTag(Object sender, EventArgs e) {
      Int32 tagFK = Int32.Parse(ddlTags.SelectedItem.Value);
      if (tagFK == -1) return;

      _ = ((ITagApartmentDomainModelManager)Application["TagsApartments"]).Add(new TagApartmentDomainModel {
        TagFK = tagFK,
        ApartmentFK = EditedApartment.Id
      });
      FillTagsForm();
    }

    protected void OpenStatusModal(Object sender, EventArgs e) {
      if (EditedApartment is null) return;

      FillStatusForm();
      pnlEdit.Visible = false;
      pnlStatus.Visible = true;
    }

    private void FillStatusForm() => FillStatusDDL(ddlUpdateStatus);

    private void ClearStatusForm() => ddlUpdateStatus.Items.Clear();

    protected void OpenMoreOptions(Object sender, EventArgs e) {
      Int32 statusFK = Int32.Parse(ddlUpdateStatus.SelectedItem.Value);

      pnlRegisteredUser.Visible = false;
      pnlUnregisteredUser.Visible = false;
      ddlUserType.SelectedIndex = 0;
      taDetails.Text = String.Empty;

      pnlReservation.Visible = statusFK == 2 || statusFK == 3;
    }

    protected void SelectUserType(Object sender, EventArgs e) {
      Int32 userType = Int32.Parse(ddlUserType.SelectedItem.Value);
      switch (userType) {
        case 0:
          pnlRegisteredUser.Visible = true;
          pnlUnregisteredUser.Visible = false;
          FillRegisteredUsersDDL();
          break;
        case 1:
          pnlRegisteredUser.Visible = false;
          pnlUnregisteredUser.Visible = true;
          break;
        default:
          pnlRegisteredUser.Visible = false;
          pnlUnregisteredUser.Visible = false;
          break;
      }
    }

    private void FillRegisteredUsersDDL() {
      ddlRegisteredUsers.Items.Clear();
      ddlRegisteredUsers.Items.Add(new ListItem() { Text = GetLocalResourceObject("liDefaultRegisteredUser").ToString(), Value = "-1", Selected = true });
      ddlRegisteredUsers.Items.AddRange(((IUserDomainModelManager)Application["Users"]).GetAllIfAvailable()
                                                                                       .Where(predicate: user => !user.IsAdmin)
                                                                                       .Select(x => new ListItem() {
                                                                                         Text = $"{x.FName} {x.LName} ({x.Email})",
                                                                                         Value = x.Id.ToString()
                                                                                       }).ToArray());
    }

    protected void SaveStatusChange(Object sender, EventArgs e) {
      Int32 statusFK = Int32.Parse(ddlUpdateStatus.SelectedItem.Value);
      if (statusFK == -1) {
        return;
      }
      else if (statusFK == 2 || statusFK == 3) {
        Int32 userType = Int32.Parse(ddlUserType.SelectedItem.Value);
        switch (userType) {
          case 0: {
            Int32 userFK = Int32.Parse(ddlRegisteredUsers.SelectedItem.Value);
            if (userFK == -1) return;

            UserDomainModel user = ((IUserDomainModelManager)Application["Users"]).GetById(userFK);
            _ = ((IReservationDomainModelManager)Application["Reservations"]).Add(new ReservationDomainModel {
              ApartmentFK = EditedApartment.Id,
              Details = taDetails.Text.Trim(),
              UserFK = userFK,
              UserFName = user.FName,
              UserLName = user.LName,
              UserAddress = String.IsNullOrEmpty(user.Address) ? "" : user.Address,
              UserEmail = user.Email,
              UserPhoneNumber = String.IsNullOrEmpty(user.PhoneNumber) ? "" : user.PhoneNumber
            });
            break;
          }
          case 1: {
            _ = ((IReservationDomainModelManager)Application["Reservations"]).Add(new ReservationDomainModel {
              ApartmentFK = EditedApartment.Id,
              Details = taDetails.Text.Trim(),
              UserFK = null,
              UserFName = txtUnregisteredUserFName.Text.Trim(),
              UserLName = txtUnregisteredUserLName.Text.Trim(),
              UserAddress = txtUnregisteredUserAddress.Text.Trim(),
              UserEmail = txtUnregisteredUserEmail.Text.Trim(),
              UserPhoneNumber = txtUnregisteredUserPhone.Text.Trim(),
            });
            break;
          }
          default:
            return;
        }
      }

      EditedApartment.StatusFK = statusFK;
      _ = ((IApartmentDomainModelManager)Application["Apartments"]).Edit(EditedApartment);

      ReturnToEditModal(sender, e);
    }

    protected void OpenPicturesModal(Object sender, EventArgs e) {
      if (EditedApartment is null) return;

      FillPicturesForm();
      pnlEdit.Visible = false;
      pnlPictures.Visible = true;
    }

    private void FillPicturesForm() {
      imgApartmentPicture.ImageUrl = String.Empty;
      FillPicturesDDL();
      ShowSelectedPicture(null, null);
    }

    protected void BackToPicturesModal(Object sender, EventArgs e) {
      pnlAddPictures.Visible = false;
      pnlPictures.Visible = true;
      ClearAddPictureModal();
      FillPicturesForm();
    }

    private void ClearAddPictureModal() => txtPictureName.Text = String.Empty;

    protected void OpenUploadPictureModal(Object sender, EventArgs e) {
      pnlAddPictures.Visible = true;
      pnlPictures.Visible = false;
    }

    private void FillPicturesDDL() {
      ddlPictures.Items.Clear();
      ddlPictures.Items.AddRange(((IPictureDomainModelManager)Application["Pictures"]).GetByApartment(EditedApartment).Select(x => new ListItem() {
        Text = x.Title,
        Value = x.Id.ToString(),
        Selected = x.IsRepresentative
      }).ToArray());
    }

    protected void ShowSelectedPicture(Object sender, EventArgs e) {
      if (ddlPictures.Items.Count == 0) return;
      Int32 id = Int32.Parse(ddlPictures.SelectedItem.Value);
      PictureDomainModel picture = ((IPictureDomainModelManager)Application["Pictures"]).GetById(id);
      imgApartmentPicture.ImageUrl = $"data:{picture.MimeType};base64," + Convert.ToBase64String(picture.Data);

      btnSelectPicture.Enabled = !picture.IsRepresentative;
      btnSelectPicture.CssClass = btnSelectPicture.CssClass.Replace(picture.IsRepresentative ? "warning" : "secondary", picture.IsRepresentative ? "secondary" : "warning");
    }

    protected void SetSelectedPictureAsRepresentative(Object sender, EventArgs e) {
      if (ddlPictures.Items.Count == 0) return;
      Int32 id = Int32.Parse(ddlPictures.SelectedItem.Value);
      PictureDomainModel picture = ((IPictureDomainModelManager)Application["Pictures"]).GetById(id);
      _ = ((IPictureDomainModelManager)Application["Pictures"]).MakeRepresentative(new PictureDomainModel {
        Guid = picture.Guid
      });
      FillPicturesForm();
    }

    protected void DeleteSelectedPicture(Object sender, EventArgs e) {
      if (ddlPictures.Items.Count == 0) return;
      Int32 id = Int32.Parse(ddlPictures.SelectedItem.Value);
      PictureDomainModel picture = ((IPictureDomainModelManager)Application["Pictures"]).GetById(id);
      _ = ((IPictureDomainModelManager)Application["Pictures"]).Remove(guid: picture.Guid);

      FillPicturesForm();
    }

    protected void ValidatePictureSize(Object source, ServerValidateEventArgs args) 
      => args.IsValid = fuUploadPicture.FileBytes.Length <= 512 * 1024;

    protected void UploadPicture(Object sender, EventArgs e) {
      if (!fuUploadPicture.HasFile) return;

      if (fuUploadPicture.PostedFile.ContentLength > 512 * 1024) return;

      var picture = new PictureDomainModel {
        ApartmentFK = EditedApartment.Id,
        Title = txtPictureName.Text.Trim(),
        MimeType = fuUploadPicture.PostedFile.ContentType,
        Data = new Byte[fuUploadPicture.PostedFile.ContentLength],
        IsRepresentative = true,
      };
      _ = fuUploadPicture.PostedFile.InputStream.Read(picture.Data, 0, fuUploadPicture.PostedFile.ContentLength);

      _ = ((IPictureDomainModelManager)Application["Pictures"]).Add(model: picture);

      ClearAddPictureModal();
    }

    protected void OpenDeleteModal(Object sender, EventArgs e) {
      var btn = sender as Button;
      var guid = Guid.Parse(btn.CommandArgument);

      txtDeleteApartmentId.Text = guid.ToString();
      pnlDelete.Visible = true;
    }

    protected void SubmitDeleteApartment(Object sender, EventArgs e) {
      var guid = Guid.Parse(txtDeleteApartmentId.Text);

      _ = ((IApartmentDomainModelManager)Application["Apartments"]).Remove(guid);

      pnlDelete.Visible = false;
      ReloadGridView(sender, e);
    }

    protected void CancelDeleteApartment(Object sender, EventArgs e) => pnlDelete.Visible = false;

    protected void OpenCreateModal(Object sender, EventArgs e) {
      FillCreateForm();
      pnlCreate.Visible = true;
    }

    private void FillCreateForm() {
      FillCityDDL(ddlCreateCity);
      FillOwnerDDL();
    }

    private void FillOwnerDDL() {
      ddlCreateOwner.Items.Clear();
      ddlCreateOwner.Items.Add(new ListItem() { Text = GetLocalResourceObject("liDefaultOwner").ToString(), Value = "-1", Selected = true });
      ddlCreateOwner.Items.AddRange(((IOwnerDomainModelManager)Application["Owners"]).GetAllIfAvailable().Select(x => new ListItem() {
        Text = x.Name,
        Value = x.Id.ToString()
      }).ToArray());
    }

    protected void CloseCreateModal(Object sender, EventArgs e) {
      pnlCreate.Visible = false;
      ClearCreateForm();
    }

    private void ClearCreateForm() {
      txtCreateNameCro.Text = String.Empty;
      txtCreateNameEng.Text = String.Empty;
      txtCreateAddress.Text = String.Empty;
      txtCreateMaxAdults.Text = "1";
      txtCreateMaxChildren.Text = "1";
      txtCreateTotalRooms.Text = "1";
      txtCreateBeachDistance.Text = "1";
      txtCreatePrice.Text = String.Empty;
    }

    protected void SubmitCreate(Object sender, EventArgs e) {
      if (!IsValid) return;

      _ = ((IApartmentDomainModelManager)Application["Apartments"]).Add(new ApartmentDomainModel {
        OwnerFK = Int32.Parse(ddlCreateOwner.SelectedItem.Value),
        StatusFK = 1,
        Name = txtCreateNameCro.Text.Trim(),
        NameEng = txtCreateNameEng.Text.Trim(),
        CityFK = Int32.Parse(ddlCreateCity.SelectedItem.Value),
        Address = txtCreateAddress.Text.Trim(),
        Price = Decimal.Parse(txtCreatePrice.Text),
        MaxAdults = Int32.Parse(txtCreateMaxAdults.Text),
        MaxChildren = Int32.Parse(txtCreateMaxChildren.Text),
        TotalRooms = Int32.Parse(txtCreateTotalRooms.Text),
        BeachDistance = Int32.Parse(txtCreateBeachDistance.Text)
      });

      CloseCreateModal(sender, e);
      ReloadGridView(sender, e);
    }
  }
}