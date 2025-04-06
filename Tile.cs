using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumpster_Diving
{
  internal class Tile
  {
    public enum TileType
    {
      Null = -1,
      Storage,
      Obstruction,
      Entry,
      Exit,
      EntryAndExit,
      Dump
    }
    Point Position { get; set; }
    public bool Occupied = false;
    public TileType Type { get; set; }

    public Tile()
    {
      Position = new Point();
      Type = TileType.Null;
      Occupied = true;
    }
    public Tile(Point position, TileType type = TileType.Storage, bool occupied = false)
    {
      this.Position = position;
      this.Type = type;
      if(type == TileType.Obstruction) {
        this.Occupied = true;
      }
      else {
        this.Occupied = occupied;
      }
    }
  }
}
