namespace StringCalculator;

public static class UIntEnumerableExtensions
{
    public static uint Sum(this IEnumerable<uint> elements)
    {
        return elements.Aggregate(0U, (sum, element) => sum + element);
    }
}