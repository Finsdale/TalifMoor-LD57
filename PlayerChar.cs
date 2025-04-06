using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumpster_Diving
{
  public class PlayerChar
  {
    public enum Direction
    {
      Up = 0,
      Right = 1,
      Down = 2,
      Left = 3
    }
    public Direction Facing = Direction.Up;
    public Point Position { get; set; }
    public PlayerChar()
    {
      Position = new Point();
    }
    public void Move(Point movement)
    {
      Position += movement;
    }

    public void MoveToPosition(Point position)
    {
      Position = position;
    }
    public void TurnRight()
    {
      Facing = (Direction)(((int)Facing + 1) % 4);
    }
    public void TurnLeft()
    {
      Facing = (Direction)(((int)Facing + 3) % 4);
    }
  }
}
