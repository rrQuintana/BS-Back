using System;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Data;

public static class DataExtensions
{
  public static async Task MigrateDatabaseAsync(this WebApplication app)
  {
    using var serviceScope = app.Services.CreateScope();
    var context = serviceScope.ServiceProvider.GetRequiredService<CategoriesContext>();
    await context.Database.MigrateAsync();
  }
}
