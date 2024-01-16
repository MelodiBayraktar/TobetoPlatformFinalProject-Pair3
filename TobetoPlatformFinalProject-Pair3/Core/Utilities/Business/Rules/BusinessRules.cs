using Core.Utilities.Results;

namespace Core.Utilities.Business.Rules;

public class BusinessRules
{
    //dönüş tipi düzeltilecek
    public static IResult Run(params IResult[] logics)
    {
        foreach (var logic in logics)
        {
            if (!logic.Success)
            {
                return logic;
            }
        }

        return null;
    }
}