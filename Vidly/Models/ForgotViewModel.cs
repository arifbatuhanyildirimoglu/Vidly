using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
	public class ForgotViewModel
	{
		[Required]
		[Display(Name = "Email")]
		public string Email { get; set; }
	}
}