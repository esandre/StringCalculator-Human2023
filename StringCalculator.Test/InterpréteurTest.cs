using StringCalculator.Test.Utilities;

namespace StringCalculator.Test
{
    public class InterpréteurTest
    {
        private static readonly uint[] NombresEntiersNonSignésRemarquables = {0U, 1U, uint.MaxValue};

        public static IEnumerable<object[]> CasAdd 
            => new CartesianAddition(
                NombresEntiersNonSignésRemarquables.WithRandomCase(), 
                NombresEntiersNonSignésRemarquables.WithRandomCase());

        [Theory]
        [MemberData(nameof(CasAdd))]
        public void TestAdd(uint a, uint b)
        {
            // ETANT DONNE une chaîne a,b
            var chaîne = $"{a},{b}";

            // QUAND on l'interprète avec la méthode Add
            var résultat = Interpréteur.Add(chaîne);

            // ALORS a+b est renvoyé
            Assert.Equal(a + b, résultat);
        }
    }
}