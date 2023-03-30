using Dapper;
using ImportApp.Context;
using ImportApp.Models;

namespace ImportApp.Repositories;

public class PersonnelRepository : IPersonnelRepository
{
    private readonly DapperContext _context;

    public PersonnelRepository(DapperContext context)
    {
        _context = context;
    }
    
    public async Task<List<Personnel>> GetListOfInsertedAsync(int[] ids){
        
        //establish connection to the database
        using var connection =_context.CreateConnection();
        //get the list from db
        var list = (await connection.QueryAsync<Personnel>("SELECT * FROM Personnel WHERE Id In @Ids", new {Ids = ids})).ToList();
        return list;

    }

    public async Task<int> UpdateRecordAsync(Personnel personnel)
    {
        //establish connection to the database
        using var connection =_context.CreateConnection();
       
        //update the record
        return await connection.ExecuteAsync("UPDATE Personnel SET PayrollNumber=@PayrollNumber,Forename=@Forename," +
                                      "Surename=@Surename,DateOfBirth=@DateOfBirth,Telephone=@Telephone,Mobile=@Mobile,Address=@Address," +
                                      "Address2=@Address2,Postcode=@Postcode,EmailHome=@EmailHome,StartDate=@StartDate WHERE Id = @Id",
            personnel);
    }

    public async Task<Personnel> InsertSingleAndReturnAsync(Personnel item)
    {
        //establish connection to the database
        using var connection =_context.CreateConnection();

        //insert the record and return it back with an Id
        return await connection.QuerySingleAsync<Personnel>("INSERT INTO Personnel(PayrollNumber,Forename," +
                                                            "Surename,DateOfBirth,Telephone,Mobile,Address," +
                                                            "Address2,Postcode,EmailHome,StartDate) OUTPUT inserted.* VALUES (@PayrollNumber,@Forename," +
                                                            "@Surename,@DateOfBirth,@Telephone,@Mobile,@Address," +
                                                            "@Address2,@Postcode,@EmailHome,@StartDate) ", item);
    }

    public async Task<Personnel> FindSingleByIdAsync(int id)
    {
        //establish connection to the database
        using var connection =_context.CreateConnection();

        //query single by an Id
        return await connection.QuerySingleAsync<Personnel>("SELECT * FROM Personnel WHERE Id = @Id",new {Id = id});
    }
}