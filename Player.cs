using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shooter
{
    /*
     new Vector2(m_Mouse.Position.X - (_texture.Width / 2f), m_Mouse.Position.Y - (_texture.Height / 2f))
    */

    public class Player : Entity
    {
        public Texture2D player_texture;
        public Texture2D player_projectile;


        private int x, y;

        Vector2 origin;
        Vector2 attackOrigin;
        Rectangle playerRectangle;


        public Player(int pos_x, int pos_y, Texture2D texture, Texture2D player_projectile)
        {

            this.x = pos_x;
            this.y = pos_y;
            this.player_texture = texture;
            this.player_projectile = player_projectile;

            color = Color.White;
            position = new Vector2(x, y);
        }

        public override void Initialize()
        {
            // center of sprite
            origin = new Vector2(player_texture.Width / 2, player_texture.Height / 2);
            attackOrigin = new Vector2(player_texture.Width / 2, player_texture.Height);
            playerRectangle = new Rectangle(0,0, player_texture.Width, player_texture.Height);
        }

        public override void Update(GameTime gameTime)
        {

            MouseState mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                //Attack();
            }

            if(mouseState.RightButton == ButtonState.Pressed)
            {
                SuperMove(new Vector2(position.X, position.Y));
            }

            KeyboardState Movement = Keyboard.GetState();

            if (Movement.IsKeyDown(Keys.W))
            {
                Move(movement.up);
            }
            if (Movement.IsKeyDown(Keys.S))
            {
                Move(movement.down);
            }
            if (Movement.IsKeyDown(Keys.A))
            {
                Move(movement.left);
            }
            if (Movement.IsKeyDown(Keys.D))
            {
                Move(movement.right);
            }

            OnCollisionWorld();
            //IsColliding(playerRectangle)

            base.Update(gameTime);
        }

        private bool IsColliding(Rectangle rect1, Rectangle rect2, int vSpeed)
        {
            if(rect1.Intersects(new Rectangle(rect2.X, rect2.Y + vSpeed, rect2.Width, rect2.Height)))
            {
                while (!rect1.Intersects(new Rectangle(rect2.X, rect2.Y + Sign(vSpeed), rect2.Width, rect2.Height)))
                {
                    
                }
                return true;
            }
            return false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            MouseState m_Mouse = Mouse.GetState();

            float look = LookTowards(new Vector2(m_Mouse.Position.X, m_Mouse.Position.Y), position);

            spriteBatch.Draw(player_texture, position, playerRectangle, color, look, origin, 1.0f, SpriteEffects.None, 1);
            
        }

    }
}
