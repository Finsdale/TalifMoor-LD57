using Dumpster_Diving;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
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
    public DirectionTimer()
    {
      timer = new GameTimer(0.07f);
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
        this.direction = direction;
        timer.Reset();
      }

      return result;
    }

    public void Reset()
    {
      timer.Reset();
    }

    public void Update()
    {
      timer?.Update();
    }
  }
}
