using System.Web.Mvc;

namespace Vidly.Controllers
{
	[AllowAnonymous]
	public class HomeController : Controller
	{
		//Caching Enabled
		//[OutputCache(Duration = 50, Location = OutputCacheLocation.Server, VaryByParam = "*")]
		//Caching Disabled
		[OutputCache(Duration = 0, VaryByParam = "*", NoStore = true)]
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}