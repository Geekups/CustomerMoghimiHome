using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.File;

namespace CustomerMoghimiHome.Client.Pages.AdminPages.File;
public partial class AdminGalleryPage
{
    public List<ImageDto> ImageDtoList = new();

    protected override async Task OnInitializedAsync()
    {
        ImageDtoList = await GetImageList();
    }

    public async Task<List<ImageDto>> GetImageList()
    {
        return await _httpService.GetValueList<ImageDto>(FileRoutes.FileApi + CRUDRouts.ReadAll);
    }

    public async Task OnChange()
    {
        ImageDtoList = await GetImageList();
    }
}