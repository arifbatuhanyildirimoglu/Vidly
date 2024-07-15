using System;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
	public class MoviesController : Controller
	{
		// GET: Movies
		public ActionResult Random()
		{
			var movie = new Movie() { Name = "Shrek!" };

			return View(movie);
		}

		public ActionResult Edit(int id)
		{
			return Content("id=" + id);
		}

		public ActionResult Index(int? pageIndex, string sortBy)
		{
			if (!pageIndex.HasValue)
				pageIndex = 1;

			if (String.IsNullOrEmpty(sortBy))
				sortBy = "Name";

			return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
		}

		[Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
		public ActionResult ByReleaseDate(int year, int month)
		{
			return Content(year + "/" + month);
		}
	}
}