using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter
{
    public abstract class Entity
    {

        //Movement
        public enum movement { up, down, left ,right }
        public Vector2 position;
        public int speed = 2;

        //debug
        public Color color;

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
        public virtual void Update(GameTime gameTime)
        {

        }
        public virtual void Initialize()
        {

        }
        public virtual void RandomInstantiation()
        {
            int MaxWidth = 800;
            int MaxHeight = 600;

            Random random = new Random();

            int x = random.Next(0, MaxWidth);
            int y = random.Next(0, MaxHeight);

            position = new Vector2(x, y);
        }
        public virtual void OnCollisionWorld()
        {
            if(this.position.X > 800)
            {
                this.position.X = 0;
            }
            else if(this.position.X < 0)
            {
                this.position.X = 800;
            }
            else if (this.position.Y > 600)
            {
                this.position.Y = 0;
            }
            else if (this.position.Y < 0)
            {
                this.position.Y = 600;
            }
        }
        public virtual void Move(movement move)
        {
            if(move == movement.up)
            {
                position.Y -= speed;
            }
            if (move == movement.down)
            {
                position.Y += speed;
            }
            if (move == movement.right)
            {
                position.X += speed;
            }
            if (move == movement.left)
            {
                position.X -= speed;
            }

        }
        // returns float that obj should rotate towards
        public virtual float LookTowards(Vector2 currentPos, Vector2 targetPos)
        {
            Vector2 lookDirection = currentPos - targetPos;
            lookDirection.Normalize();

            float rotationInRadians = (float)Math.Atan2((double)lookDirection.Y, (double)lookDirection.X) + MathHelper.PiOver2;

            return rotationInRadians;
        }
        public virtual void SuperMove(Vector2 currentPos)
        {
            MouseState mouseState = Mouse.GetState();
            Vector2 targetPos = new Vector2(mouseState.Position.X, mouseState.Position.Y);

            Vector2 Difference = Vector2.Subtract(currentPos, targetPos);

            Vector2 Direction = Vector2.Normalize(Difference);


            position += Direction * (-4.0f);
        }
        public virtual void Attack(Vector2 shootOrigin)
        {
            MouseState mouseState = Mouse.GetState();
            Vector2 targetPos = new Vector2(mouseState.Position.X, mouseState.Position.Y);

            Vector2 Difference = Vector2.Subtract(shootOrigin, targetPos);

            Vector2 Direction = Vector2.Normalize(Difference);


            position += Direction * (-4.0f);
        }
        public static float ToSingle(double value)
        {
            return (float)value;
        }

        public static int Sign(int value)
        {
            return (value > 0) ? 1 : (value < 0) ? -1 : 0;
        }
    }
}
