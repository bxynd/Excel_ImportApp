using ImportApp.Models;

namespace ImportApp.Repositories;

public interface IPersonnelRepository
{
    Task<List<Personnel>> GetListOfInsertedAsync(int[] ids);
    Task<int> UpdateRecordAsync(Personnel personnel);
    Task<Personnel> InsertSingleAndReturnAsync(Personnel item);
    Task<Personnel> FindSingleByIdAsync(int id);
}