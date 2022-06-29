using System;
using System.Diagnostics.Contracts;
using System.Web.Mvc.Routing;

using Apartments.WebUI.Infrastructure.Routing.Entries;

public sealed class LocalizedRouteAttribute : Attribute, IDirectRouteFactory, IRouteInfoProvider {
  public LocalizedRouteAttribute() => Template = String.Empty;

  public LocalizedRouteAttribute(String template, String explicitCulture = "", Boolean translateUrl = true) {
    Template = template ?? throw new ArgumentNullException("template");
    ExplicitCulture = explicitCulture;
    TranslateUrl = translateUrl;
  }

  public String Name { get; set; }

  public Int32 Order { get; set; }

  public String Template { get; private set; }

  public String ExplicitCulture { get; private set; } = "";
  public Boolean TranslateUrl { get; private set; } = true;

  RouteEntry IDirectRouteFactory.CreateRoute(DirectRouteFactoryContext context) {
    Contract.Assert(context != null);

    IDirectRouteBuilder builder = context.CreateBuilder(Template);
    Contract.Assert(builder != null);

    builder.Name = Name;
    builder.Order = Order;
    RouteEntry entry = builder.Build();
    return new LocalizedRouteEntry(entry.Name, entry.Route, ExplicitCulture, TranslateUrl);
  }
}