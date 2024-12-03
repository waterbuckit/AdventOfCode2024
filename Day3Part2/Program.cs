using System.Text.RegularExpressions;

var input = File.ReadAllText("input.txt");

var matches = MulDoDontRegex().Matches(input);
var sum = 0;
var enabled = true;
        
foreach (Match match in matches)
{
    if (match.Groups[0].Value.StartsWith("mul("))
        sum += enabled ? int.Parse(match.Groups[2].Value) * int.Parse(match.Groups[3].Value) : 0;
    else
        enabled = match.Groups[0].Value switch
        {
            "do()" => true,
            "don't()" => false,
            _ => enabled
        };
}
        
Console.WriteLine(sum);

internal abstract partial class Program
{
    [GeneratedRegex(@"(mul\((-?\d+),(-?\d+)\)|do\(\)|don't\(\))")]
    private static partial Regex MulDoDontRegex();
}