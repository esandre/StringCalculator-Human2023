namespace StringCalculator;

public class NombreNégatifException : Exception
{
    internal NombreNégatifException(string nombreFautif, uint position, Exception inner)
        : base($"Nombre négatif {nombreFautif} à la position {position} !", inner)
    {
    }
}