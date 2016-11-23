using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spacex.Obrazki
{
    public class kolumny
    {
        public Texture2D tekstura;
        public Vector2 Pozycja;

        public bool wynik = false;

        public kolumny()
        {
            this.tekstura = Stale.CONTENT.Load<Texture2D>("Tekstury/kolumny");
            this.Pozycja = new Vector2(420, Stale.RANDOM.Next(-200, 5));
        }

        public void Update()
        {
            this.Pozycja.X -= 2f;
        }

        public Rectangle Gorna_Granica { get { return new Rectangle((int)this.Pozycja.X, (int)this.Pozycja.Y, 55, 308); } }
        public Rectangle Dolna_Granica { get { return new Rectangle((int)this.Pozycja.X, (int)this.Pozycja.Y + 460, 55, 340); } }

        public void Draw()
        {
            Stale.SPRITEBATCH.Draw(this.tekstura, this.Pozycja, Color.White);

            if (Stale.DEBUG)
                Stale.SPRITEBATCH.Draw(Stale.PIXEL, this.Gorna_Granica, new Color(1f, 0f, 0f, 0.3f));
            if (Stale.DEBUG)
                Stale.SPRITEBATCH.Draw(Stale.PIXEL, this.Dolna_Granica, new Color(1f, 0f, 0f, 0.3f));
        }
    }
}