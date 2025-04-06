using BaseGameProject;
using ControllerInput;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dumpster_Diving
{
  public class PlayState : IGameState
  {
    public GameStateMachine gameStateMachine;
    public Scenario scenario { get; set; }
    public PlayPatron patron { get; set; }
    public PlayState(GameStateMachine gameStateMachine)
    {
      this.gameStateMachine = gameStateMachine;
      scenario = new Scenario();
      patron = new PlayPatron(scenario);
    }

    public void Update(NewInput input)
    {
      if (input.KBInput.IsButtonPressed(Keys.W)) {
        scenario.MovePlayer(new Point(0, -1));
      }
      if (input.KBInput.IsButtonPressed(Keys.A)) {
        scenario.MovePlayer(new Point(-1,0));
      }
      if (input.KBInput.IsButtonPressed(Keys.S)) {
        scenario.MovePlayer(new Point(0,1));
      }
      if (input.KBInput.IsButtonPressed(Keys.D)) {
        scenario.MovePlayer(new Point(1,0));
      }
      if (input.KBInput.IsButtonPressed(Keys.Q)) {
        scenario.TurnPlayerLeft();
      }
      if (input.KBInput.IsButtonPressed(Keys.E)) {
        scenario.TurnPlayerRight();
      }
    }

    public void Draw(IArtist artist)
    {
      patron.Draw(artist);
    }
  }
}
