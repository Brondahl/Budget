using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budgetting.Helpers
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

  }
}
