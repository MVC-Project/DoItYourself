namespace DoItYourself.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using DoItYourself.Common.Constants;
    using DoItYourself.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
    }
}
