namespace AdventOfCode
{
    public class Day7
    {
        public Day7(string input) => this.Input = input;

        public string Input { get; }
        public long Part1 => Directories.Values.Where(d => d.Size <= 100000 ).Sum(d => d.Size);
        public long Part2 { get; set; } = 0;
        public Dictionary<string, Directory> Directories { get; set; } = new();

        public void ProcessPart1()
        {
            var sum = 0L;
            var baseDirectory = new Directory("/", null!);
            var currentDirectory = baseDirectory;
            Directories.Add("/", currentDirectory);
            foreach (var line in Input.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
            {

                if (line.StartsWith("$"))
                {
                    if (line.Equals("$ cd .."))
                    {
                        currentDirectory = currentDirectory.ParentDirectory ?? baseDirectory;
                    }
                    else if (line.Equals("$ cd /"))
                    {
                        currentDirectory = baseDirectory;
                    }
                    else if (line.StartsWith("$ cd"))
                    {
                        var directoryName = line.Split(" ")[2];
                        currentDirectory = Directories[currentDirectory.Name + "/" + directoryName];
                    }
                }
                else if (line.StartsWith("dir"))
                {
                    var directoryName = line.Split(" ")[1];
                    Directories.TryAdd(currentDirectory.Name+"/"+directoryName, new Directory(currentDirectory.Name + "/" + directoryName, currentDirectory!));
                }
                else
                {
                    var fileSize = long.Parse(line.Split(" ")[0]);
                    currentDirectory.IncreaseSize(fileSize);
                    sum += fileSize;
                }
                
            }
            Console.WriteLine("D7P1: " + sum);
        }


        public void ProcessPart2()
        {
            var required = 30000000;
            var currentFree = (70000000 - Directories["/"].Size);
            var deleteAmount = required - currentFree;
            var d = Directories.Values.OrderBy(d => d.Size).First(d => d.Size >= deleteAmount);
            Part2 = d.Size;
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

    internal void IncreaseSize(long size)
    {
        this.Size += size;
        if (ParentDirectory != null)
            ParentDirectory.IncreaseSize(size);
    }
}