﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spacex.Obrazki
{
    class statek
    {
        public Texture2D[] Tekstura;
        public int teksturaPozycja;
        public Vector2 Pozycja;
        public float Rotation;
        public float YSpadanie;

        public int skok_czas = 500;
        public double skok_spadanie = 0;

        public bool czy_skok = true;


        public statek()
        {
            Tekstura = new Texture2D[3];
            this.Tekstura[0] = Stale.CONTENT.Load<Texture2D>("Tekstury/statek");
            this.Tekstura[1] = Stale.CONTENT.Load<Texture2D>("Tekstury/statek1");
            this.Tekstura[2] = Stale.CONTENT.Load<Texture2D>("Tekstury/statek2");

            this.Pozycja = new Vector2(150, 300);
        }

        public void Update()
        {
            YSpadanie += 0.2f;

            skok_spadanie += Stale.GAMETIME.ElapsedGameTime.TotalMilliseconds;
            if (skok_spadanie > skok_czas)
            {
                czy_skok = true;
                skok_spadanie = 0;
            }

            if (Stale.INPUT.isKeyPressed(Microsoft.Xna.Framework.Input.Keys.Space) && czy_skok)
            {
                YSpadanie = -5;
            }

            if (YSpadanie > 0f)
                Rotation = 0.5f;
            else
                Rotation = -0.5f;

            this.Pozycja.Y += YSpadanie;

        }

        public void Draw()
        {
            Stale.SPRITEBATCH.Draw(this.Tekstura[this.teksturaPozycja], this.Pozycja, null, Color.White, this.Rotation, new Vector2(20, 20), 1f, SpriteEffects.None, 0f);
        }
    }
}