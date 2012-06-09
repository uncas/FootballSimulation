using System.Collections.Generic;
using System.Linq;

namespace Uncas.FootballSimulation
{
    public class EvaluationResult
    {
        private IList<ResultProbability> _results = new List<ResultProbability>();

        public double GetWinnerProbability(Winner winner)
        {
            if (_results.Count == 0 && winner == Winner.Draw)
            {
                return 1d;
            }

            IEnumerable<ResultProbability> matchingResults = GetResults(winner);
            return matchingResults.Sum(r => r.Probability);
        }

        private IEnumerable<ResultProbability> GetResults(Winner winner)
        {
            return _results.Where(r => r.Result.Winner == winner);
        }
    }
}