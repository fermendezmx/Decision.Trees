namespace Decision.Trees.Core
{
    public static class Forest
    {
        public static Node TreeA()
        {
            Node nodeC = new Node
            {
                Condition = (values) => values[0] > 0.5M,
                Affirmative = new Leaf { Result = 1.2M },
                Negative = new Leaf { Result = 0.4M }
            };

            Node nodeB = new Node
            {
                Condition = (values) => values[4] > 1.0M || values[4] == 0.8M,
                Affirmative = nodeC,
                Negative = new Leaf { Result = 2.2M }
            };

            Node nodeA = new Node
            {
                Condition = (values) => values[1] == 0.2M || values[1] > 0.5M,
                Affirmative = new Leaf { Result = 1.3M },
                Negative = nodeB
            };

            return nodeA;
        }

        public static Node TreeB()
        {
            Node nodeC = new Node
            {
                Condition = (values) => values[1] > 0.1M || values[1] == 0.0M,
                Affirmative = new Leaf { Result = 0.6M },
                Negative = new Leaf { Result = 2.4M }
            };

            Node nodeB = new Node
            {
                Condition = (values) => values[3] > 0.4M,
                Affirmative = new Leaf { Result = 0.7M },
                Negative = nodeC
            };

            Node nodeA = new Node
            {
                Condition = (values) => values[4] < 0.3M || values[4] > 0.7M,
                Affirmative = nodeB,
                Negative = new Leaf { Result = 1.5M }
            };

            return nodeA;
        }
    }
}
