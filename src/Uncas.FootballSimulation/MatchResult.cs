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

        public static bool operator ==(MatchResult first, MatchResult second)
        {
            return first.Goals1 == second.Goals1 &&
                first.Goals2 == second.Goals2;
        }

        public static bool operator !=(MatchResult first, MatchResult second)
        {
            return !(first == second);
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