namespace StringCalculator;

public static class Interpréteur
{
    public static uint Add(string chaîne)
    {
        var partsAsString = chaîne.Split(',');
        var partsAsUint = partsAsString.Select(uint.Parse);
        return partsAsUint.Sum();
    }
}