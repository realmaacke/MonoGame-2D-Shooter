using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter
{
    public class Enemy : Entity
    {
        Texture2D Enemy_texture;
        Player player;

        public Enemy(Texture2D texture, Player player)
        {

            this.Enemy_texture = texture;
            this.player = player;
            RandomInstantiation();
        }

        public override void RandomInstantiation()
        {
            base.RandomInstantiation();
        }


        public override void Initialize()
        {
            base.Initialize();
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Move(movement move)
        {
            base.Move(move);
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, Enemy_texture.Width, Enemy_texture.Height);

            spriteBatch.Draw(Enemy_texture, position, sourceRectangle, Color.White);
        }


    }
}
