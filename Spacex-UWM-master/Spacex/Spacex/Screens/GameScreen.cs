using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spacex.Screens
{
    class GameScreen : Screen
    {
        public Texture2D background;
        public Texture2D floor;
        public Texture2D GameOver;
        public Pictures.spacecraft spacecraft;
        public Pictures.scroll scroll;
        public List<Pictures.column> column;

        public SpriteFont font;
        public int wynik = 0;

        public int column_time = 2000;
        public double column_passage = 0;

        public bool Game_Over = false;

        public GameScreen()
        {

        }

        public override void LoadContent()
        {
            background = Const.CONTENT.Load<Texture2D>("Texture/background");
            floor = Const.CONTENT.Load<Texture2D>("Texture/floor");
            font = Const.CONTENT.Load<SpriteFont>("Font/Font");
            GameOver = Const.CONTENT.Load<Texture2D>("Texture/GameOver");


            Restart();
            base.LoadContent();
        }

        public void Restart()
        {
            spacecraft = new Pictures.spacecraft();
            scroll = new Pictures.scroll();
            column = new List<Pictures.column>();
            column.Add(new Pictures.column());
            wynik = 0;
        }

        public override void Update()
        {
            Create_Column();
            if (!spacecraft.destroyed)
            {
                for (int i = column.Count - 1; i > -1; i--)
                {
                    if (column[i].Position.X < -50)
                        column.RemoveAt(i);
                    else
                    {
                        column[i].Update();
                        if (!column[i].wynik && spacecraft.Position.X > column[i].Position.X + 50)
                        {
                            column[i].wynik = true;
                            wynik++;
                        }

                        if (spacecraft.Limit.Intersects(column[i].Upper_Limit) || spacecraft.Limit.Intersects(column[i].Lower_Limit) || spacecraft.Limit.Intersects(scroll.Upper_Limit))
                        {
                            spacecraft.destroyed = true;
                        }
                    }
                }
                spacecraft.Update();
                scroll.Update();
            }

            if (spacecraft.destroyed && Const.INPUT.isKeyPressed(Microsoft.Xna.Framework.Input.Keys.R))
            {
                this.Restart();
            }

            base.Update();
        }

        public void Create_Column()
        {
            column_passage += Const.GAMETIME.ElapsedGameTime.TotalMilliseconds;
            if (column_passage > column_time)
            {
                column.Add(new Pictures.column());
                column_passage = 0;
            }
        }

        public override void Draw()
        {
            Const.SPRITEBATCH.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearWrap, null, null);

            Const.SPRITEBATCH.Draw(this.background, Vector2.Zero, Color.White);

            foreach (var item in column)
            {
                item.Draw();
            }

            Const.SPRITEBATCH.Draw(this.floor, new Vector2(0, 529), Color.White);
            scroll.Draw();
            spacecraft.Draw();

            Const.SPRITEBATCH.DrawString(this.font, "Wynik: " + this.wynik.ToString(), new Vector2(10, 10), Color.Yellow);

            if (spacecraft.destroyed)
            {
                Const.SPRITEBATCH.Draw(Const.PIXEL, new Rectangle(0, 0, Const.GAME_WIDTH, Const.GAME_HEIGHT), new Color(1f, 0f, 0f, 0.3f));
                Const.SPRITEBATCH.Draw(this.GameOver, new Vector2(0, 80), Color.White);
            }


            Const.SPRITEBATCH.End();
            base.Draw();
        }
    }
}