using ImportApp.Models;

namespace ImportApp.Services;

public interface IUploadService
{
    Task<List<Personnel>> InsertManyAndReturnAsync(IFormFile file);
    Task<List<Personnel>> GetBackWithListAsync(int[] ids);
    Task<List<Personnel>> UpdateRecordAndGetBackAsync(Personnel personnel, int[] ids, int id);
    Task<Personnel> FindByIdAsync(int id);
}