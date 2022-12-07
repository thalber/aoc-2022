// See https://aka.ms/new-console-template for more information
if (args.Length == 0) return 1;

SortedSet<int> ord = new();


int ckal = 0;
foreach (string line in File.ReadAllLines(args[0]))
{
    if (int.TryParse(line, out var val))
    {
        ckal += val;
    }
    else
    {
        ord.Add(ckal);
        ckal = 0;
    }
}
Console.WriteLine(ord.Reverse().Select(x => x.ToString()).Aggregate((x, y) => $"{x}, {y}"));

Console.WriteLine(ord.Reverse().Take(3).Sum());
Console.ReadKey();
return 0;