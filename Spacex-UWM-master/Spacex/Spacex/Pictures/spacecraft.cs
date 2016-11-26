using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spacex.Pictures
{
    public class spacecraft
    {
        public Texture2D[] Texture;
        public int texture_Position;
        public Vector2 Position;
        public float Rotation;
        public float Yfall;

        public int jump_time = 500;
        public double jump_fall = 0;

        public int animation_time = 100;
        public double animation_fall = 0;
        public int add_Texture = 1;

        public bool destroyed = false;
        public bool jump = true;

        public spacecraft()
        {
            Texture = new Texture2D[3];
            this.Texture[0] = Const.CONTENT.Load<Texture2D>("Texture/spacecraft");
            this.Texture[1] = Const.CONTENT.Load<Texture2D>("Texture/spacecraft1");
            this.Texture[2] = Const.CONTENT.Load<Texture2D>("Texture/spacecraft2");

            this.Position = new Vector2(150, 300);
        }

        public void Update()
        {
            Yfall += 0.2f;

            jump_fall += Const.GAMETIME.ElapsedGameTime.TotalMilliseconds;
            if (jump_fall > jump_time)
            {
                jump = true;
                jump_fall = 0;
            }

            animation_fall += Const.GAMETIME.ElapsedGameTime.TotalMilliseconds;
            if (animation_fall > animation_time)
            {
                this.texture_Position += this.add_Texture;
                if (this.texture_Position == 2 || this.texture_Position == 0)
                    this.add_Texture = this.add_Texture * -1;
                animation_fall = 0;
            }

            if (Const.INPUT.isKeyPressed(Microsoft.Xna.Framework.Input.Keys.Space) && jump)
            {
                Yfall = -5;
            }



            if (Yfall > 0f)
                Rotation = 0.1f;
            else
                Rotation = -0.1f;


            this.Position.Y += Yfall;

            if (this.Position.Y > 500)
            {
                destroyed = true;
            }
        }


        public Rectangle Limit { get { return new Rectangle((int)this.Position.X - 20, (int)this.Position.Y - 20, 40, 40); } }

        public void Draw()
        {
            Const.SPRITEBATCH.Draw(this.Texture[this.texture_Position], this.Position, null, Color.White, this.Rotation, new Vector2(20, 20), 1f, SpriteEffects.None, 0f);

            if (Const.DEBUG)
                Const.SPRITEBATCH.Draw(Const.PIXEL, this.Limit, new Color(1f, 0f, 0f, 0.3f));
        }
    }
}