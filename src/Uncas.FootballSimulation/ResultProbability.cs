namespace Uncas.FootballSimulation
{
    public class ResultProbability
    {
        public MatchResult Result { get; set; }
        public double Probability { get; set; }
        public int Count { get; set; }

        public override string ToString()
        {
            return string.Format(
                "{0} ({1})",
                Result,
                Count);
        }
    }
}