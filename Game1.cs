using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Net.Mime.MediaTypeNames;

namespace Shooter
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        SpriteFont font;

        private Player Player;
        private Enemy enemy;

        private Texture2D player_texture;
        private Texture2D player_projectile_texture;
        private Texture2D Enemy_texture;
        private string text = "Test";

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            _graphics.PreferredBackBufferWidth = 800;  // set this value to the desired width of your window
            _graphics.PreferredBackBufferHeight = 600;   // set this value to the desired height of your window
            _graphics.ApplyChanges();


            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here

            font = Content.Load<SpriteFont>("fonts/File");
            player_texture = Content.Load<Texture2D>("Player");
            player_projectile_texture = Content.Load<Texture2D>("ball");
            Enemy_texture = Content.Load<Texture2D>("box");


            Player = new Player(0, 0, player_texture, player_projectile_texture);
            enemy = new Enemy(Enemy_texture, Player);
            Player.Initialize();
            enemy.Initialize();

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            // TODO: Add your update logic here


            Player.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();

            // Finds the center of the string in coordinates inside the text rectangle
            Vector2 textMiddlePoint = font.MeasureString(text) / 2;
            _spriteBatch.DrawString(font, text, new Vector2(400, 20), Color.White);


            Player.Draw(_spriteBatch);
            enemy.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}