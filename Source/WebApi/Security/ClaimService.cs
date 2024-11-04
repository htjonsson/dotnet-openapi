public interface IClaimService
{
    public bool IsAuthoriszed(string token);
}

public class ClaimService : IClaimService
{
    public static string BearerToken = "Bearer";

    private bool IsValidSecurityString(string token)
    {
        return true;
    }

    private string GetSecurityString(string token)
    {
        var values = token.Split(' ');

        if (values.Count() == 2 && values[0].Contains(BearerToken))
        {
            return values[1];
        }

        return string.Empty;  
    }

    public bool IsAuthoriszed(string token)
    {
        string securityString = GetSecurityString(token);

        if (false == string.IsNullOrEmpty(securityString))
        {
            return IsValidSecurityString(securityString);
        }

        return false;        
    }
}