namespace DoItYourself.Web.ViewModels.Projects
{
    using System.Collections.Generic;

    public class ProjectIndexViewModel
    {
        public IEnumerable<AllProjectsViewModel> Projects { get; set; }
    }
}
