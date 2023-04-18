using CustomerMoghimiHome.Shared.EntityFramework.Common;

namespace CustomerMoghimiHome.Shared.EntityFramework.DTO.File;
public class ImageDto : BaseDto
{
    public string Path { get; set; }
    public string Alt { get; set; }
}