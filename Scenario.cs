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

    readonly StorageRoom storageRoomData;
    public PlayerChar player;
    readonly ItemList itemList;

    public Scenario()
    {
      storageRoomData = new StorageRoom();
      player = new PlayerChar();
      itemList = new ItemList();
      itemList.AddItem(new Item(new Point(0, 4), Item.Size.Large, Color.Brown));
    }

    public List<Item> Items()
    {
      return itemList.Items;
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
