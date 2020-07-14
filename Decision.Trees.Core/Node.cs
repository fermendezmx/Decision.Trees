using System;

namespace Decision.Trees.Core
{
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
}
