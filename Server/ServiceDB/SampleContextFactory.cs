using Microsoft.EntityFrameworkCore.Design;

namespace ServiceDB;

public class SampleContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
{
    public ApplicationContext CreateDbContext(string[] args)
    {
        return new ApplicationContext(ApplicationContext.GetDb());
    }
}