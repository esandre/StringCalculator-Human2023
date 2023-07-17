using System.Text;
using StringCalculator.Test.Utilities;

namespace StringCalculator.Test
{
    public class InterpréteurTest
    {
        private const int MaximumElementsRéaliste = 10;
        private static readonly uint[] NombresEntiersNonSignésRemarquables = {0U, 1U, uint.MaxValue};
        private static readonly int[] NombresElementsRemarquables = {2, 3, MaximumElementsRéaliste };

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
    }
}