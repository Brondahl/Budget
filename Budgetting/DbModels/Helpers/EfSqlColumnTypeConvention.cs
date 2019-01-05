using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Budgetting.DbModels.Helpers
{
  public interface IEfSqlColumnTypeConvention
  {
    Type ClrType { get; }
    Action<SqlServerPropertyAnnotations> ApplyConvention { get; }
  }

  public class EfSqlColumnTypeConvention<TClrTypeParam> : IEfSqlColumnTypeConvention
  {
    public Type ClrType => typeof(TClrTypeParam);
    public Action<SqlServerPropertyAnnotations> ApplyConvention { get; set; }

    public EfSqlColumnTypeConvention(Action<SqlServerPropertyAnnotations> convention)
    {
      ApplyConvention = convention;
    }

    public EfSqlColumnTypeConvention(string sqlColumnType)
      : this((annotations => annotations.ColumnType = sqlColumnType))
    {}
  }

  public static class ModelBuilderExtension
  {
    public static ModelBuilder ApplyColumTypeConventions(this ModelBuilder builder, params IEfSqlColumnTypeConvention[] conventions)
    {
      var modelColumns = builder.Model
        .GetEntityTypes()
        .SelectMany(entity => entity.GetProperties())
        .ToList();

      foreach (var convention in conventions)
      {
        ApplyConvention(modelColumns, convention);
      }
      return builder;
    }

    private static void ApplyConvention(IEnumerable<IMutableProperty> modelColumns, IEfSqlColumnTypeConvention convention)
    {
      var matchingColumns = modelColumns.Where(p => p.ClrType.IsTypeOrNullable(convention.ClrType));

      foreach (IMutableProperty column in matchingColumns)
      {
        convention.ApplyConvention(column.SqlServer());
      }
    }

    private static bool IsTypeOrNullable(this Type typeToTest, Type typeToFind)
    {
      var underlyingTypeToTest = Nullable.GetUnderlyingType(typeToTest) ?? typeToTest;
      return underlyingTypeToTest == typeToFind;
    }
  }
}
