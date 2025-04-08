using BaseGameProject;
using ControllerInput;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Dumpster_Diving
{
  public class PlayState : IGameState
  {
    public GameStateMachine gameStateMachine;
    public Scenario Scenario { get; set; }
    public PlayPatron Patron { get; set; }
    public PlayState(GameStateMachine gameStateMachine)
    {
      this.gameStateMachine = gameStateMachine;
      Scenario = new Scenario();
      Patron = new PlayPatron(Scenario);
    }

    public void Update(NewInput input)
    {
      if (!Scenario.GameOver) {
        if (input.KBInput.IsButtonPressed(Keys.W) || input.KBInput.IsButtonPressed(Keys.Up)) {
          Scenario.MovePlayer(new Point(0, -1));
        }
        if (input.KBInput.IsButtonPressed(Keys.A) || input.KBInput.IsButtonPressed(Keys.Left)) {
          Scenario.MovePlayer(new Point(-1, 0));
        }
        if (input.KBInput.IsButtonPressed(Keys.S) || input.KBInput.IsButtonPressed(Keys.Down)) {
          Scenario.MovePlayer(new Point(0, 1));
        }
        if (input.KBInput.IsButtonPressed(Keys.D) || input.KBInput.IsButtonPressed(Keys.Right)) {
          Scenario.MovePlayer(new Point(1, 0));
        }
        if (input.KBInput.IsButtonPressed(Keys.Q)) {
          Scenario.TurnPlayerLeft();
        }
        if (input.KBInput.IsButtonPressed(Keys.E)) {
          Scenario.TurnPlayerRight();
        }
        if (input.KBInput.IsButtonPressed(Keys.Space)) {
          Scenario.PlayerGrabsOrDropsItem();
        }
        Scenario.GenerateItem();
        Scenario.Update();
      }
      else {
        gameStateMachine.Push(gameStateMachine.gameOverState);
      }
    }

    public void Draw(IArtist artist)
    {
      Patron.Draw(artist);
    }

    public void ResetScenario()
    {
      Scenario.Reset();
    }
  }
}
