using ImportApp.Models;
using ImportApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ImportApp.Controllers;

public class UploadController : Controller
{
    private readonly IUploadService _uploadService;

    public UploadController(IUploadService uploadService)
    {
        //inject upload service with logic implementation
        _uploadService = uploadService;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> GetBack(int[] result)
    {
        //get inserted rows
        var list = await _uploadService.GetBackWithListAsync(result);
        
        return View("Index",list);
    }
    [HttpPost]
    public async Task<IActionResult> FileUpload(IFormFile file)
    {
        if (file == null)
        {
            //if file was not submitted go to index page
            return Redirect("Index");
        }
        
        //call the the service with logic of inserting data from excel file
        var list = await _uploadService.InsertManyAndReturnAsync(file);
        return View("Index", list);
    }
    
    [HttpPost("UpdatePage/{id:int}")]
    public async Task<IActionResult> UpdatePage(int[] result,[FromRoute] int id)
    {
        //pass list of ids of records
        ViewBag.recordIDs = result;
        
        // pass the data to form to be seeded with data of the record to be updated
        ViewBag.record = await _uploadService.FindByIdAsync(id);
        
        return View("Edit");
    }

    [HttpPost("UpdateRecord/{id:int}")]
    public async Task<IActionResult> UpdateRecord(Personnel personnel, int[] result, [FromRoute] int id)
    {
        //call the service to handle update that return the list with now updated record
        var list = await _uploadService.UpdateRecordAndGetBackAsync(personnel, result, id);
        return View("Index", list);
    }
}