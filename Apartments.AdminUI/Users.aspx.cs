using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

using Apartments.BLL.Base.Managers.DomainModels;
using Apartments.BLL.DomainModels;

namespace Apartments.AdminUI {
  public partial class Users : DefaultPage {
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

    private void ReloadGridView() {
      IEnumerable<UserDomainModel> users = ((IUserDomainModelManager)Application["Users"]).GetAllIfAvailable()
                                                                                          .Where(predicate: user => !user.IsAdmin);

      gvUsers.DataSource = users;
      gvUsers.DataBind();
    }

    protected void SortByColumn(Object sender, GridViewSortEventArgs e) {
      IEnumerable<UserDomainModel> users = ((IUserDomainModelManager)Application["Users"]).GetAllIfAvailable()
                                                                                          .Where(predicate: user => !user.IsAdmin);
      gvUsers.DataSource = SortUsersByDynamicPropertyName(users, e.SortExpression, GetSortDirection(e.SortExpression));
      gvUsers.DataBind();
    }

    private IEnumerable<UserDomainModel> SortUsersByDynamicPropertyName(IEnumerable<UserDomainModel> tags, String property, SortDirection direction)
      => direction == SortDirection.Ascending
        ? tags.OrderBy(x => typeof(UserDomainModel).GetProperty(property).GetValue(x))
        : tags.OrderByDescending(x => typeof(UserDomainModel).GetProperty(property).GetValue(x));

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
  }
}