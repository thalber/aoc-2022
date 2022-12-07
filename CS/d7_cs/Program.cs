string[] lines = File.ReadAllLines($"{Environment.GetEnvironmentVariable("AOCINPUT")}/d7.txt");
fs _fs = new();
bool t2 = true;//prompt.ask("task 2?");
const ulong maxspace = 70000000;
const ulong rqupdate = 30000000;


foreach (var line in lines)
{
	if (line.StartsWith("$ "))
	{
		//apply cd
		if (line[2..].StartsWith("cd "))
		{
			_fs.cd(line[5..]);
		}
	}
	else
	{
		string[] spl = line.Split(' ');
		if (spl[0] is "dir")
		{
			_fs.wd.getchild(spl[1]);
		}
		else
		{
			_fs.touch(spl[1], ulong.Parse(spl[0]));
		}
	}
}

if (t2)
{
	checked
	{
		ulong toremove = rqupdate - (maxspace - _fs.root.totalsize);
		Console.WriteLine(_fs.root.recwalk()
			.Where(x => x.totalsize >= toremove)
			.Select(x => x.totalsize)
			.Aggregate(maxspace, (x, y) => Math.Min(x, y)));
		Console.ReadKey();
	}
}
else
{
	Console.WriteLine(_fs.root.recwalk()
		.Where(x => x.totalsize <= 100000)
		.Select(x => x.totalsize)
		.Aggregate((x, y) => x + y));
		Console.ReadKey();
}


class fs
{
	public fs()
	{
		wd = root;
	}

	public dir cd(string path)
	{
		wd = path switch
		{
			".." => wd?.parent ?? wd!,
			"/" => root,
			_ => wd.getchild(path)
		};
		return wd;
	}
	public void touch(string name, ulong size)
	{
		wd.setfile(name, size);

	}
	public dir wd { get; private set; }
	public readonly dir root = new(null, "");
}

class dir
{
	public dir(dir? parent, string name)
	{
		this.parent = parent;
		this.name = name;
	}

	public Dictionary<string, ulong> files { get; private set; } = new();
	public Dictionary<string, dir> children { get; private set; } = new();
	public dir? parent { get; private set; }
	public string name { get; private set; }

	public dir getchild(string name)
	{
		if (!children.TryGetValue(name, out dir? ch))
		{
			ch = new(this, name);
			children.Add(name, ch);
		}
		return ch;
	}
	public void setfile(string name, ulong size)
	{
		files.Add(name, size);
	}
	private ulong? _ts = null;
	public ulong totalsize
	{
		get
		{
			if (_ts is not null) goto done;
			static ulong sum(ulong l, ulong r) => l + r;
			ulong
			cval = children.Count is 0 ? 0 : children.Values
				.Select(x => x.totalsize)
				.Aggregate(0ul, sum),
			fval = files.Count is 0 ? 0 : files.Values.Aggregate(sum);

			_ts = fval + cval;
		done:;
			return _ts.Value;
		}
	}
	public IEnumerable<dir> recwalk()
	{
		foreach (dir child in children.Values)
		{
			yield return child;
			foreach (dir grandchild in child.recwalk()) yield return grandchild;
		}
	}
}
