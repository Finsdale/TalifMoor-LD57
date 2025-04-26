using Hoard;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Dumpster_Diving
{
  public class ItemList
  {
    public List<Item> Items = new();
    public ItemList() {}

    public bool HasItemAtLocation(Point location)
    {
      bool result = Items.Find(x => x.positions.Contains(location)) != null;
      return result;
    }

    public Item GetItemAtLocation(Point location)
    {
      return Items.Find(x => x.positions.Contains(location));
    }

    public void AddItem(Item item)
    {
      Items.Add(item);
    }
    public Item GetHeldItem()
    {
      return Items.Find(x => x.isHeld);
    }
    public void RemoveHeldItem()
    {
      Items.RemoveAt(Items.FindIndex(x => x.isHeld));
    }

    public void AddBag(int numOfBags = 1, bool shuffle = true)
    {
      if(numOfBags > 0) {
        for(int i = 0;  i < numOfBags; i++) { 
          foreach (var item in ItemBag.ItemSet) {
            Items.Add(item);
          }
        }
      }
      if(shuffle) {
        Shuffle();
      }
    }

    public void Shuffle()
    {
      Random random = new Random();
      List<Item> copiedList = Items;
      List<Item> newItemList = new List<Item>();
      for(int x = copiedList.Count; x > 0; x--) {
        int nextItem = random.Next(copiedList.Count);
        newItemList.Add(copiedList[nextItem]);
        copiedList.RemoveAt(nextItem);
      }    
    }

    
  }
}
