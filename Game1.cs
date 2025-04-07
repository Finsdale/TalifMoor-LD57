using ControllerInput;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BaseGameProject
{
  public class Game1 : Game
  {
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    RenderTarget2D _renderTarget;
    readonly NewInput playerOne;
    readonly TextureCollection TC;
    readonly GameStateMachine gameStateMachine;
    readonly ConcreteArtist artist;


    public Game1()
    {
      TC = TextureCollection.Instance;
      _graphics = new GraphicsDeviceManager(this);
      Content.RootDirectory = "Content";
      IsMouseVisible = true;
      playerOne = new NewInput(0,true);
      gameStateMachine = new GameStateMachine();
      artist = new ConcreteArtist();
    }

    protected override void Initialize()
    {
      _graphics.PreferredBackBufferWidth = 1200;
      _graphics.PreferredBackBufferHeight = 675;
      _graphics.ApplyChanges();
      _renderTarget = new RenderTarget2D(GraphicsDevice, 400, 225, false, GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.Depth24);
      // TODO: Add your initialization logic here

      base.Initialize();
    }

    protected override void LoadContent()
    {
      _spriteBatch = new SpriteBatch(GraphicsDevice);
      TC.LoadContent(Content);
      // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
      if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        Exit();
      playerOne.Update();
      gameStateMachine.Update(playerOne);
      if (gameStateMachine.Exit == true) Exit();

      // TODO: Add your update logic here

      base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
      GraphicsDevice.SetRenderTarget(_renderTarget);
      GraphicsDevice.Clear(Color.BlueViolet);
      _spriteBatch.Begin();
      artist.SpriteBatch = _spriteBatch;
      gameStateMachine.Draw(artist);
      _spriteBatch.End();

      GraphicsDevice.SetRenderTarget(null);
      GraphicsDevice.Clear(Color.BlueViolet);
      _spriteBatch.Begin();
      _spriteBatch.Draw(_renderTarget, new Rectangle(0, 0, 1200, 675), Color.White);
      _spriteBatch.End();

      // TODO: Add your drawing code here

      base.Draw(gameTime);
    }
  }
}