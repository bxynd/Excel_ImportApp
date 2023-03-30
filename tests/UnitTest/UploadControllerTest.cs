using ImportApp.Models;
using ImportApp.Services;
using Microsoft.AspNetCore.Http;
using Moq;

namespace UnitTest;

public class UploadControllerTest
{
    private readonly Mock<IUploadService> _uploadServiceMock = new Mock<IUploadService>();

    private readonly Mock<IFormFile> _fileMock = new Mock<IFormFile>();
    [Fact]
    public async void GetBackWithListAsync_ReturnsListOfPersonnel()
    {
        int[] ids = { 1,2 };
        var expected = new List<Personnel>
        {
            new Personnel
            {
                Id = 1,
                Address = "whatever",
                Address2 = "whatever2",
                DateOfBirth = DateTime.Now,
                StartDate = DateTime.Now.AddDays(1),
                EmailHome = "johndoe@gmail.com",
                Forename = "John",
                Surename = "Doe",
                Mobile = 1235123,
                PayrollNumber = "SS213"
            },
            new Personnel
            {
                Id = 2,
                Address = "anything",
                Address2 = "anything2",
                DateOfBirth = DateTime.Now.AddDays(1),
                StartDate = DateTime.Now.AddDays(2),
                EmailHome = "jack812@gmail.com",
                Forename = "Jack",
                Surename = "Hachi",
                Mobile = 3123511,
                PayrollNumber = "AA213"
            }
        };
        
        //Arrange
        _uploadServiceMock.Setup(s => s.GetBackWithListAsync(ids))
            .ReturnsAsync(expected);

        //Act
        var result = await _uploadServiceMock.Object.GetBackWithListAsync(ids);

        //Assert
        Assert.Equal(expected, result);
    }
    [Fact]
    public async void InsertManyAndReturnAsync_ReturnsArrayOfInts()
    {
        var expected = new List<Personnel>
        {
            new Personnel
            {
                Id = 1,
                Address = "whatever",
                Address2 = "whatever2",
                DateOfBirth = DateTime.Now,
                StartDate = DateTime.Now.AddDays(1),
                EmailHome = "johndoe@gmail.com",
                Forename = "John",
                Surename = "Doe",
                Mobile = 1235123,
                PayrollNumber = "SS213"
            },
            new Personnel
            {
                Id = 2,
                Address = "anything",
                Address2 = "anything2",
                DateOfBirth = DateTime.Now.AddDays(1),
                StartDate = DateTime.Now.AddDays(2),
                EmailHome = "jack812@gmail.com",
                Forename = "Jack",
                Surename = "Hachi",
                Mobile = 3123511,
                PayrollNumber = "AA213"
            }
        };
        //Arrange
        _uploadServiceMock.Setup(s => s.InsertManyAndReturnAsync(_fileMock.Object))
            .ReturnsAsync(expected);

        //Act
        var result = await _uploadServiceMock.Object.InsertManyAndReturnAsync(_fileMock.Object);

        //Assert
        Assert.Equal(expected, result);
    }
    [Fact]
    public async void FindByIdAsyncTest_ReturnsFoundPersonnel()
    {
        var id = 1;
        var expected = new Personnel
        {
            Id = 1,
            Address = "whatever",
            Address2 = "whatever2",
            DateOfBirth = DateTime.Now,
            StartDate = DateTime.Now.AddDays(1),
            EmailHome = "johndoe@gmail.com",
            Forename = "John",
            Surename = "Doe",
            Mobile = 1235123,
            PayrollNumber = "SS213"
        };
        //Arrange
        _uploadServiceMock.Setup(s => s.FindByIdAsync(id))
            .ReturnsAsync(expected);

        //Act
        var result = await _uploadServiceMock.Object.FindByIdAsync(id);

        //Assert
        Assert.Equal(expected, result);
    }
    [Fact]
    public async void UpdateRecordAndGetBackAsync_ReturnsListOfPersonnel()
    {
        int[] ids = { 1,2 };
        var expected = new List<Personnel>
        {
            new Personnel
            {
                Id = 1,
                Address = "whateveredited",
                Address2 = "whateveredited2",
                DateOfBirth = DateTime.Now,
                StartDate = DateTime.Now.AddDays(1),
                EmailHome = "johndoe@gmail.com",
                Forename = "John",
                Surename = "Doe",
                Mobile = 1235123,
                PayrollNumber = "SS213"
            },
            new Personnel
            {
                Id = 2,
                Address = "anything",
                Address2 = "anything2",
                DateOfBirth = DateTime.Now.AddDays(1),
                StartDate = DateTime.Now.AddDays(2),
                EmailHome = "jack812@gmail.com",
                Forename = "Jack",
                Surename = "Hachi",
                Mobile = 3123511,
                PayrollNumber = "AA213"
            }
        };
        
        var input = new Personnel
        {
            Id = 1,
            Address = "whateveredited",
            Address2 = "whateveredited2",
            DateOfBirth = DateTime.Now,
            StartDate = DateTime.Now.AddDays(1),
            EmailHome = "johndoe@gmail.com",
            Forename = "John",
            Surename = "Doe",
            Mobile = 1235123,
            PayrollNumber = "SS213"
        };
        
        //Arrange
        _uploadServiceMock.Setup(s => s.UpdateRecordAndGetBackAsync(input,ids,input.Id))
            .ReturnsAsync(expected);

        //Act
        var result = await _uploadServiceMock.Object.UpdateRecordAndGetBackAsync(input,ids,input.Id);

        //Assert
        Assert.Equal(expected, result);
    }
}