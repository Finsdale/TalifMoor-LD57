using BaseGameProject;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }

    internal Rectangle DestinationRectangle(Point position)
    {
      return new Rectangle(
        position.X * 32,
        position.Y * 32,
        32,32);
    }

    internal Rectangle SourceRectangle(Point position)
    {
      Rectangle result = new Rectangle(0, 0, 32, 32);
      return result;
    }
  }
}
