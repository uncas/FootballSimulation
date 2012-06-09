namespace Uncas.FootballSimulation
{
    public class MatchResult
    {
        public int Goals1 { get; set; }
        public int Goals2 { get; set; }

        public Winner Winner
        {
            get
            {
                if (Goals1 == Goals2)
                    return Winner.Draw;
                return Goals1 > Goals2 ? Winner.FirstTeam : Winner.SecondTeam;
            }
        }

        public override string ToString()
        {
            return string.Format(
                "{0}-{1}",
                Goals1,
                Goals2);
        }
    }
}