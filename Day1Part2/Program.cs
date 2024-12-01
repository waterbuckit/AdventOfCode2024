// read file
var fileString = File.ReadAllText("input.txt");
var lines = fileString.Split('\n');

var (list1, list2) = lines.Aggregate((new List<int>(), new List<int>()), (tuple, s) =>
{
    var split = s.Split("   ");
    
    tuple.Item1.Add(int.Parse(split[0]));
    tuple.Item2.Add(int.Parse(split[1]));
    
    return tuple;
});

var sum = list1.Select(x => x * list2.Aggregate(0, (a, b) => x == b ? a + 1 : a)).Sum();

Console.WriteLine(sum);