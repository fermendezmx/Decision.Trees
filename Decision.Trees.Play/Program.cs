using System;
using System.Collections.Generic;
using Decision.Trees.Core;

namespace Decision.Trees.Play
{
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
}
