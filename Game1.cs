using ControllerInput;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BaseGameProject
{
  public class Game1 : Game
  {
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    readonly InputAdapter p1Control;
    Input playerOne;
    readonly TextureCollection TC;
    readonly GameStateMachine gameStateMachine;
    readonly ConcreteArtist artist;


    public Game1()
    {
      TC = TextureCollection.Instance;
      _graphics = new GraphicsDeviceManager(this);
      Content.RootDirectory = "Content";
      IsMouseVisible = true;
      p1Control = new InputAdapter();
      playerOne = new Input();
      gameStateMachine = new GameStateMachine();
      artist = new ConcreteArtist();
    }

    protected override void Initialize()
    {
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
      playerOne = p1Control.GetInput();
      gameStateMachine.Update(playerOne);
      if (gameStateMachine.Exit == true) Exit();

      // TODO: Add your update logic here

      base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
      GraphicsDevice.Clear(Color.CornflowerBlue);
      _spriteBatch.Begin();
      artist.SpriteBatch = _spriteBatch;
      gameStateMachine.Draw(artist);
      _spriteBatch.End();

      // TODO: Add your drawing code here

      base.Draw(gameTime);
    }
  }
}