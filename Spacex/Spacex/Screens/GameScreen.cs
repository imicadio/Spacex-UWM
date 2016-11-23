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
        public GameScreen()
        {

        }

        public override void LoadContent()
        {
            tlo = Stale.CONTENT.Load<Texture2D>("Tekstury/tlo");
            statek = new Obrazki.statek();

            base.LoadContent();
        }

        public override void Update()
        {
            statek.Update();
            base.Update();
        }

        public override void Draw()
        {
            Stale.SPRITEBATCH.Begin();

            Stale.SPRITEBATCH.Draw(this.tlo, Vector2.Zero, Color.White);

            statek.Draw();

            Stale.SPRITEBATCH.End();
            base.Draw();
        }
    }
}