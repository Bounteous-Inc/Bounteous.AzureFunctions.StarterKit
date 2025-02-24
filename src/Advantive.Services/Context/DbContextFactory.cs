using Advantive.Services.Constants;
using Bounteous.Data;
using Bounteous.Data.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace Advantive.Services.Context;

public interface IDbContextFactory
{
    AdvantiveDbContext Create();
}

public class DbContextFactory : SqlServerDbContextFactory<AdvantiveDbContext>, IDbContextFactory
{
    public DbContextFactory(IConnectionBuilder connectionBuilder, IDbContextObserver observer) 
        : base(connectionBuilder, observer)
    {
    }

    protected override AdvantiveDbContext Create(DbContextOptions<DbContextBase> options, IDbContextObserver observer)
    {
        var context = new AdvantiveDbContext(options, observer);
        context.WithUserId(SystemUser.User.Id); //the default audit user
        return context;
    }
}