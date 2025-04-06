using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumpster_Diving
{
  public class Scenario
  {

    StorageRoom storageRoomData;
    public PlayerChar player;

    public Scenario()
    {
      storageRoomData = new StorageRoom();
      player = new PlayerChar();
    }

    public List<Point> StorageRoomTilePositions()
    {
      return storageRoomData.storageRoom.Keys.ToList();
    }

    public void MovePlayer(Point movement)
    {
      Point checkedLocation = player.Position + movement;
      if (StorageRoomTilePositions().Contains(checkedLocation)) {
        player.Move(movement);
      }
    }
    public void TurnPlayerLeft()
    {
      player.TurnLeft();
    }
    public void TurnPlayerRight()
    {
      player.TurnRight();
    }
  }
}
