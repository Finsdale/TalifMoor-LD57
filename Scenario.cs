using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Dumpster_Diving
{
  public class Scenario
  {

    readonly StorageRoom storageRoomData;
    public PlayerChar player;
    readonly ItemList itemList;
    readonly ItemGenerator itemGenerator;

    public Scenario()
    {
      storageRoomData = new StorageRoom();
      player = new PlayerChar();
      itemList = new ItemList();
      itemGenerator = new ItemGenerator();
      GenerateItem();
    }

    public Tile GetTileAtRoomPosition(Point position)
    {
      return storageRoomData.GetTileAtPosition(position);
    }

    public List<Item> Items()
    {
      return itemList.Items;
    }

    public void GenerateItem()
    {
      if(!player.HoldsItem && !storageRoomData.AreAnyEntryPositionsOccupied()) {
        Item item = itemGenerator.GenerateItem(storageRoomData.PositionOfEntryOrigin());
        itemList.AddItem(item);
        storageRoomData.ToggleOccupiedForPositions(item.positions);
      }
    }

    public void PlayerGrabsOrDropsItem()
    {
      Item heldItem;
      if (player.HoldsItem) {
        heldItem = itemList.GetItemAtLocation(player.FacedPosition());
        storageRoomData.ToggleOccupiedForPositions(heldItem.positions);
        heldItem.isHeld = false;
        player.HoldsItem = false;
      }
      else if(PlayerIsFacingItem()) {
        heldItem = itemList.GetItemAtLocation(player.FacedPosition());
        storageRoomData.ToggleOccupiedForPositions(heldItem.positions);
        heldItem.isHeld = true;
        player.HoldsItem = true;
      }
    }
    public bool PlayerIsFacingItem()
    {
      return itemList.HasItemAtLocation(player.FacedPosition());
    }

    public List<Point> StorageRoomTilePositions()
    {
      return storageRoomData.storageRoom.Keys.ToList();
    }

    public void MovePlayer(Point movement)
    {
      Item heldItem = null;
      bool destinationIsOccupied = false;
      List<Point> checkedLocations = new();
      checkedLocations.Add(player.Position + movement);
      if (player.HoldsItem) {
        heldItem = itemList.GetHeldItem();
        foreach(Point position in heldItem.positions) {
          checkedLocations.Add(position + movement);
        }
      }
      foreach (Point position in checkedLocations) {
        if (storageRoomData.GetTileAtPosition(position).Occupied) {
          destinationIsOccupied = true;
          break;
        }
      }

      if (!destinationIsOccupied) {
        player.Move(movement);
        heldItem?.Move(movement);
      }
    }

    public bool StorageRoomPositionIsOccupied(Point position)
    {
      return storageRoomData.storageRoom[position].Occupied;
    }
    public void TurnPlayerLeft()
    {
      if (!player.HoldsItem) player.TurnLeft();
    }
    public void TurnPlayerRight()
    {
      if (!player.HoldsItem) player.TurnRight();
    }
  }
}
