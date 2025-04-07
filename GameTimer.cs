using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumpster_Diving
{
  internal class GameTimer
  {
    float Length { get; set; }
    float Current { get; set; }
    static readonly float TICK_VALUE = 0.01f;
    public GameTimer(float length = 36)
    {
      Length = length;
    }

    public void Update()
    {
      Current = Math.Max(0, Current - TICK_VALUE);
    }
    public float Reset() { return Current = Length; }

    public bool Complete() { return Current == 0; }
    public bool Fresh() { return Current == Length; }
    public void MatchBonus(int pointsGained) { Current += (0.30f * pointsGained); }
    public float PercentTimerRemains()
    {
      return Math.Min(1, Current / Length);
    }

    public int MeterHeight()
    {
      return (int)(Current / Length * 115);
    }
    public int MeterYPosition()
    {
      return 225 - (int)(Current / Length * 115);
    }
  }
}
