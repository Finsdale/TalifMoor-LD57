using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Dumpster_Diving
{
  internal class StorageRoom
  {
    public readonly Dictionary<Point, Tile> storageRoom;
    public StorageRoom()
    {
      storageRoom = new Dictionary<Point, Tile>();
      for(var y = 0; y < 6; y++) {
        for (var x = 0; x < 10; x++) {
          storageRoom.Add(new Point(x,y), new Tile(new Point(x,y)));
        }
      }

      GetTileAtPosition(new Point(0,2)).Type = Tile.TileType.EntryOrigin;
      GetTileAtPosition(new Point(0,3)).Type = Tile.TileType.Entry;
      GetTileAtPosition(new Point(1,2)).Type = Tile.TileType.Entry;
      GetTileAtPosition(new Point(1,3)).Type = Tile.TileType.Entry;
      GetTileAtPosition(new Point(8,2)).Type = Tile.TileType.Exit;
      GetTileAtPosition(new Point(8,3)).Type = Tile.TileType.Exit;
      GetTileAtPosition(new Point(9,2)).Type = Tile.TileType.Exit;
      GetTileAtPosition(new Point(9,3)).Type = Tile.TileType.Exit;
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

    public Point PositionOfEntryOrigin()
    {
      return storageRoom.Where(x => x.Value.Type == Tile.TileType.EntryOrigin).First().Key;
    }

    public List<Point> GetExitTilePositions()
    {
      return storageRoom.Where(x => x.Value.Type == Tile.TileType.Exit).Select(x => x.Key).ToList();
    }

    public bool ExitZoneIsClean()
    {
      return storageRoom.Where(x => x.Value.Type == Tile.TileType.Exit).All(x => x.Value.Occupied == false);
    }

    public List<Point> GetEntryZonePositions()
    {
      return storageRoom.Where(x => x.Value.Type == Tile.TileType.Entry || x.Value.Type == Tile.TileType.EntryOrigin).Select(x => x.Key).ToList();
    }
  }
}
