namespace Decision.Trees.Core
{
    public class Leaf : Decision
    {
        public decimal Result { get; set; }

        public override decimal Decide(decimal[] input)
        {
            return Result;
        }
    }
}
