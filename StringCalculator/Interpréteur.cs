namespace StringCalculator;

public static class Interpréteur
{
    public static uint Add(string chaîne)
    {
        var partsAsString = chaîne
            .Replace(" ", string.Empty)
            .Split(',');

        var index = 0U;
        var partsAsUint = partsAsString
            .ToDictionary(_ => ++index, str => str)
            .AsParallel()
            .Select(dict => ParseOrThrow(dict.Key, dict.Value));

        return partsAsUint.Sum();
    }

    private static uint ParseOrThrow(uint index, string nombre)
    {
        try
        {
            return uint.Parse(nombre);
        }
        catch (OverflowException e)
        {
            throw new NombreNégatifException(nombre, index, e);
        }
    }
}