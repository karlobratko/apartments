using System;
using System.Web;
using System.Web.Mvc;

using Apartments.WebUI.Infrastructure;

using Microsoft.Web.Infrastructure.DynamicModuleHelper;

using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Apartments.WebUI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Apartments.WebUI.App_Start.NinjectWebCommon), "Stop")]

namespace Apartments.WebUI.App_Start {

  public static class NinjectWebCommon {
    private static readonly Bootstrapper BOOTSTRAPPER = new Bootstrapper();

    public static void Start() {
      DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
      DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
      BOOTSTRAPPER.Initialize(CreateKernel);
    }

    public static void Stop() => BOOTSTRAPPER.ShutDown();

    private static IKernel CreateKernel() {
      var kernel = new StandardKernel();
      try {
        _ = kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
        _ = kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
        RegisterServices(kernel);
        return kernel;
      }
      catch {
        kernel.Dispose();
        throw;
      }
    }

    private static void RegisterServices(IKernel kernel)
      => DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
  }
}