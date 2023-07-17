namespace StringCalculator.Test.Utilities;

internal static class RandomTestingExtensions
{
    public static IEnumerable<uint> WithRandomCase(this IEnumerable<uint> original)
    {
        var random = new Random();
        return original.Append(random.NextUint());
    }

    public static uint NextUint(this Random random)
    {
        var uintBytes = new byte[4];
        random.NextBytes(uintBytes);

        return BitConverter.ToUInt32(uintBytes);
    }
}