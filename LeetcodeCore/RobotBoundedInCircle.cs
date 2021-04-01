using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class RobotBoundedInCircle
    {
        // 1041. Robot Bounded In Circle
        public bool IsRobotBounded(string instructions)
        {
            var list = new List<(int, int)>() { (0, 1), (-1, 0), (0, -1), (1, 0) };
            var direction = 0;
            var x = 0;
            var y = 0;

            foreach (var c in instructions)
            {
                switch (c)
                {
                    case 'G':
                        x += list[direction].Item1;
                        y += list[direction].Item2;
                        break;
                    case 'L':
                        direction = direction == 3 ? 0 : direction + 1;
                        break;
                    case 'R':
                        direction = direction == 0 ? 3 : direction - 1;
                        break;
                    default:
                        break;
                }
            }

            if (direction == 0 && (x != 0 || y != 0)) // only if there's displacement and direction remains the same, the robot position will diverge
                return false;
            else
                return true;
        }
    }
}
