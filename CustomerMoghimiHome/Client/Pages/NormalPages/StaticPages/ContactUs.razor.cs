using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Customer;

namespace CustomerMoghimiHome.Client.Pages.NormalPages.StaticPages;

public partial class ContactUs
{
	#region Pre-Load
	ContactFormDto model = new();
	#endregion

	#region Actions
	public async Task Add()
	{
		using var response = await _httpService.PostValue(CustomerRoute.ContactForm + CRUDRouts.Create, model);
	}
	#endregion
}
