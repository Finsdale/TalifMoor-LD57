using Dumpster_Diving;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hoard
{
  internal class DirectionTimer
  {
    GameTimer timer;
    Point direction = new Point();
    DirectionTimer()
    {
      timer = new GameTimer(0.1f);
    }

    public bool IsComplete(Point direction)
    {
      bool result = false;
      if(this.direction == direction) {
        timer.Update();
        if (timer.Complete()) {
          timer.Reset();
          result = true;
        }
      }
      else {
        timer.Reset();
      }

      return result;
    }
  }
}
