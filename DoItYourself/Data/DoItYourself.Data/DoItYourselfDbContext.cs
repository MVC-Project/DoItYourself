namespace DoItYourself.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Common.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class DoItYourselfDbContext : IdentityDbContext<User>
    {
        public DoItYourselfDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<Image> Images { get; set; }

        public IDbSet<Location> Locations { get; set; }

        public IDbSet<Project> Projects { get; set; }

        public IDbSet<ProjectComment> ProjectComments { get; set; }

        public IDbSet<Question> Questions { get; set; }

        public IDbSet<QuestionComment> QuestionComments { get; set; }

        public IDbSet<Rating> Ratings { get; set; }

        public IDbSet<Video> Videos { get; set; }

        public static DoItYourselfDbContext Create()
        {
            return new DoItYourselfDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
