using System.ComponentModel.DataAnnotations;

namespace Cmd.Models;

[Container]
[Metadata("ContainerModel")]
public class ContainerModel
{
    [Metadata("Number")]
    public string Number { get; set; } = string.Empty;
    [Metadata("Name")]
    public string Name { get; set; } = string.Empty;
    [Metadata("Title")]
    public string Title { get; set; } = string.Empty;
    [Metadata("Address1")]
    public string Address1 { get; set; } = string.Empty;
    [Metadata("Address2")]
    public string Address2 { get; set; } = string.Empty;
    [Metadata("Address3")]
    public string Address3 { get; set; } = string.Empty;
    [Required]
    [Metadata("City")]
    public string City { get; set; } = string.Empty;
    [Metadata("ZipCode")]
    public string ZipCode { get; set; } = string.Empty;
    [Metadata("CountryCode")]
    public string CountryCode { get; set; } = string.Empty;
    [Metadata("Department")]
    public string Department { get; set; } = string.Empty;
    [Metadata("SSNumber")]
    public string SSNumber { get; set; } = string.Empty;
    [Metadata("Phone")]
    public string Phone { get; set; } = string.Empty;
    [Metadata("PhoneLocal")]
    public string PhoneLocal { get; set; } = string.Empty;
    [Metadata("PhoneMobile")]    
    public string PhoneMobile { get; set; } = string.Empty;
    [Metadata("Fax")]
    public string Fax { get; set; } = string.Empty;
    [Metadata("Telex")]
    public string Telex { get; set; } = string.Empty;
    [Metadata("Email")]
    public string Email { get; set; } = string.Empty;
    [Metadata("URL")]
    public string URL { get; set; } = string.Empty;
    [Metadata("JobTitleCode")]
    public string JobTitleCode { get; set; } = string.Empty;
    [Metadata("Modified")]
    public DateTime Modified { get; set; } = DateTime.MinValue;
}