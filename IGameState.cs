using ControllerInput;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseGameProject
{
  public interface IGameState
  {
    void Update(NewInput input);

    void Draw(IArtist artist);
  }
}
