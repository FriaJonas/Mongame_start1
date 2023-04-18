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
        private Vector2 Velocity;
        private bool IsJump = false;

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

            base.Initialize();
            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            TextureBg = Content.Load<Texture2D>("bgspace");
            TextureSpaceShip = Content.Load<Texture2D>("SpaceShip");

            //Laddar in fonten
            Font = Content.Load<SpriteFont>("Font");



            SpaceShip = new Rectangle(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight - 600, 100, 100);
            SpaceShip2 = new Rectangle(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight - 100, 100, 100);
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
            if (ks.IsKeyDown(Keys.Space)){
                IsJump = true;
                Velocity.Y = -10;
            }
            if (IsJump)
            {
                SpaceShip2.Y += (int)Velocity.Y;
                if (SpaceShip2.Y <= 600)
                {
                    Velocity.Y = 10;
                }
                if(SpaceShip2.Y >= GraphicsDevice.Viewport.Height-100) {
                    IsJump = false;
                    Velocity.Y = 0;
                }
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

                
            _spriteBatch.Draw(TextureSpaceShip, SpaceShip, Color.White);
            _spriteBatch.Draw(TextureSpaceShip, SpaceShip2, Color.Blue);

            _spriteBatch.DrawString(Font, "Points " + points, new Vector2(120, 20), Color.White);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}