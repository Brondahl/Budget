using System;
using System.Collections.Generic;
using System.Linq;

namespace Budgetting.Common
{
  public static class MiscUtilities
  {
    public static string StringJoin(this IEnumerable<string> set, string separator)
    {
      return String.Join(separator, set);
    }

    public static string StringJoinWithNewLine(this IEnumerable<string> set)
    {
      return set.StringJoin(Environment.NewLine);
    }

    public static bool In<T>(this T value, params T[] collection) => value.In(collection.ToList());
    public static bool In<T>(this T value, IEnumerable<T> collection)
    {
      return collection.Contains(value);
    }
  }
}
