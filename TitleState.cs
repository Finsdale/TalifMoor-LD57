using BaseGameProject;
using ControllerInput;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Dumpster_Diving
{
  public class TitleState : IGameState
  {
    GameTimer timer;
    GameStateMachine gameStateMachine;
    TextureCollection TC;
    public TitleState(GameStateMachine gameStateMachine)
    {
      this.gameStateMachine = gameStateMachine;
      timer = new GameTimer(1.8f);
      timer.Reset();
      TC = TextureCollection.Instance;
    }
    public void Update(NewInput input)
    {
      if (timer.Complete()) {
        if (input.KBInput.IsButtonPressed(Keys.Space)) {
          gameStateMachine.playState.ResetScenario();
          gameStateMachine.Pop();
        }
      }
      else {
        timer.Update();
      }
    }
    public void Draw(IArtist artist)
    {
      artist.Draw(TC.Title1,
        new Rectangle(0, 0, 400, 225),
        new Rectangle(0, 0, 400, 225),
        Color.White);
      if(timer.Complete()) {
        artist.Draw(TC.Title2,
        new Rectangle(0, 0, 400, 225),
        new Rectangle(0, 0, 400, 225),
        Color.White);
      }
    }

    public void Reset()
    {
      timer.Reset();
    }
  }
}
