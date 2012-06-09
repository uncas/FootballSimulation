using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uncas.FootballSimulation
{
    public struct FieldPosition
    {
        private int _x;
        private int _y;

        public FieldPosition(int widthPosition, int lengthPosition)
        {
            // TODO: Complete member initialization
            this._x = widthPosition;
            this._y = lengthPosition;
        }

        public int WidthPosition
        {
            get { return _x; }
            set { _x = value; }
        }

        public int LengthPosition
        {
            get { return _y; }
            set { _y = value; }
        }

        public FieldPosition Move(int widthDelta, int lengthDelta)
        {
            return new FieldPosition(
                this.WidthPosition + widthDelta,
                this.LengthPosition + lengthDelta);
        }

        public override string ToString()
        {
            return string.Format(
                "({0},{1})",
                this.WidthPosition,
                this.LengthPosition);
        }

        public static bool operator ==(FieldPosition a, FieldPosition b)
        {
            return a.WidthPosition == b.WidthPosition &&
                a.LengthPosition == b.LengthPosition;
        }

        public static bool operator !=(FieldPosition a, FieldPosition b)
        {
            return !(a == b);
        }
    }
}
