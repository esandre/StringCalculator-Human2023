namespace StringCalculator;

public static class Interpréteur
{
    private const string DélimiteurParDéfaut = ",";
    private const string PréfixeDélimiteur = "//";

    public static uint Add(string chaîne)
    {
        var délimiteurs = new [] { DélimiteurParDéfaut };

        if(chaîne.StartsWith(PréfixeDélimiteur))
        {
            var lignes = chaîne.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var ligneDélimiteurs = lignes[0]
                .Replace(PréfixeDélimiteur, string.Empty);

            délimiteurs = ligneDélimiteurs.Split(',');

            chaîne = lignes.Last();
        }

        chaîne = chaîne
            .Replace(" ", string.Empty);

        chaîne = délimiteurs.Aggregate(chaîne,
            (current, délimiteur) => current.Replace(délimiteur, ",")
        );

        var partsAsString = chaîne.Split(',');

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