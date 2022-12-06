using System;

public static class prompt
{
	public static bool ask(string prompt)
	{
		Console.Write($"\n{prompt} > ");
		return Console.ReadLine() is "1" or "y" or "yes";
	}
}
