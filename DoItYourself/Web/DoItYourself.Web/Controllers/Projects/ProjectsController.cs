namespace DoItYourself.Web.Controllers.Projects
{
    using System;
    using System.Web.Mvc;
    using System.Linq;

    using Data.Models;
    using Infrastructure.Populator;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;

    using ViewModels.Projects;
    using System.IO;
    using Common.Constants;
    using Infrastructure.Mapping;
    public class ProjectsController : BaseController
    {
        private readonly IProjectService projects;
        private readonly IDropDownListPopulator populator;
        private readonly IUserService users;

        public ProjectsController(IUserService users, IProjectService projects, IDropDownListPopulator populator)
        {
            this.projects = projects;
            this.populator = populator;
            this.users = users;
        }

        public ActionResult Index()
        {
            if (this.ModelState.IsValid)
            {
                var projects = this.projects.AllApprovedProjects().To<AllProjectsViewModel>().ToList();

                var viewModel = new ProjectIndexViewModel
                {
                    Projects = projects
                };

                return this.View(viewModel);
            }

            return this.View();
        }

        public ActionResult Details(int id)
        {
            var project = this.projects.GetById(id);

            return this.View(project);
        }

        [Authorize]
        public ActionResult Add(ProjectCreateViewModel model)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                this.RedirectToAction("Login", "Accounnt");
            }

            if (this.ModelState.IsValid)
            {
                var project = new Project()
                {
                    Title = model.Title,
                    Content = model.Content,
                    IsApproved = true,
                    UserId = this.User.Identity.GetUserId(),
                    CategoryId = 5,
                    CreatedOn = DateTime.Now
                };

                if (model.Image != null)
                {
                    string filename = Path.GetFileName(model.Image.FileName);
                    string folderPath = this.Server.MapPath("~/Resources/Images/Projects/" + this.User.Identity.GetUserId());
                    string imagePath = folderPath + "/" + filename;
                    string imageUrl = "/Resources/Images/Projects/" + this.User.Identity.GetUserId() + "/" + filename;

                    if (!Directory.Exists(folderPath))
                    {
                        DirectoryInfo directory = Directory.CreateDirectory(folderPath);
                    }

                    model.Image.SaveAs(imagePath);
                    project.Image = new Image()
                    {
                        Path = imageUrl,
                        CreatedOn = DateTime.Now
                    };
                }
                else
                {
                    project.Image = new Image()
                    {
                        Path = "http://princeps.bg/blog/wp-content/uploads/2010/03/no_image.gif",
                        CreatedOn = DateTime.Now
                    };
                }

                this.projects.AddProject(project);
            }

            return this.View();
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetCategories()
        {
            this.ViewData["categories"] = this.populator.GetCategories();
            return this.View();
        }
    }
}