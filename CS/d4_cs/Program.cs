using static System.Math;

string[] lines = File.ReadAllLines(args[0]);
bool t2 = prompt.ask("task 2?");
int count = 0;
int[] elms = new int[4];

foreach (string line in lines)
{
	var spl = line.Split('-', ',');
	for (int i = 0; i < 4; i++)
	{
		int.TryParse(spl[i], out elms[i]);
	}

	if (t2)
	{
		//p0-p1,p2-p3
		int comp1 = Max(elms[0], elms[2]),
			comp2 = Min(elms[1], elms[3]);
		if (comp1 <= comp2) { count++; }
	}
	else
	{
		int comp1 = elms[0] - elms[2],
			comp2 = elms[1] - elms[3];
		if (comp1 >= 0 && comp2 <= 0 || comp1 <= 0 && comp2 >= 0)
		{
			count++;
		}
	}

}
Console.WriteLine(count);
Console.ReadKey();
