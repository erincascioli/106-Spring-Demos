using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegateDemo
{
    struct Vector2
    {
        private int x;
        private int y;

        public int X
        {
            get{ return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// String representation of this vector
        /// Formatted as such: (x, y)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format(
                "({0}, {1})",
                x,
                y);
        }
    }
}
