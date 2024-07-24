using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
			Mapper.CreateMap<Customer, CustomerDto>();

			Mapper.CreateMap<Movie, MovieDto>().ForMember(m => m.Id, opt => opt.Ignore());
			Mapper.CreateMap<MovieDto, Movie>();

			Mapper.CreateMap<MembershipType, MembershipTypeDto>();
		}
	}
}