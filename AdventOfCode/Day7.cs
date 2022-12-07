namespace AdventOfCode
{
    public class Day7
    {
        public Day7(string input) => this.Input = input;

        public string Input { get; }
        public int Part1 { get; } = 0;
        public int Part2 { get; } = 0;
        public Dictionary<string, Directory> Directories { get; set; } = new();

        public void ProcessPart1()
        {
            var baseDirectory = new Directory("/", null!);
            var currentDirectory = baseDirectory;
            Directories.Add("/", currentDirectory);
            foreach (var line in Input.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
            {
                if (line.StartsWith("$"))
                {
                    if (line.StartsWith("$ cd .."))
                    {
                        currentDirectory = currentDirectory.ParentDirectory;
                    }
                    else if (line.Equals("$ cd /"))
                    {
                        currentDirectory = baseDirectory;
                    }
                    else if (line.StartsWith("$ cd"))
                    {
                        var directoryName = line.Split(" ")[2];
                        Directories.TryGetValue(directoryName, out var directory);
                        currentDirectory = directory;
                    }
                }
                else if (line.StartsWith("dir"))
                {
                    var directoryName = line.Split(" ")[1];
                    Directories.Add(directoryName, new Directory(directoryName, currentDirectory!));
                }
                else
                {
                    var fileSize = line.Split(" ")[0];
                    currentDirectory.Size += long.Parse(fileSize);
                }
            }
        }

        public long SumSizeFor(string dir)
        {
            return Directories.Values.Where(d => d.ParentDirectory?.Name == dir).Sum(d => d.Size) + Directories[dir].Size;
        }

        public void ProcessPart2()
        {
        }
    }
}

public class Directory
{
    public string Name { get; set; } = string.Empty;
    public Directory(string name, Directory parentDirectory)
    {
        this.Name = name;
        this.ParentDirectory = parentDirectory;
    }

    public long Size { get; set; } = 0;

    public Directory ParentDirectory { get; set; }
}