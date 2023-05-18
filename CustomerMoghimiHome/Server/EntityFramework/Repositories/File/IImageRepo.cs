using AutoMapper;
using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Server.EntityFramework.Entities.File;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.File;
using Microsoft.EntityFrameworkCore;

namespace CustomerMoghimiHome.Server.EntityFramework.Repositories.File;

public interface IImageRepo
{
    Task<long> AddImageAsync(ImageDto imageDto);
    Task<bool> IsImagePathExist(string imagePath);
    Task<List<ImageDto>> GetAllImages();
    Task<ImageDto> GetImageById(int id);
    Task<ImageDto> GetImageByPathAsync(string path);
}

public class ImageRepo : IImageRepo
{
    private DataContext _dataContext;
    private DbSet<ImageEntity> _ImageEntity;
    private readonly IMapper _mapper;

    public ImageRepo(DataContext dataContext, IMapper mapper) : base()
    {
        _dataContext = dataContext;
        _ImageEntity = _dataContext.Set<ImageEntity>();
        _mapper = mapper;
    }

    public async Task<long> AddImageAsync(ImageDto imageDto)
    {
        var isImagePathExist = await IsImagePathExist(imageDto.Path);
        if (!isImagePathExist)
        {
            var entity = _mapper.Map<ImageEntity>(imageDto);
            await _ImageEntity.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
            return entity.Id;
        }
        else
        {
            throw new Exception("Image Path Exist");
        }
    }

    public async Task<List<ImageDto>> GetAllImages()
    {
        var ImageEntityList = await _ImageEntity.ToListAsync();
        var imageDtoList = _mapper.Map<List<ImageDto>>(ImageEntityList);
        return imageDtoList;
    }

    public async Task<bool> IsImagePathExist(string imagePath)
    {
        var image = await _ImageEntity.FirstOrDefaultAsync(x => x.Path == imagePath);
        if (image == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public async Task<ImageDto> GetImageById(int id)
    {
        var imageEntity = await _ImageEntity
            .FirstOrDefaultAsync(x => x.Id == id);
        var imageDto = _mapper.Map<ImageDto>(imageEntity);
        return imageDto;
    }

    public async Task<ImageDto> GetImageByPathAsync(string path)
    {
        var imageEntity = await _ImageEntity.FirstOrDefaultAsync(x=>x.Path == path);
        return _mapper.Map<ImageDto>(imageEntity);
    }
}