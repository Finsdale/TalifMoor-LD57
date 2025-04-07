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
      artist.Draw(TC.BackDrop, new Rectangle(0, 0, 400, 225), new Rectangle(0, 0, 400, 225), Color.White);

      foreach(var position in scenario.StorageRoomTilePositions()) {
        artist.Draw(TC.Floors,
          DestinationRectangle(position),
          SourceRectangle(position),
          Color.White);
      }

      artist.Draw(TC.Player,
        new Rectangle(scenario.player.Position.X * 32 + 5, scenario.player.Position.Y * 32 + 28, 32, 32),
        new Rectangle((int)scenario.player.Facing * 32, 0, 32, 32),
        Color.White);

      foreach(var item in scenario.Items()) {
        artist.Draw(
          TC.Box,
          new Rectangle(
            item.OriginPosition.X * 32 + 5,
            item.OriginPosition.Y * 32 + 28, 
            Item.WidthBySize(item.size), 
            Item.HeightBySize(item.size)),
          new Rectangle(
            Item.XDrawOriginBySize(item.size), 
            Item.YDrawOriginBySize(item.size),
            Item.WidthBySize(item.size),
            Item.HeightBySize(item.size)),
          item.Colors[item.color]);
      }

      Item requestedItem = scenario.scoring.GetRequestedItem();
      artist.Draw(
        TC.Box,
        new Rectangle(329, 37, Item.WidthBySize(requestedItem.size), Item.HeightBySize(requestedItem.size)),
        new Rectangle(Item.XDrawOriginBySize(requestedItem.size), Item.YDrawOriginBySize(requestedItem.size), Item.WidthBySize(requestedItem.size), Item.HeightBySize(requestedItem.size)),
        requestedItem.Colors[requestedItem.color]);

      artist.DrawString(TC.Font, $"Score: {scenario.scoring.GetScore()}", new Point(220, 0).ToVector2(), Color.Black);
      artist.DrawString(TC.Font, $"High Score: {scenario.scoring.GetHighScore()}", new Point(14, 0).ToVector2(), Color.Black);

      artist.Draw(TC.MeterBackground,
        new Rectangle(340, 109, 40, 122), Color.Beige);
      artist.Draw(TC.MeterFill,
        new Rectangle(345, scenario.TimerMeterYPosition(), 30, scenario.TimerMeterHeight()), Color.CadetBlue);
        artist.Draw(TC.MeterBorder,
          new Rectangle(340, 109, 40, 120), new Color(237,28,36));
    }



    internal static Rectangle DestinationRectangle(Point position)
    {
      return new Rectangle(
        position.X * 32 + 5,
        position.Y * 32 + 28,
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
