using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BaseGameProject
{
  public interface IArtist
  {
    void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle sourceRectangle, Color color);
    void DrawString(SpriteFont font, string text, Vector2 position, Color color);
    int ScreenWidth();
    int ScreenHeight();
  }
}
