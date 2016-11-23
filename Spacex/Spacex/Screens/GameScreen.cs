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
        public Texture2D tlo;
        public Texture2D floor;
        public Obrazki.statek statek;
        public Obrazki.scroll scroll;
        public List<Obrazki.kolumny> kolumny;

        public SpriteFont font;
        public int wynik = 0;

        public int kolumny_Czas = 2000;
        public double kolumny_Mijanie = 0;

        public bool Koniec_Gry = false;

        public GameScreen()
        {

        }

        public override void LoadContent()
        {
            tlo = Stale.CONTENT.Load<Texture2D>("Tekstury/tlo");
            floor = Stale.CONTENT.Load<Texture2D>("Tekstury/floor");
            font = Stale.CONTENT.Load<SpriteFont>("Font/Font");


            Restart();
            base.LoadContent();
        }

        public void Restart()
        {
            statek = new Obrazki.statek();
            scroll = new Obrazki.scroll();
            kolumny = new List<Obrazki.kolumny>();
            kolumny.Add(new Obrazki.kolumny());
            wynik = 0;
        }

        public override void Update()
        {
            kolumny_Tworzenie();
            if (!statek.zniszczony)
            {
                for (int i = kolumny.Count - 1; i > -1; i--)
                {
                    if (kolumny[i].Pozycja.X < -50)
                        kolumny.RemoveAt(i);
                    else
                    {
                        kolumny[i].Update();
                        if (!kolumny[i].wynik && statek.Pozycja.X > kolumny[i].Pozycja.X + 50)
                        {
                            kolumny[i].wynik = true;
                            wynik++;
                        }

                        if (statek.Granica.Intersects(kolumny[i].Gorna_Granica) || statek.Granica.Intersects(kolumny[i].Dolna_Granica))
                        {
                            statek.zniszczony = true;
                        }
                    }
                }
                statek.Update();
                scroll.Update();
            }

            if (statek.zniszczony && Stale.INPUT.isKeyPressed(Microsoft.Xna.Framework.Input.Keys.R))
            {
                this.Restart();
            }

            base.Update();
        }

        public void kolumny_Tworzenie()
        {
            kolumny_Mijanie += Stale.GAMETIME.ElapsedGameTime.TotalMilliseconds;
            if (kolumny_Mijanie > kolumny_Czas)
            {
                kolumny.Add(new Obrazki.kolumny());
                kolumny_Mijanie = 0;
            }
        }

        public override void Draw()
        {
            Stale.SPRITEBATCH.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearWrap, null, null);

            Stale.SPRITEBATCH.Draw(this.tlo, Vector2.Zero, Color.White);

            foreach (var item in kolumny)
            {
                item.Draw();
            }

            Stale.SPRITEBATCH.Draw(this.floor, new Vector2(0, 529), Color.White);
            scroll.Draw();
            statek.Draw();

            Stale.SPRITEBATCH.DrawString(this.font, "Wynik: " + this.wynik.ToString(), new Vector2(10, 10), Color.Yellow);


            Stale.SPRITEBATCH.End();
            base.Draw();
        }
    }
}