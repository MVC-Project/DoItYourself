namespace DoItYourself.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using Data.Models;

    public class HomeIndexViewModel
    {
        public IEnumerable<Project> Projects { get; set; }
    }
}
