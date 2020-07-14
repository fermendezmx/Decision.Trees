# Decision trees
The purpose of this solution is to get the sum of all the decision tree results.

    Input:
      - 1000 Decimal variables: VAR_0 ... VAR_999
      - 50 Decision trees
        * Multilevel
        * Each level has a condition based on a variable
            Example:
              * VAR_56 < 0.5
              * VAR_475 > 544 and VAR_475 < 892
        * The result of a decision tree is a decimal number
            Example: 0.2319949
          
    Output:
      - SCORE = Sum of the decision tree results

Solution:

```csharp
public abstract class Decision
{
    public abstract decimal Decide(decimal[] input);
}
```
```csharp
public class Node : Decision
{
    public Decision Affirmative { get; set; }
    public Decision Negative { get; set; }
    public Func<decimal[], bool> Condition { get; set; }

    public override decimal Decide(decimal[] input)
    {
        return Condition(input)
            ? Affirmative.Decide(input)
            : Negative.Decide(input);
    }
}
```
```csharp
public class Leaf : Decision
{
    public decimal Result { get; set; }

    public override decimal Decide(decimal[] input)
    {
        return Result;
    }
}
```
```csharp
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
```
```csharp
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
```
```csharp
class Program
{
    static void Main(string[] args)
    {
        decimal result = 0;
        Node rootA = Forest.TreeA();
        Node rootB = Forest.TreeB();
        List<Tree> trees = new List<Tree>();

        // 1000 decimal variables, VAR_0 ... VAR_999
        decimal[] inputA = { 1.1M, 0.5M, 2.0M, 0.3M, 0.2M };
        decimal[] inputB = { 0.4M, 0.2M, 3.5M, 1.0M, 0.5M };

        // 50 decision trees
        trees.Add(new Tree(rootA, inputA));
        trees.Add(new Tree(rootA, inputB));
        trees.Add(new Tree(rootB, inputA));
        trees.Add(new Tree(rootB, inputB));

        foreach (Tree tree in trees)
        {
            // The result of a decision tree is a decimal number
            result += tree.Root.Decide(tree.Values);
        }

        // Sum of the decision tree results
        Console.WriteLine(result);
        Console.ReadKey();
    }
}
```
