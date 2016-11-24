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
        public Vector2 Pozycja1;
        public Texture2D tekstura;

        public int animacja_czas = 10;
        public double animacja_spadanie = 0;
        public int transferX = 0;

        public scroll()
        {
            this.Pozycja = new Vector2(0, 529);
            this.Pozycja1 = new Vector2(0, 0);
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

        public Rectangle Granica_GORA { get { return new Rectangle((int)this.Pozycja.X, (int)this.Pozycja.Y-528, Stale.GRA_SZEROKOSC, 10); } }

        public void Draw()
        {
            Stale.SPRITEBATCH.Draw(this.tekstura, this.Pozycja, new Rectangle(this.transferX, 0, Stale.GRA_SZEROKOSC, 12), Color.White);

            Stale.SPRITEBATCH.Draw(this.tekstura, this.Pozycja1, new Rectangle(this.transferX, 0, Stale.GRA_SZEROKOSC, 12), Color.White);
            
            if (Stale.DEBUG)
                Stale.SPRITEBATCH.Draw(Stale.PIXEL, this.Granica_GORA, new Color(1f, 0f, 0f, 0.3f));
        }
    }
}