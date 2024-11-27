using System.ComponentModel.DataAnnotations;

namespace Cmd.Models;

public class NonContainerModel
{
    [Required]
    [MaxLength(10)]
    public string Number { get; set; } = string.Empty;
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [MaxLength(30)]
    public string Title { get; set; } = string.Empty;
    [Required]
    [MaxLength(255)]
    public string Address1 { get; set; } = string.Empty;
    public string Address2 { get; set; } = string.Empty;
    public string Address3 { get; set; } = string.Empty;
    [Required]
    public string City { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public string CountryCode { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string SSNumber { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string PhoneLocal { get; set; } = string.Empty;    
    public string PhoneMobile { get; set; } = string.Empty;
    public string Fax { get; set; } = string.Empty;
    public string Telex { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string URL { get; set; } = string.Empty;
    public string JobTitleCode { get; set; } = string.Empty;
    public DateTime Modified { get; set; } = DateTime.MinValue;
}