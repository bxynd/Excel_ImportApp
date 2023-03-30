using System.ComponentModel.DataAnnotations;

namespace ImportApp.Models;

public class Personnel
{
    [Key] public int Id { get; set; }

    public string PayrollNumber { get; set; }
    public string Forename { get; set; }
    public string Surename { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int Telephone { get; set; }
    public int Mobile { get; set; }
    public string Address { get; set; }
    public string Address2 { get; set; }
    public string Postcode { get; set; }
    public string EmailHome { get; set; }
    public DateTime StartDate { get; set; }
}