using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spacex.Screens
{
    class GameScreen : Screen
    {
        // GameScreen cały kod gry jest praktycznie umieszczony w tym pliku, "cała logika"

        public Texture2D background;
        public Texture2D floor;
        public Texture2D GameOver;
        public Pictures.spacecraft spacecraft;
        public Pictures.scroll scroll;
        public List<Pictures.column> column;

        public SpriteFont fontBIG;
        public SpriteFont font;
        public int wynik = 0;
        public int wynikEND = 0;

        public int column_time = 2000;
        public double column_passage = 0;

        public bool Game_Over = false;

        public Spacex spacex;

        public GameScreen()
        {

        }

        public override void LoadContent()
        {
            //Wczytanie textur

            background = Const.CONTENT.Load<Texture2D>("Texture/background");
            floor = Const.CONTENT.Load<Texture2D>("Texture/floor");
            font = Const.CONTENT.Load<SpriteFont>("Font/Font");
            fontBIG = Const.CONTENT.Load<SpriteFont>("Font/WynikBIG");
            GameOver = Const.CONTENT.Load<Texture2D>("Texture/GameOver");  


            Restart(); 
            base.LoadContent();
        }

        public void Restart() // Restart, nowe wczytanie
        {
            spacecraft = new Pictures.spacecraft();
            scroll = new Pictures.scroll();
            column = new List<Pictures.column>();
            column.Add(new Pictures.column());
            wynik = 0;
        }

        public override void Update()
        {
            // poniżej został umieszczony kod który odpowiada za wynik, zniszczenie statku, pozycje kolumn
            Create_Column(); 
            if (!spacecraft.destroyed)
            {
                for (int i = column.Count - 1; i > -1; i--) // kolumny 
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
                            // statek przeszedł to i wynik się zwiększa przez przejście przez kolumnę
                        }

                        if (spacecraft.Limit.Intersects(column[i].Upper_Limit) || spacecraft.Limit.Intersects(column[i].Lower_Limit) || spacecraft.Limit.Intersects(scroll.Upper_Limit))
                        {
                            // statek zniszczony bo dotknął kolumny albo dolnej i górnej granicy
                            spacecraft.destroyed = true; 
                        }
                    }
                }
                spacecraft.Update();
                scroll.Update();
            }

            // wciśnięcie R powoduje restart gry
            if (spacecraft.destroyed && Const.INPUT.isKeyPressed(Microsoft.Xna.Framework.Input.Keys.R))            
                this.Restart();

            // wciśnięcie ESC powoduje zakończenie gry
            else if (spacecraft.destroyed && Const.INPUT.isKeyPressed(Microsoft.Xna.Framework.Input.Keys.Escape))            
                spacex.Quit();
            

            base.Update();
        }
        

        public void Create_Column() // tworzy kolumny
        {
            column_passage += Const.GAMETIME.ElapsedGameTime.TotalMilliseconds;
            if (column_passage > column_time)
            {
                column.Add(new Pictures.column());
                column_passage = 0;
            }
        }

        public override void Draw() // w metodzie Draw() umieszczone są tła, statki, wynik czy scroll
        {
            Const.SPRITEBATCH.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearWrap, null, null); // scroll pasek, żeby się cały czas przewijał

            Const.SPRITEBATCH.Draw(this.background, Vector2.Zero, Color.White); // tło

            foreach (var item in column) // kolumny
            {
                item.Draw();
            }

            Const.SPRITEBATCH.Draw(this.floor, new Vector2(0, 529), Color.White);
            scroll.Draw();
            spacecraft.Draw();

            // napis na górze "wynik"
            Const.SPRITEBATCH.DrawString(this.font, "Wynik: " + this.wynik.ToString(), new Vector2(10, 10), Color.Yellow);

            wynikEND = wynik;

            // w tym kodzie pokaże się nam czerwone tło i GAME OVER jeśli statek zniszczony
            if (spacecraft.destroyed) 
            {
                Const.SPRITEBATCH.Draw(Const.PIXEL, new Rectangle(0, 0, Const.GAME_WIDTH, Const.GAME_HEIGHT), new Color(1f, 0f, 0f, 0.3f));
                Const.SPRITEBATCH.Draw(this.GameOver, new Vector2(0, 80), Color.White);
                Const.SPRITEBATCH.DrawString(this.fontBIG, "Wynik: " + this.wynikEND.ToString(), new Vector2(99, 65), Color.LawnGreen);
            }


            Const.SPRITEBATCH.End();
            base.Draw();
        }
    }
}