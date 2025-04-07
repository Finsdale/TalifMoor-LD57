using ControllerInput;
using Dumpster_Diving;
using System.Collections.Generic;

namespace BaseGameProject
{
  public class GameStateMachine
  {
    public List<IGameState> GameStack = new();
    public PlayState playState;
    public bool Exit { get; set; } = false;

    public GameStateMachine()
    {
      playState = new PlayState(this);
      Push(playState);
    }

    public void Clear()
    {
      GameStack.Clear();
    }

    public void Push(IGameState gameState)
    {
      GameStack.Add(gameState);
    }

    public void Pop()
    {
      GameStack.RemoveAt(GameStack.Count - 1);
    }

    public void Update(NewInput input)
    {
      if(GameStack.Count > 0) {
        GameStack[^1].Update(input);
      }
    }

    public void Draw(IArtist artist)
    {
      for (int i = 0; i <= GameStack.Count - 1; i++) {
        GameStack[i].Draw(artist);
      }
    }
  }
}
