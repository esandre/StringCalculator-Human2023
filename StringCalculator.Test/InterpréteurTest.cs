using StringCalculator.Test.Utilities;

namespace StringCalculator.Test
{
    public class InterpréteurTest
    {
        private static readonly uint[] NombresEntiersNonSignésRemarquables = {0U, 1U, uint.MaxValue};

        public static IEnumerable<object[]> CasAddTwo 
            => new CartesianAddition(
                NombresEntiersNonSignésRemarquables.WithRandomCase(), 
                NombresEntiersNonSignésRemarquables.WithRandomCase());

        public static IEnumerable<object[]> CasAddThree
            => new CartesianAddition(
                NombresEntiersNonSignésRemarquables.WithRandomCase(),
                NombresEntiersNonSignésRemarquables.WithRandomCase(),
                NombresEntiersNonSignésRemarquables.WithRandomCase());

        [Theory]
        [MemberData(nameof(CasAddTwo))]
        [MemberData(nameof(CasAddThree))]
        public void TestAddN(params uint[] elements)
        {
            // ETANT DONNE une chaîne a,b,c...
            var chaîne = string.Join(',', elements);

            // QUAND on l'interprète avec la méthode Add
            var résultat = Interpréteur.Add(chaîne);

            // ALORS la somme des élements est renvoyé
            Assert.Equal(elements.Sum(), résultat);
        }
    }
}