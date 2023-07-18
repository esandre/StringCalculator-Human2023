namespace StringCalculator;

public class NombreNégatifException : Exception
{
    public static string MakeMessage(string nombreFautif, uint position)
        => $"Nombre négatif {nombreFautif} détecté à la position {position} !";

    internal NombreNégatifException(string nombreFautif, uint position, Exception inner)
        : base(MakeMessage(nombreFautif, position), inner)
    {
    }
}