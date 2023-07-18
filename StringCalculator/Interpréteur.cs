namespace StringCalculator;

public static class Interpréteur
{
    public static uint Add(string chaîne)
    {
        try
        {
            var partsAsString = chaîne.Split(',');
            var partsAsUint = partsAsString.Select(uint.Parse);
            return partsAsUint.Sum();
        } 
        catch(OverflowException e)
        {
            throw new NombreNégatifException(e);
        }
        
    }
}