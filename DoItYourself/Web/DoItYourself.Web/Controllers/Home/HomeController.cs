namespace DoItYourself.Web.Controllers.Home
{
    using System.Linq;
    using System.Web.Mvc;

    using Services.Data.Contracts;
    using Services.Web;

    using ViewModels.Home;
    using Data.Models;
    using System.Collections.Generic;
    public class HomeController : BaseController
    {
        private readonly IProjectService projects;
        private readonly ICacheService cache;

        public HomeController(IProjectService projects, ICacheService cache)
        {
            this.projects = projects;
            this.cache = cache;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Home()
        {
            var projects = this.cache.Get<IEnumerable<Project>>(
               "newestProjects",
               () =>
               {
                   var newestProjectsList = new List<Project>();

                   newestProjectsList.AddRange(this.projects.TopNewestProjects(3).ToList());

                   return newestProjectsList;
               },
                2 * 60 * 60);

            var viewModel = new HomeIndexViewModel
            {
                Projects = projects
            };

            return this.View(viewModel);
        }

        public ActionResult About()
        {
            return this.View();
        }

        public ActionResult Contacts()
        {
            return this.View();
        }
    }
}
