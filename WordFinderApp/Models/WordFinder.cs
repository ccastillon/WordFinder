namespace WordFinderApp.Models
{
    public class WordFinder
    {
        private readonly HashSet<string> _dictionary;

        public WordFinder(IEnumerable<string> dictionary)
        {
            _dictionary = new HashSet<string>(dictionary);
        }

        public IList<string> Find(IEnumerable<string> src)
        {
            var foundWords = new HashSet<string>();
            var matrix = src.ToArray();
            int rows = matrix.Length;
            int cols = matrix[0].Length;

            // Search horizontally
            foreach (var word in _dictionary)
            {
                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i].Contains(word))
                    {
                        foundWords.Add(word);
                    }
                }
            }

            // Search vertically
            for (int col = 0; col < cols; col++)
            {
                string colString = string.Empty;
                for (int row = 0; row < rows; row++)
                {
                    colString += matrix[row][col];
                }

                foreach (var word in _dictionary)
                {
                    if (colString.Contains(word))
                    {
                        foundWords.Add(word);
                    }
                }
            }

            return foundWords.ToList();
        }
    }
}

