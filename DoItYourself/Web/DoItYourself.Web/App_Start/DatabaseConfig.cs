namespace DoItYourself.Web.App_Start
{
    using System.Data.Entity;

    using Data;
    using Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DoItYourselfDbContext, Configuration>());
            DoItYourselfDbContext.Create().Database.Initialize(true);
        }
    }
}
