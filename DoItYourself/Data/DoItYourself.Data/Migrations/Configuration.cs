namespace DoItYourself.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<DoItYourselfDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DoItYourselfDbContext context)
        {
            DataSeeder.SeedCountries(context);
            DataSeeder.SeedCategories(context);
            DataSeeder.SeedRoles(context);
            DataSeeder.SeedAdministrator(context);
        }
    }
}
