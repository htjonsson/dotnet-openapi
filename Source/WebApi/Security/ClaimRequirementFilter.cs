using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class ClaimRequirementFilter : IAuthorizationFilter
{
    private static string AuthorizationHeader = "Authorization";

    private readonly IClaimService _claimService;

    public ClaimRequirementFilter(IClaimService claimService)
    {
        _claimService = claimService;
    }

    // https://stackoverflow.com/questions/47324129/no-authenticationscheme-was-specified-and-there-was-no-defaultchallengescheme-f
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (context.HttpContext.Request.Headers.ContainsKey(AuthorizationHeader))
        {
            var token = context.HttpContext.Request.Headers[AuthorizationHeader].ToString();

            bool isAuthoriszed =  _claimService.IsAuthoriszed(token);

            if (isAuthoriszed is false)
            {
                context.Result = new UnauthorizedResult();
            }            
        }
        else
        {
            context.Result = new UnauthorizedResult();
        }
    }
}