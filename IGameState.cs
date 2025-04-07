using ControllerInput;

namespace BaseGameProject
{
  public interface IGameState
  {
    void Update(NewInput input);

    void Draw(IArtist artist);
  }
}
