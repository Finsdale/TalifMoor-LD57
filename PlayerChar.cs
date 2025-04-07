using Microsoft.Xna.Framework;
using System.Collections.Generic;

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
    public Dictionary<Direction, Point> DirectionToPointConversion = new(){
      {Direction.Up, new Point(0, -1) },
      {Direction.Right, new Point(1, 0) },
      {Direction.Down, new Point(0, 1) },
      {Direction.Left, new Point(-1, 0) }
    };
    public Direction Facing = Direction.Up;
    public bool HoldsItem = false;
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
    public Point FacedPosition()
    {
      return Position + DirectionToPointConversion[Facing];
    }
  }
}
