using Hoard;
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
    ItemList currentAreaItems, storedItemList;
    public Scoring scoring;
    GameTimer gameTimer;
    public bool GameOver;
    DirectionTimer directionTimer = new DirectionTimer();

    public Scenario()
    {
      scoring = new Scoring();
      gameTimer = new GameTimer();
      Reset();
    }

    public void Reset()
    {
      storageRoomData = new StorageRoom();
      player = new PlayerChar();
      currentAreaItems = new ItemList();
      storedItemList = new ItemList();
      storedItemList.AddBag(3);
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
      return currentAreaItems.Items;
    }

    public void GenerateItem()
    {
      if(!player.HoldsItem && !storageRoomData.AreAnyEntryPositionsOccupied() && PlayerIsNotOnEntryZone()) {
        Item item = storedItemList.PullNextItem();
        item.MoveTo(new Point(0,2));
        currentAreaItems.AddItem(item);
        storageRoomData.ToggleOccupiedForPositions(item.positions);
        if (storedItemList.IsBagSetMissing(3)) {
          storedItemList.AddBag();
        }
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
        heldItem = currentAreaItems.GetItemAtLocation(player.FacedPosition());
        List<Point> exitTilePositions = storageRoomData.GetExitTilePositions();
        int coveredPositions = exitTilePositions.Intersect(heldItem.positions).Count();
        if(coveredPositions == heldItem.NumberOfOccupiedSpaces() && storageRoomData.ExitZoneIsClean()) {
          int pointsGained = scoring.ScoreItem(heldItem);
          gameTimer.MatchBonus(pointsGained);
          currentAreaItems.RemoveHeldItem();
          scoring.SetRequestedItem();
        }
        else {
          storageRoomData.ToggleOccupiedForPositions(heldItem.positions);
          heldItem.isHeld = false;
        }
        player.HoldsItem = false;
      }
      else if(PlayerIsFacingItem()) {
        heldItem = currentAreaItems.GetItemAtLocation(player.FacedPosition());
        storageRoomData.ToggleOccupiedForPositions(heldItem.positions);
        heldItem.isHeld = true;
        player.HoldsItem = true;
      }
    }
    public bool PlayerIsFacingItem()
    {
      return currentAreaItems.HasItemAtLocation(player.FacedPosition());
    }

    public List<Point> StorageRoomTilePositions()
    {
      return storageRoomData.storageRoom.Keys.ToList();
    }

    public void ChargeToMove(Point movement)
    {
      if (directionTimer.IsComplete(movement)) {
        MovePlayer(movement);
      }
    }

    public void MovePlayer(Point movement)
    {
      Item heldItem = null;
      bool destinationIsOccupied = false;
      List<Point> checkedLocations = new();
      checkedLocations.Add(player.Position + movement);
      if (player.HoldsItem) {
        heldItem = currentAreaItems.GetHeldItem();
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
