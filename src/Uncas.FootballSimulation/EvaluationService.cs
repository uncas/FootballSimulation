namespace Uncas.FootballSimulation
{
    public class EvaluationService
    {
        private SimulationEngine _simulationEngine = new SimulationEngine();

        public EvaluationResult EvaluateMatch(FootballMatch match)
        {
            const int numberOfSimulations = 10;
            for (int simulationIndex = 0;
                simulationIndex < numberOfSimulations;
                simulationIndex++)
            {
                MatchResult result = _simulationEngine.SimulateMatch(match);
            }

            return new EvaluationResult();
        }
    }
}