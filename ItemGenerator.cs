using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumpster_Diving
{
  internal class ItemGenerator
  {
    Random random = new Random();
    public ItemGenerator(){}

    public Item GenerateItem(Point originPosition)
    {
      int value = random.Next(0, 16);
      int size = value % 4;
      int color = value / 4;
      Item result = new Item(originPosition, (Item.Size)size, (Item.BoxColor)color);
      return result;
    }
  }
}
