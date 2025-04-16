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
        if (UpButtonIsDown(input)) {
          if(UpIsPressed(input)) {
            Scenario.MovePlayer(new Point(0, -1));
          } else if(UpIsHeld(input)) {
            Scenario.ChargeToMove(new Point(0, -1));
          }
        }
        if (LeftButtonIsDown(input)) {
          if(LeftIsPressed(input)) {
            Scenario.MovePlayer(new Point(-1, 0));
          } else if(LeftIsHeld(input)) {
            Scenario.ChargeToMove(new Point(-1, 0));
          }
        }
        if (DownButtonIsDown(input)) {
          if (DownIsPressed(input)) {
            Scenario.MovePlayer(new Point(0, 1));
          }
          else if (DownIsHeld(input)) {
            Scenario.ChargeToMove(new Point(0, 1));
          }
        }
        if (RightButtonIsDown(input)) {
          if(RightIsPressed(input)) {
            Scenario.MovePlayer(new Point(1, 0));
          } else if (RightIsHeld(input)) {
            Scenario.ChargeToMove(new Point(1, 0));
          }
        }
        if (input.KBInput.IsButtonPressed(Keys.Q) || input.Controllers[0].IsButtonPressed(Buttons.LeftShoulder) || input.Controllers[0].IsButtonPressed(Buttons.LeftTrigger)) {
          Scenario.TurnPlayerLeft();
        }
        if (input.KBInput.IsButtonPressed(Keys.E) || input.Controllers[0].IsButtonPressed(Buttons.RightShoulder) || input.Controllers[0].IsButtonPressed(Buttons.RightTrigger)) {
          Scenario.TurnPlayerRight();
        }
        if (input.KBInput.IsButtonPressed(Keys.Space) || input.Controllers[0].IsButtonPressed(Buttons.A)) {
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

    bool UpIsPressed(NewInput input)
    {
      return input.KBInput.IsButtonPressed(Keys.W) || input.KBInput.IsButtonPressed(Keys.Up) || input.Controllers[0].IsButtonPressed(Buttons.DPadUp);
    }
    bool UpIsHeld(NewInput input)
    {
      return input.KBInput.IsButtonHeld(Keys.W) || input.KBInput.IsButtonHeld(Keys.Up) || input.Controllers[0].IsButtonHeld(Buttons.DPadUp);
    }

    bool UpButtonIsDown(NewInput input)
    {
      return input.KBInput.IsButtonDown(Keys.W) || input.KBInput.IsButtonDown(Keys.Up) || input.Controllers[0].IsButtonDown(Buttons.DPadUp);
    }

    bool LeftIsPressed(NewInput input)
    {
      return input.KBInput.IsButtonPressed(Keys.A) || input.KBInput.IsButtonPressed(Keys.Left) || input.Controllers[0].IsButtonPressed(Buttons.DPadLeft);
    }
    bool LeftIsHeld(NewInput input)
    {
      return input.KBInput.IsButtonHeld(Keys.A) || input.KBInput.IsButtonHeld(Keys.Left) || input.Controllers[0].IsButtonHeld(Buttons.DPadLeft);
    }

    bool LeftButtonIsDown(NewInput input)
    {
      return input.KBInput.IsButtonDown(Keys.A) || input.KBInput.IsButtonDown(Keys.Left) || input.Controllers[0].IsButtonDown(Buttons.DPadLeft);
    }

    bool DownIsPressed(NewInput input)
    {
      return input.KBInput.IsButtonPressed(Keys.S) || input.KBInput.IsButtonPressed(Keys.Down) || input.Controllers[0].IsButtonPressed(Buttons.DPadDown);
    }
    bool DownIsHeld(NewInput input)
    {
      return input.KBInput.IsButtonHeld(Keys.S) || input.KBInput.IsButtonHeld(Keys.Down) || input.Controllers[0].IsButtonHeld(Buttons.DPadDown);
    }

    bool DownButtonIsDown(NewInput input)
    {
      return input.KBInput.IsButtonDown(Keys.S) || input.KBInput.IsButtonDown(Keys.Down) || input.Controllers[0].IsButtonDown(Buttons.DPadDown);
    }

    bool RightIsPressed(NewInput input)
    {
      return input.KBInput.IsButtonPressed(Keys.D) || input.KBInput.IsButtonPressed(Keys.Right) || input.Controllers[0].IsButtonPressed(Buttons.DPadRight);
    }
    bool RightIsHeld(NewInput input)
    {
      return input.KBInput.IsButtonHeld(Keys.D) || input.KBInput.IsButtonHeld(Keys.Right) || input.Controllers[0].IsButtonHeld(Buttons.DPadRight);
    }

    bool RightButtonIsDown(NewInput input)
    {
      return input.KBInput.IsButtonDown(Keys.D) || input.KBInput.IsButtonDown(Keys.Right) || input.Controllers[0].IsButtonDown(Buttons.DPadRight);
    }
  }
}
