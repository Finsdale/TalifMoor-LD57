using Hoard;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Dumpster_Diving
{
  public class ItemList
  {
    public static readonly List<Item> ItemBag = new List<Item>()
    {
      new Item(new Point(), Item.Size.Small, Item.BoxColor.Yellow),
      new Item(new Point(), Item.Size.Small, Item.BoxColor.Red),
      new Item(new Point(), Item.Size.Small, Item.BoxColor.Blue),
      new Item(new Point(), Item.Size.Small, Item.BoxColor.White),
      new Item(new Point(), Item.Size.Long, Item.BoxColor.Yellow),
      new Item(new Point(), Item.Size.Long, Item.BoxColor.Red),
      new Item(new Point(), Item.Size.Long, Item.BoxColor.Blue),
      new Item(new Point(), Item.Size.Long, Item.BoxColor.White),
      new Item(new Point(), Item.Size.Tall, Item.BoxColor.Yellow),
      new Item(new Point(), Item.Size.Tall, Item.BoxColor.Red),
      new Item(new Point(), Item.Size.Tall, Item.BoxColor.Blue),
      new Item(new Point(), Item.Size.Tall, Item.BoxColor.White),
      new Item(new Point(), Item.Size.Large, Item.BoxColor.Yellow),
      new Item(new Point(), Item.Size.Large, Item.BoxColor.Red),
      new Item(new Point(), Item.Size.Large, Item.BoxColor.Blue),
      new Item(new Point(), Item.Size.Large, Item.BoxColor.White),
    };

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
          foreach (var item in ItemBag) {
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

    public Item PullNextItem()
    {
      Item result = null;
      if(Items.Count > 0) {
        result = Items[0];
        Items.RemoveAt(0);
      }
      return result;
    }

    public bool IsBagSetMissing(int setsExpected = 1)
    {
      bool result = true;
      foreach (var item in ItemBag) {
        if(Items.FindAll(x => x.Equals(item)).Count == setsExpected) {
          result = false;
          break;
        }
      }
      return result;
    }
  }
}
