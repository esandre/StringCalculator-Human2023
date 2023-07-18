using System.Text;
using StringCalculator;

Console.Write('>');

var lines = new StringBuilder();

var canWork = false;
while(!canWork)
{
    var line = Console.ReadLine() ?? string.Empty;
    canWork = !line.StartsWith("//");

    lines.AppendLine(line);
}

Console.WriteLine(Interpréteur.Add(lines.ToString()));