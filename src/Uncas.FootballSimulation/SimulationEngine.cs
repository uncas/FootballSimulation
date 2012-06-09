using System;

namespace Uncas.FootballSimulation
{
    public class SimulationEngine
    {
        private static readonly Random Random = new Random();

        public MatchResult SimulateMatch(FootballMatch match)
        {
            var field = new Field();
            const int interval = 10;
            var result = new MatchResult();
            bool team1HasBall = true;
            for (int seconds = 0; seconds < 90 * 60; seconds += interval)
            {
                bool otherTeamWinsBall = Random.Next(4) == 0;
                if (otherTeamWinsBall)
                    team1HasBall = !team1HasBall;
                int widthDelta = GetWidthDelta(field);
                int lengthDelta = GetLengthDelta(field, team1HasBall);
                field.MoveBall(widthDelta, lengthDelta);
                if (field.BallIsAtGoal1())
                {
                    result.Goals2++;
                    field.ResetBallPosition();
                    team1HasBall = true;
                }
                if (field.BallIsAtGoal2())
                {
                    result.Goals1++;
                    field.ResetBallPosition();
                    team1HasBall = false;
                }
            }

            return result;
        }

        private int GetLengthDelta(Field field, bool team1HasBall)
        {
            int luckyNumber = Random.Next(100);
            int result = luckyNumber < 60 ? 1 : (luckyNumber < 80 ? -1 : 0);
            return team1HasBall ? result : -result;
        }

        private int GetWidthDelta(Field field)
        {
            int luckyNumber = Random.Next(100);
            int widthPosition = field.BallPosition.WidthPosition;
            bool moveTowardsCenter = luckyNumber < 60;
            bool moveAwayFromCenter = luckyNumber > 80;
            int center = Field.GetCenter().WidthPosition;
            if (moveTowardsCenter)
            {
                if (widthPosition < center)
                    return 1;
                return -1;
            }
            if (moveAwayFromCenter)
            {
                if (widthPosition < center)
                    return -1;
                return 1;
            }

            return 0;
        }
    }
}