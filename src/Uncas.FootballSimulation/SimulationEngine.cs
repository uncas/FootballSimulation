using System;

namespace Uncas.FootballSimulation
{
    public class SimulationEngine
    {
        public MatchResult SimulateMatch(FootballMatch match)
        {
            var field = new Field();
            var random = new Random();
            const int interval = 10;
            Console.WriteLine("The game starts...");
            var result = new MatchResult();
            for (int seconds = 0; seconds < 90 * 60; seconds += interval)
            {
                int widthDelta = random.Next(3) - 1;
                int lengthDelta = random.Next(3) - 1;
                field.MoveBall(widthDelta, lengthDelta);
                if (field.BallIsAtGoal1())
                {
                    result.Goals1++;
                    field.ResetBallPosition();
                }
                if (field.BallIsAtGoal2())
                {
                    result.Goals2++;
                    field.ResetBallPosition();
                }
            }

            Console.WriteLine(result);
            return result;
        }
    }
}