﻿using Microsoft.Xna.Framework;
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


        public kolumny()
        {
            this.tekstura = Stale.CONTENT.Load<Texture2D>("Tekstury/kolumny");
            this.Pozycja = new Vector2(420, Stale.RANDOM.Next(-200, 5));
        }

        public void Update()
        {
            this.Pozycja.X -= 2f;
        }

        public void Draw()
        {
            Stale.SPRITEBATCH.Draw(this.tekstura, this.Pozycja, Color.White);
        }
    }
}