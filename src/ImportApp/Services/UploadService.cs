using System.Globalization;
using CsvHelper;
using ImportApp.Models;
using ImportApp.Repositories;

namespace ImportApp.Services;

public class UploadService : IUploadService
{
    private readonly IPersonnelRepository _personnelRepository;

    public UploadService(IPersonnelRepository personnelRepository)
    {
        _personnelRepository = personnelRepository;
    }

    public async Task<List<Personnel>> InsertManyAndReturnAsync(IFormFile file)
    {
        //read file from stream and parse it using csvhelper
        var reader = new StreamReader(file.OpenReadStream());
        var csv = new CsvReader(reader, CultureInfo.GetCultureInfo("en-GB"));
        csv.Context.RegisterClassMap<PersonnelClassMap>();
        var records = csv.GetRecords<Personnel>().ToList();
        
        //prepare list for inserted values to the database
        var list = new List<Personnel>();
        foreach (var item in records)
            list.Add(await _personnelRepository.InsertSingleAndReturnAsync(item));

        return list;
    }

    public async Task<List<Personnel>> GetBackWithListAsync(int[] ids)
    {
        return await _personnelRepository.GetListOfInsertedAsync(ids);
    }

    public async Task<List<Personnel>> UpdateRecordAndGetBackAsync(Personnel personnel, int[] ids, int id)
    {
        personnel.Id = id;
        await _personnelRepository.UpdateRecordAsync(personnel);
        return await _personnelRepository.GetListOfInsertedAsync(ids);
    }

    public async Task<Personnel> FindByIdAsync(int id)
    {
        return await _personnelRepository.FindSingleByIdAsync(id);
    }
}