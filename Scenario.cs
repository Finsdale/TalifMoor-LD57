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
      GenerateItem(new Item(new Point(0, 4), Item.Size.Large, Item.BoxColor.Yellow));
    }

    public List<Item> Items()
    {
      return itemList.Items;
    }

    public void GenerateItem(Item item)
    {
      itemList.AddItem(item);
      foreach(Point position in item.positions) {
        storageRoomData.storageRoom[position].Occupied = true;
      }
    }

    public List<Point> StorageRoomTilePositions()
    {
      return storageRoomData.storageRoom.Keys.ToList();
    }

    public void MovePlayer(Point movement)
    {
      Point checkedLocation = player.Position + movement;
      if (StorageRoomTilePositions().Contains(checkedLocation) && !StorageRoomPositionIsOccupied(checkedLocation)) {
        player.Move(movement);
      }
    }

    public bool StorageRoomPositionIsOccupied(Point position)
    {
      return storageRoomData.storageRoom[position].Occupied;
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
