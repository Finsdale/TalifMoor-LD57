using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumpster_Diving
{
  public class ItemList
  {
    public List<Item> Items = new();
    public ItemList() {}
    public bool HasItemAtLocation(Point location)
    {
      bool result = Items.Find(x => x.positions.Contains(location)) == null;
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
  }
}
