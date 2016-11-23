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
        public Obrazki.statek statek;
        public Obrazki.scroll scroll;
        public List<Obrazki.kolumny> kolumny;

        public GameScreen()
        {

        }

        public override void LoadContent()
        {
            tlo = Stale.CONTENT.Load<Texture2D>("Tekstury/tlo");
            statek = new Obrazki.statek();
            scroll = new Obrazki.scroll();
            kolumny = new List<Obrazki.kolumny>();
            kolumny.Add(new Obrazki.kolumny());


            base.LoadContent();
        }

        public override void Update()
        {
            foreach (var item in kolumny)
            {
                item.Update();
            }

            statek.Update();
            scroll.Update();
            base.Update();
        }

        public override void Draw()
        {
            Stale.SPRITEBATCH.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearWrap, null, null);

            Stale.SPRITEBATCH.Draw(this.tlo, Vector2.Zero, Color.White);
            scroll.Draw();

            foreach (var item in kolumny)
            {
                item.Draw();
            }

            statek.Draw();


            Stale.SPRITEBATCH.End();
            base.Draw();
        }
    }
}