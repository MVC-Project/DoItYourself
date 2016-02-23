namespace DoItYourself.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using Common.Constants;
    using Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
    }
}
