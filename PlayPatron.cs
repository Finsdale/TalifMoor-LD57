using BaseGameProject;
using Microsoft.Xna.Framework;

namespace Dumpster_Diving
{
  public class PlayPatron : IPatron
  {
    readonly TextureCollection TC;
    readonly Scenario scenario;

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
          SourceRectangle(),
          Color.White);
      }
      artist.Draw(TC.Player,
        new Rectangle(scenario.player.Position.X * 32, scenario.player.Position.Y * 32, 32, 32),
        new Rectangle((int)scenario.player.Facing * 32, 0, 32, 32),
        Color.White);
      foreach(var item in scenario.Items()) {
        Point size;
        switch (item.size) {
          case Item.Size.Small:
            size = new Point(32, 32);
            break;
          case Item.Size.Long:
            size = new Point(64, 32);
            break;
          case Item.Size.Tall:
            size = new Point(32, 64);
            break;
          case Item.Size.Large:
            size = new Point(64, 64);
            break;
          default:
            size = new Point(32, 32);
            break;
        }
        artist.Draw(
          TC.Box,
          new Rectangle(item.OriginPosition.X * 32, item.OriginPosition.Y * 32, size.X, size.Y),
          new Rectangle(0, 0, 32, 32),
          item.color);
      }
    }

    internal static Rectangle DestinationRectangle(Point position)
    {
      return new Rectangle(
        position.X * 32,
        position.Y * 32,
        32,32);
    }

    internal static Rectangle SourceRectangle()
    {
      Rectangle result = new(0, 0, 32, 32);
      return result;
    }
  }
}
