using Decision.Trees.Core;

namespace Decision.Trees.Play
{
    public class Tree
    {
        public Tree(Node root, decimal[] values)
        {
            Root = root;
            Values = values;
        }

        public Node Root { get; set; }
        public decimal[] Values { get; set; }
    }
}
