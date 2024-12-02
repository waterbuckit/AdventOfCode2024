var lines = File.ReadAllLines("input.txt");

var parsed = lines
    .Select(x => x.Split(' ').Select(int.Parse).ToList()).ToList();

var count = parsed.Count(IsSafe) + parsed.Count(x => !IsSafe(x) && SafeInAtLeastOneWay(x));

Console.WriteLine(count);

bool SafeInAtLeastOneWay(List<int> levels)
{
    return levels.Where((_, i) => IsSafe(levels.Where((_, j) => j != i).ToList())).Any();
}

bool IsSafe(List<int> levels)
{
    for (var i = 1; i < levels.Count; i++)
    {
        // range check
        if (Math.Abs(levels[i - 1] - levels[i]) is < 1 or > 3) return false;
    }

    // check it's equal if ordering 
    return levels.SequenceEqual(levels.OrderBy((x) => x)) || levels.SequenceEqual(levels.OrderByDescending((x) => x));
}
