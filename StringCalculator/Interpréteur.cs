namespace StringCalculator;

public static class Interpréteur
{
    public static uint Add(string chaîne)
    {
        var parts = chaîne.Split(',');
        var a = uint.Parse(parts.First());
        var b = uint.Parse(parts.Last());
        return a + b;
    }
}