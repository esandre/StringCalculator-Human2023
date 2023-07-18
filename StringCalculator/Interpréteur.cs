namespace StringCalculator;

public static class Interpréteur
{
    public static uint Add(string chaîne)
    {
        var partsAsString = chaîne.Split(',');
        var partsAsUint = partsAsString.Select(ParseOrThrow);
        return partsAsUint.Sum();
    }

    private static uint ParseOrThrow(string représentation)
    {
        try
        {
            return uint.Parse(représentation);
        }
        catch (OverflowException e)
        {
            throw new NombreNégatifException(représentation, e);
        }
    }
}