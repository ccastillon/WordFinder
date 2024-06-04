namespace WordFinderApp.Models
{
    public class Trie
    {
        private readonly TrieNode _root;

        public Trie()
        {
            _root = new TrieNode();
        }

        public void Insert(string word)
        {
            var node = _root;
            foreach (var ch in word)
            {
                if (!node.Children.ContainsKey(ch))
                {
                    node.Children[ch] = new TrieNode();
                }
                node = node.Children[ch];
            }
            node.IsEndOfWord = true;
        }

        public bool Search(string word)
        {
            var node = _root;
            foreach (var ch in word)
            {
                if (!node.Children.ContainsKey(ch))
                {
                    return false;
                }
                node = node.Children[ch];
            }
            return node.IsEndOfWord;
        }
    }
}
