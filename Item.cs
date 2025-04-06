using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumpster_Diving
{
  public class Item
  {
    public enum Size
    {
      Small,
      Long,
      Tall,
      Large
    }
    public enum Color
    {
      Yellow,
      Green,
      Blue,
      Pink
    }
    public List<Point> positions = new List<Point>();
    public Point OriginPosition;
    public Size size;
    public Color color;
    public bool carried = false;
    public Item(Point originPosition, Size size, Color color)
    {
      OriginPosition = originPosition;
      this.size = size;
      this.color = color;
      positions.Add(originPosition);
      switch (size) {
        case Size.Long:
          this.positions.Add(new Point(originPosition.X + 1, originPosition.Y));
          break;
        case Size.Tall:
          this.positions.Add(new Point(originPosition.X, originPosition.Y + 1));
          break;
        case Size.Large:
          this.positions.Add(new Point(originPosition.X + 1, originPosition.Y));
          this.positions.Add(new Point(originPosition.X, originPosition.Y + 1));
          this.positions.Add(new Point(originPosition.X + 1, originPosition.Y + 1));
          break;
      }
    }
  }
}
