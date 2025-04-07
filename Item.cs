using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

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
    public enum BoxColor
    {
      Yellow,
      Blue,
      Red,
      White
    }

    public Dictionary<BoxColor, Color> Colors = new()
    {
      { BoxColor.Yellow, Color.Yellow },
      { BoxColor.Blue, Color.Blue },
      { BoxColor.Red, Color.Red },
      { BoxColor.White, Color.White }
    };

    public List<Point> positions = new();
    public Point OriginPosition;
    public Size size;
    public BoxColor color;
    public bool isHeld = false;
    public Item(Point originPosition, Size size, BoxColor color)
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

    public void Move(Point movement)
    {
      List<Point> newPositions = new List<Point>();
      OriginPosition += movement;
      foreach(Point position in positions) {
        newPositions.Add(position + movement);
      }
      positions = newPositions;
    }

    public static int WidthBySize(Size size)
    {
      return size switch
      {
        Size.Small => 32,
        Size.Tall => 32,
        Size.Long => 64,
        Size.Large => 64,
        _ => 0
      };
    }

    public static int HeightBySize(Size size)
    {
      return size switch
      {
        Size.Small => 32,
        Size.Tall => 64,
        Size.Long => 32,
        Size.Large => 64,
        _ => 0
      };
    }

    public static int XDrawOriginBySize(Size size)
    {
      return size switch
      {
        Size.Small => 0,
        Size.Tall => 0,
        Size.Long => 32,
        Size.Large => 32,
        _ => 0
      };
    }

    public static int YDrawOriginBySize(Size size)
    {
      return size switch
      {
        Size.Small => 0,
        Size.Tall => 32,
        Size.Long => 0,
        Size.Large => 32,
        _ => 0
      };
    }

    public int NumberOfOccupiedSpaces()
    {
      return this.size switch
      {
        Size.Small => 1,
        Size.Tall => 2,
        Size.Long => 2,
        Size.Large => 4,
        _ => 0
      };
    }

    public override bool Equals(object obj)
    {
      bool result;
      if (obj == null || !(obj is Item))
        result = false;
      else
        result = size == ((Item)obj).size && color == ((Item)obj).color;
      return result;
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(size, color);
    }

    public static bool operator ==(Item item1, Item item2)
    {
      bool result;
      if (item1 is null)
        result = item2 is null;
      else
        result = item1.Equals(item2);
      return result;
    }
    public static bool operator!=(Item item1, Item item2)
    {
      return !(item1 == item2);
    }
  }
}
