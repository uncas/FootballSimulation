using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uncas.FootballSimulation
{
    public class Field
    {
        private const int _width = 21;
        private const int _length = 31;

        private FieldPosition _ballPosition = GetCenter();

        public FieldPosition BallPosition
        {
            get
            {
                return _ballPosition;
            }
        }

        public void MoveBall(int widthDelta, int lengthDelta)
        {
            int newWidth = BallPosition.WidthPosition + widthDelta;
            int newLength = BallPosition.LengthPosition + lengthDelta;
            if (newWidth < 1)
                newWidth = 1;
            if (newWidth > _width)
                newWidth = _width;
            if (newLength < 1)
                newLength = 1;
            if (newLength > _length)
                newLength = _length;
            _ballPosition = new FieldPosition(newWidth, newLength);
        }

        public bool BallIsAtGoal1()
        {
            return BallPosition == GetGoal1Position();
        }

        public bool BallIsAtGoal2()
        {
            return BallPosition == GetGoal2Position();
        }

        public void ResetBallPosition()
        {
            _ballPosition = GetCenter();
        }

        private static FieldPosition GetCenter()
        {
            return new FieldPosition(GetWidthCenter(), GetLengthCenter());
        }

        private static int GetWidthCenter()
        {
            return _width / 2 + 1;
        }

        private static int GetLengthCenter()
        {
            return _length / 2 + 1;
        }

        private static FieldPosition GetGoal1Position()
        {
            return new FieldPosition(GetWidthCenter(), 1);
        }

        private static FieldPosition GetGoal2Position()
        {
            return new FieldPosition(GetWidthCenter(), _length);
        }
    }
}
