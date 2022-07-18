using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Routing;

using Apartments.BLL.Managers;
using Apartments.DAL.Managers;
using Apartments.DAL.Repository.Db.Sql;

namespace Apartments.AdminUI {
  public class Global : System.Web.HttpApplication {

    protected void Application_Start(Object sender, EventArgs e) {
      RouteConfig.RegisterRoutes(RouteTable.Routes);

      Application["requestCounter"] = 0;
      Application["sessionCounter"] = 0;

      Application["Apartments"] = new ApartmentDomainModelManager(new ApartmentSqlDbRepository(new ConnectionStringManager(), new SqlDbTypeManager()));
      Application["Statuses"] = new StatusDomainModelManager(new StatusSqlDbRepository(new ConnectionStringManager(), new SqlDbTypeManager()));
      Application["Cities"] = new CityDomainModelManager(new CitySqlDbRepository(new ConnectionStringManager(), new SqlDbTypeManager()));
      Application["TagsApartments"] = new TagApartmentDomainModelManager(new TagApartmentSqlDbRepository(new ConnectionStringManager(), new SqlDbTypeManager()));
      Application["Tags"] = new TagDomainModelManager(new TagSqlDbRepository(new ConnectionStringManager(), new SqlDbTypeManager()));
      Application["Users"] = new UserDomainModelManager(new UserSqlDbRepository(new ConnectionStringManager(), new SqlDbTypeManager()));
      Application["Reservations"] = new ReservationDomainModelManager(new ReservationSqlDbRepository(new ConnectionStringManager(), new SqlDbTypeManager()));
      Application["Owners"] = new OwnerDomainModelManager(new OwnerSqlDbRepository(new ConnectionStringManager(), new SqlDbTypeManager()));
      Application["TagTypes"] = new TagTypeDomainModelManager(new TagTypeSqlDbRepository(new ConnectionStringManager(), new SqlDbTypeManager()));
      Application["Pictures"] = new PictureDomainModelManager(new PictureSqlDbRepository(new ConnectionStringManager(), new SqlDbTypeManager()));
    }

    protected void Session_Start(Object sender, EventArgs e) {
      Application.Lock();
      Application["sessionCounter"] = (Int32)Application["sessionCounter"] + 1;
      Application.UnLock();
    }

    protected void Application_BeginRequest(Object sender, EventArgs e) {
      Application.Lock();
      Application["requestCounter"] = (Int32)Application["requestCounter"] + 1;
      Application.UnLock();

      if (Request.Cookies["lang"] != null &&
          Request.Cookies["lang"]["lang"] != null) {
        String culture = Request.Cookies["lang"]["lang"];
        Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
      }
    }

    protected void Application_AuthenticateRequest(Object sender, EventArgs e) {

    }

    protected void Application_Error(object sender, EventArgs e) {
      Exception exc = Server.GetLastError();

      if (exc is HttpUnhandledException) {
        Server.Transfer("ErrorPage.aspx", true);
      }
    }

    protected void Session_End(Object sender, EventArgs e) {
      Application.Lock();
      Application["sessionCounter"] = (Int32)Application["sessionCounter"] - 1;
      Application.UnLock();
    }

    protected void Application_End(Object sender, EventArgs e) {

    }
  }
}