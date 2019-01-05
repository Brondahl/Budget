using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Budgetting.DbModels.Helpers
{
  public class DateColumnAttribute : ColumnAttribute
  {
    public DateColumnAttribute()
    {
      TypeName = "date";
    }
  }
  public class MoneyColumnAttribute : ColumnAttribute
  {
    public MoneyColumnAttribute()
    {
      TypeName = "decimal(9,2)";
    }
  }

}
