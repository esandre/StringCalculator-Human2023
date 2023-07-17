namespace StringCalculator.Test.Utilities;

internal static class RandomTestingExtensions
{
    public static IEnumerable<uint> WithRandomCase(this IEnumerable<uint> original)
    {
        var random = new Random();
        var uintBytes = new byte[4];
        random.NextBytes(uintBytes);

        var randomUint = BitConverter.ToUInt32(uintBytes);

        return original.Append(randomUint);
    }
}