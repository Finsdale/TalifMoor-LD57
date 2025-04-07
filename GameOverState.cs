using BaseGameProject;
using ControllerInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Dumpster_Diving
{
  public class GameOverState : IGameState
  {
    GameStateMachine gameStateMachine;
    GameTimer gameTimer;
    TextureCollection TC;
    public GameOverState(GameStateMachine gameStateMachine)
    {
      this.gameStateMachine = gameStateMachine;
      gameTimer = new GameTimer(3);
      gameTimer.Reset();
      TC = TextureCollection.Instance;
    }
    public void Update(NewInput input)
    {
      if (gameTimer.Complete()) {
        gameTimer.Reset();
        gameStateMachine.Pop();
        gameStateMachine.Push(gameStateMachine.titleState);
        gameStateMachine.titleState.Reset();
      }
      else gameTimer.Update();
    }
    public void Draw(IArtist artist)
    {
      artist.Draw(TC.GameOver,
        new Rectangle(0, 0, 400, 225),
        new Rectangle(0, 0, 400, 225),
        Color.White);
    }
  }
}
