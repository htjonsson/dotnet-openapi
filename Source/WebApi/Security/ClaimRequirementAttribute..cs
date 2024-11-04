using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

// https://stackoverflow.com/questions/31464359/how-do-you-create-a-custom-authorizeattribute-in-asp-net-core
public class ClaimRequirementAttribute : TypeFilterAttribute
{
    public ClaimRequirementAttribute() : base(typeof(ClaimRequirementFilter))
    {
    }
}