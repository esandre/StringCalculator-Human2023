namespace StringCalculator;

public class NombreNégatifException : Exception
{
    internal NombreNégatifException(OverflowException inner)
        : base("Nombre négatif !" ,inner)
    {
    }
}