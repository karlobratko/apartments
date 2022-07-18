using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.UI.WebControls;

using Apartments.AdminUI.Projections;
using Apartments.BLL.Base.Managers.DomainModels;
using Apartments.BLL.DomainModels;

namespace Apartments.AdminUI {
  public partial class Tags : DefaultPage {
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
        ReloadGridView();
      }
    }

    public IEnumerable<TagProjection> ReadAllTagProjection()
      => from tag in ((ITagDomainModelManager)Application["Tags"]).GetAllIfAvailable()
         let tagType = ((ITagTypeDomainModelManager)Application["TagTypes"]).GetById(tag.TagTypeFK)
         select new TagProjection {
           Id = tag.Id,
           Guid = tag.Guid,
           Name = Thread.CurrentThread.CurrentUICulture.Name == "hr" ? tag.Name : tag.NameEng,
           TypeName = Thread.CurrentThread.CurrentUICulture.Name == "hr" ? tagType.Name : tagType.NameEng,
           ApartmentCount = ((IApartmentDomainModelManager)Application["Apartments"]).GetByTag(tag).Count()
         };

    private void ReloadGridView() {
      IEnumerable<TagProjection> tags = ReadAllTagProjection();

      gvTags.DataSource = tags;
      gvTags.DataBind();
    }

    protected void CreateTag(Object sender, EventArgs e) {
      FillCreateForm();
      pnlCreate.Visible = true;
    }

    private void FillCreateForm() => FillTypeDDL();

    private void FillTypeDDL() {
      ddlCreateType.Items.Clear();
      ddlCreateType.Items.Add(new ListItem() { Text = GetLocalResourceObject("liDefaultType").ToString(), Value = "-1", Selected = true });

      ddlCreateType.Items.AddRange(((ITagTypeDomainModelManager)Application["TagTypes"]).GetAllIfAvailable().Select(x => new ListItem() {
        Text = CultureInfo.CurrentUICulture.Name == "hr" ? x.Name : x.NameEng,
        Value = x.Id.ToString()
      }).ToArray());
    }

    protected void SubmitCreateTag(Object sender, EventArgs e) {
      if (!IsValid) return;

      _ = ((ITagDomainModelManager)Application["Tags"]).Add(new TagDomainModel {
        Name = txtCreateNameCro.Text.Trim(),
        NameEng = txtCreateNameEng.Text.Trim(),
        TagTypeFK = Int32.Parse(ddlCreateType.SelectedItem.Value),
      });

      CancelCreateTag(sender, e);
      ReloadGridView();
    }

    protected void CancelCreateTag(Object sender, EventArgs e) {
      pnlCreate.Visible = false;
      ClearCreateForm();
    }

    private void ClearCreateForm() {
      txtCreateNameCro.Text = String.Empty;
      txtCreateNameEng.Text = String.Empty;
    }

    protected void DeleteTag(Object sender, EventArgs e) {
      var btn = sender as Button;
      var guid = Guid.Parse(btn.CommandArgument);

      txtDeleteTagId.Text = guid.ToString();
      pnlDelete.Visible = true;
    }

    protected void SubmitDeleteTag(Object sender, EventArgs e) {
      var guid = Guid.Parse(txtDeleteTagId.Text);

      _ = ((ITagDomainModelManager)Application["Tags"]).Remove(guid);

      pnlDelete.Visible = false;
      ReloadGridView();
    }

    protected void CancelDeleteTag(Object sender, EventArgs e) => pnlDelete.Visible = false;

    protected void SortByColumn(Object sender, GridViewSortEventArgs e) {
      IEnumerable<TagProjection> tags = ReadAllTagProjection();
      gvTags.DataSource = SortTagsByDynamicPropertyName(tags, e.SortExpression, GetSortDirection(e.SortExpression));
      gvTags.DataBind();
    }

    private IEnumerable<TagProjection> SortTagsByDynamicPropertyName(IEnumerable<TagProjection> tags, String property, SortDirection direction)
      => direction == SortDirection.Ascending
        ? tags.OrderBy(x => typeof(TagProjection).GetProperty(property).GetValue(x))
        : tags.OrderByDescending(x => typeof(TagProjection).GetProperty(property).GetValue(x));

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

    protected void DisableDeleteForUsedTags(Object sender, GridViewRowEventArgs e) {
      if (e.Row.RowType == DataControlRowType.Header) return;

      if (!(e.Row.FindControl("btnDelete") is Button btn)) return;

      if (Int32.Parse(e.Row.Cells[e.Row.Cells.Count - 2].Text) != 0) {
        btn.CommandArgument = "-1";
        btn.CssClass += " btn-outline-secondary";
        btn.Enabled = false;
      }
    }
  }
}