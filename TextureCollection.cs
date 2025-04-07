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
    public Texture2D Title1 { get; private set; }
    public Texture2D Title2 { get; private set; }
    public Texture2D GameOver { get; private set; }
    public Texture2D MeterBackground { get; private set; }
    public Texture2D MeterBorder { get; private set; }
    public Texture2D MeterFill { get; private set; }
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
      Title1 = content.Load<Texture2D>("TitleScreen1");
      Title2 = content.Load<Texture2D>("TitleScreen2");
      GameOver = content.Load<Texture2D>("GameEndSplash");
      MeterBackground = content.Load<Texture2D>("Meter Background");
      MeterBorder = content.Load<Texture2D>("MeterBorder");
      MeterFill = content.Load<Texture2D>("MeterFill");
      Font = content.Load<SpriteFont>("Font");
    }
  }
}