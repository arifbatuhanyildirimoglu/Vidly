using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
	public class MoviesController : ApiController
	{
		private ApplicationDbContext _context;

		public MoviesController()
		{
			_context = new ApplicationDbContext();
		}

		// GET /api/movies
		[HttpGet]
		public IHttpActionResult GetMovies(string query = null)
		{
			var moviesQuery = _context.Movies
				.Include(m => m.Genre)
				.Where(m => m.NumberAvailable > 0);

			if (!String.IsNullOrWhiteSpace(query))
				moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

			var movieDtos = moviesQuery.ToList().Select(Mapper.Map<Movie, MovieDto>);

			return Ok(movieDtos);
		}

		// GET /api/movies/id
		[HttpGet]
		public IHttpActionResult GetMovie(int id)
		{
			var movie = _context.Movies.FirstOrDefault(x => x.Id == id);

			if (movie == null)
				return NotFound();

			var movieDto = Mapper.Map<Movie, MovieDto>(movie);

			return Ok(movieDto);
		}

		// POST /api/movies
		[HttpPost]
		[Authorize(Roles = RoleName.CanManageMovies)]
		public IHttpActionResult CreateMovie(MovieDto movieDto)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var movie = Mapper.Map<MovieDto, Movie>(movieDto);

			_context.Movies.Add(movie);
			_context.SaveChanges();

			movieDto.Id = movie.Id;
			return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
		}

		// PUT /api/movies/id
		[HttpPut]
		[Authorize(Roles = RoleName.CanManageMovies)]
		public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var movie = _context.Movies.FirstOrDefault(x => x.Id == id);

			if (movie == null)
				return NotFound();

			Mapper.Map(movieDto, movie);

			_context.SaveChanges();

			return Ok(movieDto);
		}

		// DELETE /api/movies/id
		[HttpDelete]
		[Authorize(Roles = RoleName.CanManageMovies)]
		public IHttpActionResult DeleteMovie(int id)
		{
			var movie = _context.Movies.FirstOrDefault(x => x.Id == id);

			if (movie == null)
				return NotFound();

			_context.Movies.Remove(movie);
			_context.SaveChanges();

			return Ok();
		}
	}
}
