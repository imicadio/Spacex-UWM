using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spacex.Obrazki
{
    public class scroll
    {
        public Vector2 Pozycja;
        public Texture2D tekstura;

        public int animacja_czas = 10;
        public double animacja_spadanie = 0;
        public int transferX = 0;

        public scroll()
        {
            this.Pozycja = new Vector2(0, 529);
            this.tekstura = Stale.CONTENT.Load<Texture2D>("Tekstury/scroll");
        }

        public void Update()
        {
            animacja_spadanie += Stale.GAMETIME.ElapsedGameTime.TotalMilliseconds;
            if (animacja_spadanie > animacja_czas)
            {
                this.transferX++;
                if (transferX > 12)
                    transferX = 0;
                animacja_spadanie = 0;
            }
        }

        public void Draw()
        {
            Stale.SPRITEBATCH.Draw(this.tekstura, this.Pozycja, new Rectangle(this.transferX, 0, Stale.GRA_SZEROKOSC, 12), Color.White);
        }
    }
}