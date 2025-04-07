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

      GetTileAtPosition(new Point(0,4)).Type = Tile.TileType.EntryOrigin;
      GetTileAtPosition(new Point(0,5)).Type = Tile.TileType.Entry;
      GetTileAtPosition(new Point(1,4)).Type = Tile.TileType.Entry;
      GetTileAtPosition(new Point(1,5)).Type = Tile.TileType.Entry;
      GetTileAtPosition(new Point(8,4)).Type = Tile.TileType.Exit;
      GetTileAtPosition(new Point(8,5)).Type = Tile.TileType.Exit;
      GetTileAtPosition(new Point(9,4)).Type = Tile.TileType.Exit;
      GetTileAtPosition(new Point(9,5)).Type = Tile.TileType.Exit;
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

    public void ToggleOccupiedForPositions(List<Point> positions)
    {
      foreach (var position in positions) {
        Tile tile = GetTileAtPosition(position);
        tile.Occupied = !tile.Occupied;
      }
    }

    public bool AreAnyEntryPositionsOccupied()
    {
      return storageRoom.Where(x => x.Value.IsEntryPosition() && x.Value.Occupied == true).Count() > 0;
    }
  }
}
