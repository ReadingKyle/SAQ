using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SuperAdventureQuest
{
    public class SAQGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Hero hero;

        private SceneElement hill1;
        private SceneElement hill2;
        private SceneElement hill3;
        private SceneElement hill4;
        private SceneElement castle;
        private SceneElement sky;
        private SceneElement clouds;
        private SceneElement title;
        private SceneElement fog;

        private SpriteFont november;

        private bool displayMessage = false;

        private Texture2D blackScreen;
        private double endScreenTimer = 0;

        public SAQGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Initialize all the elements in the scene
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Mouse.SetCursor(MouseCursor.FromTexture2D(Content.Load<Texture2D>("swordpointer"), 0, 0 ));
            Window.Title = "Super Adventure Quest!";
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 800;
            _graphics.ApplyChanges();

            sky = new SceneElement() { Position = new Vector2(256, 256) };
            clouds = new SceneElement() { Position = new Vector2(300, 256) };
            castle = new SceneElement() { Position = new Vector2(225, 256) };
            hill4 = new SceneElement() { Position = new Vector2(225, 256) };
            hill3 = new SceneElement() { Position = new Vector2(225, 256) };
            hill2 = new SceneElement() { Position = new Vector2(225, 300) };
            fog = new SceneElement() { Position = new Vector2(225, 300) };
            hill1 = new SceneElement() { Position = new Vector2(300, 300) };
            title = new SceneElement() { Position = new Vector2(256, 256) };

            hero = new Hero() { Position = new Vector2(850 , 650) };
            base.Initialize();
        }
        /// <summary>
        /// Load all the elements into the scene
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            sky.LoadContent(Content, _graphics.GraphicsDevice, "sky", 0.002f);
            clouds.LoadContent(Content, _graphics.GraphicsDevice, "clouds", -0.01f);
            castle.LoadContent(Content, _graphics.GraphicsDevice, "castle", 0f);
            hill4.LoadContent(Content, _graphics.GraphicsDevice, "hill4", 0f);
            hill3.LoadContent(Content, _graphics.GraphicsDevice, "hill3", 0.005f);
            hill2.LoadContent(Content, _graphics.GraphicsDevice, "hill2", 0.015f);
            fog.LoadContent(Content, _graphics.GraphicsDevice, "fog", -0.015f);
            hill1.LoadContent(Content, _graphics.GraphicsDevice, "hill1", 0.02f);
            title.LoadContent(Content, _graphics.GraphicsDevice, "title", 0.002f);

            hero.LoadContent(Content);

            november = Content.Load<SpriteFont>("november");

            blackScreen = new Texture2D(GraphicsDevice, 1, 1);
            blackScreen.SetData(new[] { Color.Black });
        }

        /// <summary>
        /// Update all elements in the scene
        /// </summary>
        /// <param name="gameTime">The game's clock time</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                displayMessage = true;
            }

            hero.Update(gameTime);
            hill1.Update(gameTime);
            hill2.Update(gameTime);
            hill3.Update(gameTime);
            hill4.Update(gameTime);
            castle.Update(gameTime);
            clouds.Update(gameTime);
            fog.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// Draw all elements in the scene
        /// </summary>
        /// <param name="gameTime">Timer in the game</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone);
            if (displayMessage)
            {
                endScreenTimer += gameTime.ElapsedGameTime.TotalSeconds;
                _spriteBatch.Draw(blackScreen,
                        GraphicsDevice.Viewport.Bounds, Color.Black);
                _spriteBatch.DrawString(november, "coward...", new Vector2(25, 500), Color.MistyRose);
                if (endScreenTimer > 2)
                {
                    Exit();
                }
            }
            else
            {
                sky.Draw(_spriteBatch);
                clouds.Draw(_spriteBatch);
                castle.Draw(_spriteBatch);
                hill4.Draw(_spriteBatch);
                hill3.Draw(_spriteBatch);
                hill2.Draw(_spriteBatch);
                fog.Draw(_spriteBatch);
                hill1.Draw(_spriteBatch);
                title.Draw(_spriteBatch);

                hero.Draw(gameTime, _spriteBatch);

                _spriteBatch.DrawString(november, "PRESS [ESC]\nTO FLEE!", new Vector2(30, 505), Color.Black);
                _spriteBatch.DrawString(november, "PRESS [ESC]\nTO FLEE!", new Vector2(25, 500), Color.MistyRose);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}