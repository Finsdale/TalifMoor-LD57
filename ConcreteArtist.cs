using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BaseGameProject
{
  internal class ConcreteArtist : IArtist
  {
    public SpriteBatch SpriteBatch { get; set; }
    public void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle sourceRectangle, Color color)
    {
      SpriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color);
    }

    public void DrawString(SpriteFont font, string text, Vector2 position, Color color)
    {
      SpriteBatch.DrawString(font, text, position, color);
    }

    public int ScreenWidth()
    {
      return SpriteBatch.GraphicsDevice.Viewport.Width;
    }
    public int ScreenHeight()
    {
      return SpriteBatch.GraphicsDevice.Viewport.Height;
    }
  }
}
