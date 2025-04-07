using BaseGameProject;
using Microsoft.Xna.Framework;

namespace Dumpster_Diving
{
  public class PlayPatron : IPatron
  {
    readonly TextureCollection TC;
    Scenario scenario;

    public PlayPatron(Scenario scenario)
    {
      TC = TextureCollection.Instance;
      this.scenario = scenario;
    }
    public void Draw(IArtist artist)
    {
      foreach(var position in scenario.StorageRoomTilePositions()) {
        artist.Draw(TC.Floors,
          DestinationRectangle(position),
          SourceRectangle(position),
          Color.White);
      }

      artist.Draw(TC.Player,
        new Rectangle(scenario.player.Position.X * 32, scenario.player.Position.Y * 32, 32, 32),
        new Rectangle((int)scenario.player.Facing * 32, 0, 32, 32),
        Color.White);

      foreach(var item in scenario.Items()) {
        artist.Draw(
          TC.Box,
          new Rectangle(
            item.OriginPosition.X * 32,
            item.OriginPosition.Y * 32, 
            Item.WidthBySize(item.size), 
            Item.HeightBySize(item.size)),
          new Rectangle(
            Item.XDrawOriginBySize(item.size), 
            Item.YDrawOriginBySize(item.size),
            Item.WidthBySize(item.size),
            Item.HeightBySize(item.size)),
          item.Colors[item.color]);
      }
    }



    internal static Rectangle DestinationRectangle(Point position)
    {
      return new Rectangle(
        position.X * 32,
        position.Y * 32,
        32,32);
    }

    internal Rectangle SourceRectangle(Point position)
    {
      Tile tile = scenario.GetTileAtRoomPosition(position);
      int XPosition = GetSourceXPositionFromTileType(tile);
      Rectangle result = new(XPosition, 0, 32, 32);
      return result;
    }

    int GetSourceXPositionFromTileType(Tile tile)
    {
      return tile.Type switch
      {
        Tile.TileType.Storage => 0,
        Tile.TileType.Entry => 32,
        Tile.TileType.EntryOrigin => 32,
        Tile.TileType.Exit => 64,
        _ => 0,
      };
     }
  }
}
