using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumpster_Diving
{
  internal class StorageRoom
  {
    public readonly Dictionary<Point, Tile> storageRoom;
    public StorageRoom()
    {
      storageRoom = new Dictionary<Point, Tile>();
      for(var y = 0; y < 10; y++) {
        for (var x = 0; x < 10; x++) {
          storageRoom.Add(new Point(x,y), new Tile(new Point(x,y)));
        }
      }
    }

    public Tile GetTileAtPosition(Point position)
    {
      storageRoom.TryGetValue(position, out var tile);
      tile ??= new Tile();
      return tile;
    }
    public int GetTileTypeAtPosition(Point position)
    {
      var tile = GetTileAtPosition(position);
      return (int)tile.Type;
    }
  }
}
