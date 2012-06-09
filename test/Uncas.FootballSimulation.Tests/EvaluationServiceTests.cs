using NUnit.Framework;

namespace Uncas.FootballSimulation.Tests
{
    public class EvaluationService
    {
        public EvaluationResult EvaluateMatch()
        {
            return new EvaluationResult();
        }
    }

    [TestFixture]
    public class EvaluationServiceTests
    {
        private EvaluationService _evaluationService = new EvaluationService();

        [Test]
        public void EvaluateMatch()
        {
            EvaluationResult evaluationResult = _evaluationService.EvaluateMatch();

            Assert.NotNull(evaluationResult);
        }
    }
}
