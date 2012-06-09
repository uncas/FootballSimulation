using NUnit.Framework;
using System;

namespace Uncas.FootballSimulation.Tests
{
    [TestFixture]
    public class EvaluationServiceTests
    {
        private EvaluationService _evaluationService = new EvaluationService();

        [Test]
        public void EvaluateMatch_EvenMatch_EvenProbabilities()
        {
            var match = new FootballMatch();
            EvaluationResult evaluationResult =
                _evaluationService.EvaluateMatch(match);

            Assert.NotNull(evaluationResult);
            double firstTeamWins =
                evaluationResult.GetWinnerProbability(Winner.FirstTeam);
            double secondTeamWins =
                evaluationResult.GetWinnerProbability(Winner.SecondTeam);
            double draw =
                evaluationResult.GetWinnerProbability(Winner.Draw);

            Assert.Less(Math.Abs(firstTeamWins - secondTeamWins), 0.1d);
            Assert.Less(
                Math.Abs(firstTeamWins + secondTeamWins + draw - 1d),
                0.000001d);
        }
    }
}