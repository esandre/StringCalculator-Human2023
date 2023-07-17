namespace StringCalculator;

public static class Interpréteur
{
    public static uint Add(string chaîne)
    {
        var parts = chaîne.Split(',');
        return parts.Select(uint.Parse).Sum();
    }
}