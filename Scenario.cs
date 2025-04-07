using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Dumpster_Diving
{
  public class Scenario
  {

    StorageRoom storageRoomData;
    public PlayerChar player;
    ItemList itemList;
    ItemGenerator itemGenerator;
    public Scoring scoring;
    GameTimer gameTimer;
    public bool GameOver;

    public Scenario()
    {
      itemGenerator = new ItemGenerator();
      scoring = new Scoring(itemGenerator.GenerateItem(new Point()));
      gameTimer = new GameTimer();
      Reset();
    }

    public void Reset()
    {
      storageRoomData = new StorageRoom();
      player = new PlayerChar();
      itemList = new ItemList();
      GenerateItem();
      scoring.Reset();
      gameTimer.Reset();
      GameOver = false;
    }
    public void Update()
    {
      gameTimer.Update();
      if (gameTimer.Complete()) {
        GameOver = true;
      }
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
      if(!player.HoldsItem && !storageRoomData.AreAnyEntryPositionsOccupied() && PlayerIsNotOnEntryZone()) {
        Item item = itemGenerator.GenerateItem(storageRoomData.PositionOfEntryOrigin());
        itemList.AddItem(item);
        storageRoomData.ToggleOccupiedForPositions(item.positions);
      }
    }

    bool PlayerIsNotOnEntryZone()
    {
      return !storageRoomData.GetEntryZonePositions().Contains(player.Position);
    }

    public void PlayerGrabsOrDropsItem()
    {
      Item heldItem;
      if (player.HoldsItem) {
        heldItem = itemList.GetItemAtLocation(player.FacedPosition());
        List<Point> exitTilePositions = storageRoomData.GetExitTilePositions();
        int coveredPositions = exitTilePositions.Intersect(heldItem.positions).Count();
        if(coveredPositions == heldItem.NumberOfOccupiedSpaces() && storageRoomData.ExitZoneIsClean()) {
          int pointsGained = scoring.ScoreItem(heldItem);
          gameTimer.MatchBonus(pointsGained);
          itemList.RemoveHeldItem();
          scoring.SetRequestedItem(itemGenerator.GenerateItem(new Point()));
        }
        else {
          storageRoomData.ToggleOccupiedForPositions(heldItem.positions);
          heldItem.isHeld = false;
        }
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

    public int TimerMeterYPosition()
    {
      return gameTimer.MeterYPosition();
    }
    public int TimerMeterHeight()
    {
      return gameTimer.MeterHeight();
    }
  }
}
