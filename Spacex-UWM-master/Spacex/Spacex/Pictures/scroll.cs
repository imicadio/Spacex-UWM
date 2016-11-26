using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spacex.Pictures
{
    public class scroll
    {
        public Vector2 Position;
        public Vector2 Position1;
        public Texture2D texture;

        public int animation_time = 10;
        public double animation_lower = 0;
        public int transferX = 0;

        public scroll()
        {
            this.Position = new Vector2(0, 529);
            this.Position1 = new Vector2(0, 0);
            this.texture = Const.CONTENT.Load<Texture2D>("Texture/scroll");
        }

        public void Update()
        {
            animation_lower += Const.GAMETIME.ElapsedGameTime.TotalMilliseconds;
            if (animation_lower > animation_time)
            {
                this.transferX++;
                if (transferX > 12)
                    transferX = 0;
                animation_lower = 0;
            }
        }

        public Rectangle Upper_Limit { get { return new Rectangle((int)this.Position.X, (int)this.Position.Y-528, Const.GAME_WIDTH, 10); } }

        public void Draw()
        {
            Const.SPRITEBATCH.Draw(this.texture, this.Position, new Rectangle(this.transferX, 0, Const.GAME_WIDTH, 12), Color.White);

            Const.SPRITEBATCH.Draw(this.texture, this.Position1, new Rectangle(this.transferX, 0, Const.GAME_WIDTH, 12), Color.White);
            
            if (Const.DEBUG)
                Const.SPRITEBATCH.Draw(Const.PIXEL, this.Upper_Limit, new Color(1f, 0f, 0f, 0.3f));
        }
    }
}