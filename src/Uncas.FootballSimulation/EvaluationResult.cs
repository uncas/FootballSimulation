using System.Collections.Generic;
using System.Linq;

namespace Uncas.FootballSimulation
{
    public class EvaluationResult
    {
        private IList<ResultProbability> _results = new List<ResultProbability>();

        public IEnumerable<ResultProbability> Results
        {
            get
            {
                return _results;
            }
        }

        public double GetWinnerProbability(Winner winner)
        {
            if (_results.Count == 0 && winner == Winner.Draw)
            {
                return 1d;
            }

            IEnumerable<ResultProbability> matchingResults = GetResults(winner);
            return matchingResults.Sum(r => r.Probability);
        }

        public void AddResult(MatchResult matchResult)
        {
            var entry = _results.SingleOrDefault(r => r.Result == matchResult);
            if (entry == null)
            {
                entry = new ResultProbability { Result = matchResult };
                _results.Add(entry);
            }

            entry.Count++;

            int totalCount = _results.Sum(r => r.Count);
            foreach (var item in _results)
            {
                item.Probability = (item.Count * 1d) / (1d * totalCount);
            }
        }

        private IEnumerable<ResultProbability> GetResults(Winner winner)
        {
            return _results.Where(r => r.Result.Winner == winner);
        }
    }
}