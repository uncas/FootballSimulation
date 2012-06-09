using System;
using System.Linq;

namespace Uncas.FootballSimulation
{
    public class EvaluationService
    {
        private SimulationEngine _simulationEngine = new SimulationEngine();

        public EvaluationResult EvaluateMatch(FootballMatch match)
        {
            var result = new EvaluationResult();
            const int numberOfSimulations = 100;
            for (int simulationIndex = 0;
                simulationIndex < numberOfSimulations;
                simulationIndex++)
            {
                MatchResult matchResult = _simulationEngine.SimulateMatch(match);
                result.AddResult(matchResult);
            }

            foreach (ResultProbability resultProbability in
                result.Results.OrderByDescending(r => r.Count))
            {
                Console.WriteLine(resultProbability);
            }

            return result;
        }
    }
}