using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumpster_Diving
{
  internal class StorageRoom
  {
    readonly Dictionary<Point, Tile> storageRoom;
    StorageRoom()
    {
      for(var y = 0; y < 10; y++) {
        for (var x = 0; x < 10; x++) {
          storageRoom.Add(new Point(x,y), new Tile(new Point(x,y)));
        }
      }
    }
  }
}
