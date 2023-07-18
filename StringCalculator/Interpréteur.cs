namespace StringCalculator;

public static class Interpréteur
{
    private const char DélimiteurParDéfaut = ',';
    private const string PréfixeDélimiteur = "//";

    public static uint Add(string chaîne)
    {
        var délimiteur = DélimiteurParDéfaut;

        if(chaîne.StartsWith(PréfixeDélimiteur))
        {
            var lignes = chaîne.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var ligneDélimiteur = lignes[0];
            délimiteur = ligneDélimiteur
                .Replace(PréfixeDélimiteur, string.Empty)
                .Single();

            chaîne = lignes.Last();
        }

        var partsAsString = chaîne
            .Replace(" ", string.Empty)
            .Split(délimiteur);

        var index = 0U;
        var partsAsUint = partsAsString
            .ToDictionary(_ => ++index, str => str)
            .AsParallel()
            .Select(dict => ParseOrThrow(dict.Key, dict.Value))
            .Where(nombre => nombre <= 1000);

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