using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BaseGameProject
{
  internal class TestArtist : IArtist
  {
    public void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle sourceRectangle, Color color) { }

    public void DrawString(SpriteFont font, string text, Vector2 position, Color color) { }
    public int ScreenWidth()
    {
      return 0;
    }

    public int ScreenHeight()
    {
      return 0;
    }
  }
}
