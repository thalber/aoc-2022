// See https://aka.ms/new-console-template for more information
string[] lines = File.ReadAllLines(args[0]);
int score = 0;
for (int i = 0; i < lines.Length; i++)
{
	string[] spl = lines[i].Split(new char[] { ' ' });
	RPS
		opps = spl[0] switch
		{
			"A" => RPS.rock,
			"B" => RPS.paper,
			"C" => RPS.scissors,
			_ => throw new ArgumentException(),
		},
		your = spl[1] switch
		{
			"X" => RPS.rock,
			"Y" => RPS.paper,
			"Z" => RPS.scissors,
			_ => throw new ArgumentException(),
		};
	score += your switch
	{
		RPS.rock => 1,
		RPS.paper => 2,
		RPS.scissors => 3,
		_ => throw new InvalidOperationException(),
	};
	score += battle(your, opps) switch
	{
		RES.win => 6,
		RES.draw => 3,
		RES.loss => 0,
		_ => throw new InvalidOperationException(),
	};
}
Console.WriteLine(score);
Console.ReadKey();
RES battle(RPS you, RPS other)
{
	RES res = ((int)you - (int)other) switch
	{
		0 => RES.draw,
		1 or -2 => RES.win,
		-1 or 2 => RES.loss,
		_ => throw new InvalidOperationException(),
	};
	return res;
}
enum RPS
{
	rock = 0,
	paper = 1,
	scissors = 2
}
enum RES
{
	win,
	draw,
	loss
}
