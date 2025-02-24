using Bounteous.Data;
using Microsoft.EntityFrameworkCore;

namespace Advantive.Services.Context;

public class AdvantiveDbContext(DbContextOptions<DbContextBase> options, IDbContextObserver observer)
    : DbContextBase(options, observer)
{
    protected override void RegisterModels(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("advantive");
    }
}