using CsvHelper.Configuration;

namespace ImportApp.Models;

public sealed class PersonnelClassMap : ClassMap<Personnel>
{
    public PersonnelClassMap()
    {
        Map(p => p.PayrollNumber).Name("Personnel_Records.Payroll_Number");
        Map(p => p.Forename).Name("Personnel_Records.Forenames");
        Map(p => p.Surename).Name("Personnel_Records.Surname");
        Map(p => p.DateOfBirth).Name("Personnel_Records.Date_of_Birth");
        Map(p => p.Telephone).Name("Personnel_Records.Telephone");
        Map(p => p.Mobile).Name("Personnel_Records.Mobile");
        Map(p => p.Address).Name("Personnel_Records.Address");
        Map(p => p.Address2).Name("Personnel_Records.Address_2");
        Map(p => p.Postcode).Name("Personnel_Records.Postcode");
        Map(p => p.EmailHome).Name("Personnel_Records.EMail_Home");
        Map(p => p.StartDate).Name("Personnel_Records.Start_Date");
    }
}