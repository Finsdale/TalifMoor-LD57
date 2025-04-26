using Dumpster_Diving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Hoard
{
  internal class ItemBag
  {
    public static readonly List<Item> ItemSet = new List<Item>()
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
  }
}
