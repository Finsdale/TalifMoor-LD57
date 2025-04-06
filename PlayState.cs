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
      if (input.KBInput.IsButtonPressed(Keys.W)) {
        Scenario.MovePlayer(new Point(0, -1));
      }
      if (input.KBInput.IsButtonPressed(Keys.A)) {
        Scenario.MovePlayer(new Point(-1,0));
      }
      if (input.KBInput.IsButtonPressed(Keys.S)) {
        Scenario.MovePlayer(new Point(0,1));
      }
      if (input.KBInput.IsButtonPressed(Keys.D)) {
        Scenario.MovePlayer(new Point(1,0));
      }
      if (input.KBInput.IsButtonPressed(Keys.Q)) {
        Scenario.TurnPlayerLeft();
      }
      if (input.KBInput.IsButtonPressed(Keys.E)) {
        Scenario.TurnPlayerRight();
      }
    }

    public void Draw(IArtist artist)
    {
      Patron.Draw(artist);
    }
  }
}
