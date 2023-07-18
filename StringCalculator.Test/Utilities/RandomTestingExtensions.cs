namespace StringCalculator.Test.Utilities;

internal static class RandomTestingExtensions
{
    public static IEnumerable<uint> WithRandomCase(this IEnumerable<uint> original, uint max = uint.MaxValue)
    {
        var random = new Random();
        return original.Append(random.NextUint(max));
    }

    public static uint NextUint(this Random random, uint max = uint.MaxValue)
    {
        var randomFloat = random.NextSingle();
        return (uint) Math.Round(max * randomFloat);
    }
}