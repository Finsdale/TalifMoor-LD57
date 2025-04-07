using Microsoft.Xna.Framework.Graphics;

namespace BaseGameProject
{
  public sealed class TextureCollection
  {
    private static readonly TextureCollection collection = new();
    public Texture2D Floors { get; private set; }
    public Texture2D Player { get; private set; }
    public Texture2D Box { get; private set; }
    public Texture2D BackDrop { get; private set; }
    public SpriteFont Font { get; private set; }
    private TextureCollection() { }
    public static TextureCollection Instance
    {
      get
      {
        return collection;
      }
    }

    public void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
    {
      Floors = content.Load<Texture2D>("Floor tile");
      Player = content.Load<Texture2D>("Player");
      Box = content.Load<Texture2D>("Box");
      BackDrop = content.Load<Texture2D>("Basic Border");
      Font = content.Load<SpriteFont>("Font");
    }
  }
}