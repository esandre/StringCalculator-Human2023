namespace StringCalculator;

public class NombreNégatifException : Exception
{
    internal NombreNégatifException(string nombre, OverflowException inner)
        : base($"Nombre négatif : {nombre} !" ,inner)
    {
    }
}