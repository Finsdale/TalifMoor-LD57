﻿using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Dumpster_Diving
{
  public class Scoring
  {
    int Score = 0;
    int HighScore = 0;
    ItemList requestedItems;
    Item requestedItem { get
      {
        return requestedItems.Items[0];
      } 
    }

    public Scoring()
    {
      requestedItems = new ItemList();
      requestedItems.AddBag();
    }

    public int ScoreItem(Item item)
    {
      int result = 0;
      if (item == requestedItem) {
        result = 12;
      }
      else if(item.color == requestedItem.color || item.size == requestedItem.size) {
        result = 4;
      }
      Score += result;
      if (Score > HighScore) {
        HighScore = Score;
      }
      return result;
    }
    public void SetRequestedItem()
    {
      requestedItems.PullNextItem();
      if (requestedItems.IsBagSetMissing()) {
        requestedItems.AddBag();
      }
    }

    public int GetScore()
    {
      return Score;
    }

    public int GetHighScore()
    {
      return HighScore;
    }

    public Item GetRequestedItem()
    {
      return requestedItem;
    }
    public void Reset()
    {
      Score = 0;
    }
  }
}
