using Microsoft.Xna.Framework;
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
  }
}
