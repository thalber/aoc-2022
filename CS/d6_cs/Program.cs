const int MSZ_PACKET = 4;
const int MSZ_MESSAGE = 14;

string[] lines = File.ReadAllLines(args[0]);
bool t2 = prompt.ask("task 2?");
int buffsize = t2 ? MSZ_MESSAGE : MSZ_PACKET;


char?[] buffer = new char?[buffsize];
using var tr = File.OpenText(args[0]);

int pos = 0;

while (!tr.EndOfStream)
{
	char c = (char)tr.Read();
	if (check()) break;
	push(c);
	pos++;
}

Console.WriteLine(pos);
Console.ReadKey();

void push(char? val)
{
	for (int i = 1; i < buffsize; i++)
	{
		buffer[i - 1] = buffer[i];
	}
	buffer[buffsize - 1] = val;
}
bool check()
{
	for (int i = 0; i < buffsize; i++)
	{
		if (buffer[i] is null) { return false; }
		for (int j = i + 1; j < buffsize; j++)
		{
			if (buffer[i] == buffer[j]) { return false; }
		}
	}
	return true;
}
