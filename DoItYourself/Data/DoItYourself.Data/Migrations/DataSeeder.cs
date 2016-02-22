namespace DoItYourself.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    using DoItYourself.Common.Constants;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;

    public static class DataSeeder
    {
        public static void SeedAdministrator(DoItYourselfDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            const string AdministratorUserName = "dimitar.dzhurenov@gmail.com";
            const string AdministratorPassword = "123456q";

            var userManager = new UserManager<User>(new UserStore<User>(context));

            var administrator = new User
            {
                UserName = AdministratorUserName,
                Email = AdministratorUserName,
                FirstName = "Dimitar",
                LastName = "Dzhurenov",
                Image = new Image()
                {
                    Path = GlobalConstants.AdministratorProfilePicture,
                    CreatedOn = DateTime.Now
                },
                Location = new Location()
                {
                    City = "Sofia",
                    CountryId = 32,
                    CreatedOn = DateTime.Now
                }
            };

            userManager.Create(administrator, AdministratorPassword);
            userManager.AddToRole(administrator.Id, GlobalConstants.AdministratorRoleName);
            userManager.AddToRole(administrator.Id, GlobalConstants.UserRoleName);

            context.SaveChanges();
        }

        public static void SeedUser(DoItYourselfDbContext context)
        {
            const string UserUserName = "vasil.ivantchev@abv.bg";
            const string UserPassword = "123456q";

            var userManager = new UserManager<User>(new UserStore<User>(context));

            var user = new User
            {
                UserName = UserUserName,
                Email = UserUserName,
                FirstName = "Vasil",
                LastName = "Ivantchev",
                Image = new Image()
                {
                    Path = "https://scontent-frt3-1.xx.fbcdn.net/hphotos-xpl1/v/t1.0-0/p206x206/11043535_10204106159197177_5638542303422524290_n.jpg?oh=4b23cd3ffbac51ee624c13828b6dd786&oe=5770CDC5",
                    CreatedOn = DateTime.Now
                },
                Location = new Location()
                {
                    City = "Kyustendil",
                    CountryId = 35,
                    CreatedOn = DateTime.Now
                }
            };

            userManager.Create(user, UserPassword);
            userManager.AddToRole(user.Id, GlobalConstants.UserRoleName);

            context.SaveChanges();
        }

        public static void SeedRoles(DoItYourselfDbContext context)
        {
            if (context.Roles.Any())
            {
                return;
            }

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            roleManager.Create(new IdentityRole { Name = GlobalConstants.AdministratorRoleName });
            roleManager.Create(new IdentityRole { Name = GlobalConstants.UserRoleName });

            context.SaveChanges();
        }

        public static void SeedCountries(DoItYourselfDbContext context)
        {
            if (context.Countries.Any())
            {
                return;
            }

            var reader = new StreamReader("C:\\Users\\dsd36\\Desktop\\Do It Yourself\\DoItYourself\\Data\\DoItYourself.Data\\countries.txt");

            using (reader)
            {
                var line = reader.ReadLine();

                while (line != null && line != string.Empty)
                {
                    var data = line.Split('=');
                    string name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(data[1].ToLower());
                    var country = new Country()
                    {
                        Name = name,
                        Abbreviation = data[0],
                        CreatedOn = DateTime.Now
                    };

                    context.Countries.Add(country);
                    line = reader.ReadLine();
                }
            }

            context.SaveChanges();
        }

        public static void SeedCategories(DoItYourselfDbContext context)
        {
            if (context.Categories.Any())
            {
                return;
            }

            var reader = new StreamReader("C:\\Users\\dsd36\\Desktop\\Do It Yourself\\DoItYourself\\Data\\DoItYourself.Data\\categories.txt");
            var categories = new HashSet<string>();

            using (reader)
            {
                var line = reader.ReadLine();

                while (line != null && line != string.Empty)
                {
                    categories.Add(line);
                    line = reader.ReadLine();
                }

                foreach (var categoryName in categories)
                {
                    var category = new Category()
                    {
                        Name = categoryName,
                        CreatedOn = DateTime.Now
                    };

                    context.Categories.Add(category);
                }
            }

            context.SaveChanges();
        }
    }
}
