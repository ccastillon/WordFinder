namespace WordFinderApp.Models
{
    public class WordFinderTrie
    {
        private readonly Trie _trie;

        public WordFinderTrie(IEnumerable<string> dictionary)
        {
            _trie = new Trie();
            foreach (var word in dictionary)
            {
                _trie.Insert(word);
            }
        }

        public IList<string> Find(IEnumerable<string> src)
        {
            var foundWords = new HashSet<string>();
            var matrix = src.ToArray();
            int rows = matrix.Length;
            int cols = matrix[0].Length;

            // Search horizontally
            foreach (var row in matrix)
            {
                for (int start = 0; start < row.Length; start++)
                {
                    for (int length = 1; length <= row.Length - start; length++)
                    {
                        var word = row.Substring(start, length);
                        if (_trie.Search(word))
                        {
                            foundWords.Add(word);
                        }
                    }
                }
            }

            // Search vertically
            for (int col = 0; col < cols; col++)
            {
                for (int start = 0; start < rows; start++)
                {
                    for (int length = 1; length <= rows - start; length++)
                    {
                        var word = string.Concat(Enumerable.Range(start, length).Select(r => matrix[r][col]));
                        if (_trie.Search(word))
                        {
                            foundWords.Add(word);
                        }
                    }
                }
            }

            return foundWords.ToList();
        }
    }
}
