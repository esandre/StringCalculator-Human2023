using StringCalculator.Test.Utilities;

namespace StringCalculator.Test;

public class InterpréteurTest
{
    private const int MaximumElementsRéaliste = 10;
    private static readonly uint[] NombresEntiersNonSignésRemarquables = {0U, 1U, uint.MaxValue};

    private static IEnumerable<object[]> CasAdd(int n)
        // ReSharper disable once CoVariantArrayConversion
        => new CartesianAddition(Enumerable
            .Range(1, n)
            .Select(_ => NombresEntiersNonSignésRemarquables.WithRandomCase())
            .ToArray());

    public static IEnumerable<object[]> CasAddTwo => CasAdd(2);
    public static IEnumerable<object[]> CasAddThree => CasAdd(3);

    public static IEnumerable<object[]> CasAddMax =>
        new []
        {
            Enumerable
                .Range(0, MaximumElementsRéaliste)
                .Select(_ => Random.Shared.NextUint())
                .Cast<object>() // HACK : Magie, ne pas faire attention.
                .ToArray()
        };

    [Theory]
    [MemberData(nameof(CasAddTwo))]
    [MemberData(nameof(CasAddThree))]
    [MemberData(nameof(CasAddMax))]
    public void TestAddN(params uint[] elements)
    {
        // ETANT DONNE une chaîne a,b,c...
        var chaîne = string.Join(',', elements);
        var résultatAttendu = elements.Sum();

        // QUAND on l'interprète avec la méthode Add
        var résultatObtenu = Interpréteur.Add(chaîne);

        // ALORS la somme des élements est renvoyée
        Assert.Equal(résultatAttendu, résultatObtenu);
    }

    [Fact]
    public void ExceptionSiNégatifTest()
    {
        // ETANT DONNE une chaîne représentant un nombre négatif
        const string nombreNégatif = "-1";
        const string chaîne = "0," + nombreNégatif;
        const int positionNombreNégatif = 2;

        // QUAND on l'interprète avec la méthode Add
        static void Act() => Interpréteur.Add(chaîne);

        // ALORS une exception NombreNégatifException indiquant le nombre fautif
        // et sa position est lancée
        var catchedException = Assert.Throws<AggregateException>(Act).InnerException!;
        Assert.Equal(NombreNégatifException.MakeMessage("-1", positionNombreNégatif), catchedException.Message);
    }

    [Fact]
    public void ExceptionSiPlusieursNégatifsTest()
    {
        // ETANT DONNE une chaîne représentant deux nombres négatifs
        var nombresNégatifs = new[] { -1, -2 };
        var chaîne = string.Join(',', nombresNégatifs);

        // QUAND on l'interprète avec la méthode Add
        void Act() => Interpréteur.Add(chaîne);

        // ALORS une exception AggregateException est lancée avec 2 InnerException
        // indiquant les nombres fautifs et leur position
        var catchedException = Assert.Throws<AggregateException>(Act);
        var inners = catchedException
            .InnerExceptions
            .OfType<NombreNégatifException>()
            .OrderBy(inner => inner.Message)
            .ToArray();

        Assert.Equal(2, inners.Length);
        Assert.Equal(NombreNégatifException.MakeMessage("-1", 1), inners[0].Message);
        Assert.Equal(NombreNégatifException.MakeMessage("-2", 2), inners[1].Message);
    }
}