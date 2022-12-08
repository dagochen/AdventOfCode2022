namespace AdventOfCode
{
    public class Day8
    {
        public Day8(string input) => this.Input = input;

        public string Input { get; }
        public long Part1 { get; set; } = 0;
        public long Part2 { get; set; } = 0;
        public int[,] Forest { get; set; }

        private int SizeOfForest = 0;

        public void Read()
        {
            int index = 0;
            foreach (var line in Input.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
            {
                SizeOfForest = line.Length;
                if (Forest == null)
                    Forest = new int[SizeOfForest, SizeOfForest];

                for(int i = 0; i < line.Length; i++)
                {
                    Forest[index, i] = int.Parse(line.Substring(i,1));
                }
                index++;
            }
        }

        public void Calculate()
        {
            for (int row = 1; row < SizeOfForest - 1; row++)
            {
                for (int col = 1; col < SizeOfForest - 1; col++)
                    {
                     if (IsVisibleFromLeft(row, col) 
                            || IsVisibleFromRight(row, col) 
                            || IsVisibleFromTop(row, col) 
                            || IsVisibleFromBottom(row,col))
                        this.Part1++;

                    var left = DistanceToLeft(row, col);
                    var right = DistanceToRight(row, col);
                    var top = DistanceToTop(row, col);
                    var bottom = DistanceToBottom(row, col);
                    var score = left * right * top * bottom;
                    this.Part2 = Math.Max(score, this.Part2);
                }
            }
            this.Part1 += (2 * SizeOfForest) + (2 * (SizeOfForest - 2));
        }

        private bool IsVisibleFromLeft(int row, int col)
        {
            var tree = Forest[row, col];

            for (int c = col-1; c >= 0; c--) 
            {
                if (Forest[row,c] >= tree)
                    return false;
            }
            return true;
        }

        private bool IsVisibleFromRight(int row, int col)
        {
            var tree = Forest[row, col];

            for (int c = col+1; c < SizeOfForest; c++)
            {
                if (Forest[row, c] >= tree)
                    return false;
            }
            return true;
        }

        private bool IsVisibleFromTop(int row, int col)
        {
            var tree = Forest[row, col];

            for (int r = row-1; r >= 0; r--)
            {
                if (Forest[r, col] >= tree)
                    return false;
            }
            return true;
        }

        private bool IsVisibleFromBottom(int row, int col)
        {
            var tree = Forest[row, col];

            for (int r = row+1; r < SizeOfForest; r++)
            {
                if (Forest[r,col] >= tree)
                    return false;
            }
            return true;
        }

        private int DistanceToLeft(int row, int col)
        {
            var tree = Forest[row, col];

            var distance = 0;
            for (int c = col-1; c >= 0; c--)
            {
                distance++;
                if (Forest[row, c] >= tree)
                    return distance;
            }
            return distance;
        }

        private int DistanceToRight(int row, int col)
        {
            var tree = Forest[row, col];

            var distance = 0;
            for (int c = col + 1; c < SizeOfForest; c++)
            {
                distance++;
                if (Forest[row, c] >= tree)
                    return distance;
            }
            return distance;
        }

        private int DistanceToTop(int row, int col)
        {
            var tree = Forest[row, col];

            var distance = 0;
            for (int r = row - 1; r >= 0; r--)
            {
                distance++;
                if (Forest[r, col] >= tree)
                    return distance;
            }
            return distance;
        }

        private int DistanceToBottom(int row, int col)
        {
            var tree = Forest[row, col];

            var distance = 0;
            for (int r = row + 1; r < SizeOfForest; r++)
            {
                distance++;
                if (Forest[r, col] >= tree)
                    return distance;
            }
            return distance;
        }
    }
}
