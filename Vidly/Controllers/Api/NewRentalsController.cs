using System;
using System.Web.Http;
using Vidly.Dtos;

namespace Vidly.Controllers.Api
{
	public class NewRentalsController : ApiController
	{
		[HttpPost]
		public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
		{
			throw new NotImplementedException();
		}
	}
}
