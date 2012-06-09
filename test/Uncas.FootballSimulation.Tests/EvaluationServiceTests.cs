using NUnit.Framework;

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

            Assert.AreEqual(firstTeamWins, secondTeamWins);
            Assert.AreEqual(1d, firstTeamWins + secondTeamWins + draw);
        }
    }
}