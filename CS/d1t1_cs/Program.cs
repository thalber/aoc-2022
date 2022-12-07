// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
if (args.Length == 0) return 1;

int maxcal = 0, ckal = 0;

foreach (var line in File.ReadAllLines(args[0]))
{
	if (int.TryParse(line, out var value))
	{
		ckal += value;
	}
	else
	{
		maxcal = Math.Max(maxcal, ckal);
		ckal = 0;
	}
}
Console.WriteLine(maxcal);
Console.ReadKey();
return 0;
