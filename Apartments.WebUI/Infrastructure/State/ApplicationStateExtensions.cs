using System;
using System.Web;

namespace Apartments.WebUI.Infrastructure.State {
  public static class ApplicationStateExtensions {
    public static T GetSetApplicationState<T>(this HttpApplicationState appState, String objectName, Object objectValue = null, Int32 syncCheckMinutes = 0) {
      var retVal = default(T);
      appState.Lock();
      if (appState[objectName + "LastSync"] == null || DateTime.Now.Subtract((DateTime)appState[objectName + "LastSync"]).TotalMinutes >= syncCheckMinutes) {
        appState[objectName + "LastSync"] = DateTime.Now;

        if (objectValue != null)
          appState[objectName] = objectValue;
      }

      if (appState[objectName] != null)
        retVal = (T)appState[objectName];
      appState.UnLock();
      return retVal;
    }
    public static Object GetSetApplicationState(this HttpApplicationState appState, String objectName, Object objectValue = null, Int32 syncCheckMinutes = 0) {
      Object retVal = null;
      appState.Lock();
      if (appState[objectName + "LastSync"] == null || DateTime.Now.Subtract((DateTime)appState[objectName + "LastSync"]).TotalMinutes >= syncCheckMinutes) {
        appState[objectName + "LastSync"] = DateTime.Now;

        if (objectValue != null)
          appState[objectName] = objectValue;
      }

      if (appState[objectName] != null)
        retVal = appState[objectName];
      appState.UnLock();
      return retVal;
    }
    public static void SetApplicationState(this HttpApplicationState appState, String objectName, Object objectValue, Int32 syncCheckMinutes = 0) {
      appState.Lock();
      if (appState[objectName + "LastSync"] == null || DateTime.Now.Subtract((DateTime)appState[objectName + "LastSync"]).TotalMinutes >= syncCheckMinutes) {
        appState[objectName + "LastSync"] = DateTime.Now;
        appState[objectName] = objectValue;
      }

      appState.UnLock();
    }
    public static Object GetApplicationState(this HttpApplicationState appState, String objectName) {
      Object retVal = null;
      appState.Lock();
      if (appState[objectName] != null)
        retVal = appState[objectName];
      appState.UnLock();
      return retVal;
    }
    public static T GetApplicationState<T>(this HttpApplicationState appState, String objectName) {
      var retVal = default(T);
      appState.Lock();
      if (appState[objectName] != null)
        retVal = (T)appState[objectName];
      appState.UnLock();
      return retVal;
    }
  }
}