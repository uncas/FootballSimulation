using NUnit.Framework;

namespace Uncas.FootballSimulation.Tests
{
    [TestFixture]
    public class EvaluationResultTests
    {
        [Test]
        public void GetWinnerProbability_AnyResult_AlwaysAddsToOne()
        {
            EvaluationResult evaluationResult = new EvaluationResult();

            double first = evaluationResult.GetWinnerProbability(Winner.FirstTeam);
            double second = evaluationResult.GetWinnerProbability(Winner.SecondTeam);
            double draw = evaluationResult.GetWinnerProbability(Winner.Draw);

            Assert.AreEqual(1d, first + second + draw);
        }

        [Test]
        public void GetWinnerProbability_DummyResult_EvenOdds()
        {
            EvaluationResult evaluationResult = new EvaluationResult();

            double first = evaluationResult.GetWinnerProbability(Winner.FirstTeam);
            double second = evaluationResult.GetWinnerProbability(Winner.SecondTeam);

            Assert.AreEqual(first, second);
        }
    }
}