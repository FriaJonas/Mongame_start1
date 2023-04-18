using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Reflection.Metadata.BlobBuilder;

namespace Mongame_start1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D TextureBg;

        //Skeppet - En grafikvaiabel och en raktangle
        private Texture2D TextureSpaceShip;

        private Rectangle SpaceShip;

        private Rectangle SpaceShip2;

        SpriteFont Font;


        int points = 0;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            Window.AllowUserResizing = true;

            _graphics.PreferredBackBufferWidth = 1200;//GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = 800; // GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            _graphics.ApplyChanges();

            SpaceShip = new Rectangle(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight - 120,100,100);
            SpaceShip2 = new Rectangle(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight - 620, 100, 100);
            base.Initialize();
            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            TextureBg = Content.Load<Texture2D>("bgspace");
            TextureSpaceShip = Content.Load<Texture2D>("SpaceShip");

            //Laddar in fonten
            Font = Content.Load<SpriteFont>("Font");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Left))
            {
                SpaceShip.X -= 5;
            }
            if (ks.IsKeyDown(Keys.Right))
            {
                SpaceShip.X += 5;
            }
            if (ks.IsKeyDown(Keys.Down) && SpaceShip.Y < this.GraphicsDevice.Viewport.Height - 90)
            {
                SpaceShip.Y += 5;
            }
            if (ks.IsKeyDown(Keys.Up) && SpaceShip.Y > 0)
            {
                SpaceShip.Y -= 5;
            }
            if (SpaceShip.Intersects(SpaceShip2))
            {
                points++;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

                
            _spriteBatch.Draw(TextureSpaceShip, SpaceShip, Color.White);
            _spriteBatch.Draw(TextureSpaceShip, SpaceShip2, Color.White);

            _spriteBatch.DrawString(Font, "Points " + points, new Vector2(120, 20), Color.White);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}