﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
	public class MoviesController : Controller
	{
		private ApplicationDbContext _context;

		public MoviesController()
		{
			_context = new ApplicationDbContext();
		}

		public ActionResult Index()
		{
			if (User.IsInRole(RoleName.CanManageMovies))
				return View("List");

			return View("ReadOnlyList");
		}

		[Authorize(Roles = RoleName.CanManageMovies)]
		public ActionResult New()
		{
			var viewModel = new MovieFormViewModel
			{
				Genres = _context.Genres.ToList()
			};

			return View("MovieForm", viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = RoleName.CanManageMovies)]
		public ActionResult Save(Movie movie)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new MovieFormViewModel
				{
					Movie = movie,
					Genres = _context.Genres.ToList()
				};

				return View("MovieForm", viewModel);
			}

			if (movie.Id == 0)
			{
				movie.DateAdded = DateTime.Now;
				_context.Movies.Add(movie);
			}
			else
			{
				var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

				movieInDb.Name = movie.Name;
				movieInDb.ReleaseDate = movie.ReleaseDate;
				movieInDb.Genre = movie.Genre;
				movieInDb.NumberInStock = movie.NumberInStock;
			}

			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		[Authorize(Roles = RoleName.CanManageMovies)]
		public ActionResult Edit(int? id)
		{
			var viewModel = new MovieFormViewModel
			{
				Movie = _context.Movies.SingleOrDefault(m => m.Id == id),
				Genres = _context.Genres.ToList()
			};

			return View("MovieForm", viewModel);
		}

		[Authorize(Roles = RoleName.CanManageMovies)]
		public ActionResult Details(int? id)
		{
			var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

			if (movie == null)
				return HttpNotFound();

			return View(movie);
		}

		// GET: Movies
		public ActionResult Random()
		{
			var movie = new Movie() { Name = "Shrek!" };
			var customers = new List<Customer>
			{
				new Customer {Name = "Customer 1"},
				new Customer {Name = "Customer 2"}
			};

			var viewModel = new RandomMovieViewModel
			{
				Movie = movie,
				Customers = customers
			};

			return View(viewModel);
		}
	}
}