using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;

namespace Apartments.WebUI {
  public static class Extensions {
    public static IEnumerable<T> SortBy<T, K>(this IEnumerable<T> enumerable,
                                              Func<T, K> keySelector,
                                              SortDirection sortDirection)
      => sortDirection == SortDirection.Ascending ? enumerable.OrderBy(keySelector) : enumerable.OrderByDescending(keySelector);
  }
}