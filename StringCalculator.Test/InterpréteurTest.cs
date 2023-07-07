namespace StringCalculator.Test
{
    public class UnitTest1
    {
        /*
         * Créez une méthode int Add(string numbers) prenant un string de forme
         * « x,y » et renvoyant l’entier x+y.
         */

        [Fact]
        public void TestAdd0Et0()
        {
            // ETANT DONNE une chaîne 0,0
            const string chaîne = "0,0";

            // QUAND on l'interprète avec la méthode Add
            var résultat = Interpréteur.Add(chaîne);

            // ALORS 0 est renvoyé
            Assert.Equal(0U, résultat);
        }
    }
}