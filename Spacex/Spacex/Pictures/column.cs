using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spacex.Pictures
{
    public class column
    {
        public Texture2D texture;
        public Vector2 Position;

        public bool wynik = false;

        public column()
        {
            this.texture = Const.CONTENT.Load<Texture2D>("Texture/column"); // wczytanie kolumn
            this.Position = new Vector2(420, Const.RANDOM.Next(-200, 5)); // ustawienie randomowo kolumn
        }

        public void Update()
        {
            this.Position.X -= 2f; // pozycja odległości od siebie
        }

        // poniższy kod to granice kolumn, jeśli statek je dotknie ulega zniszczeniu i koniec gry
        public Rectangle Upper_Limit { get { return new Rectangle((int)this.Position.X, (int)this.Position.Y, 55, 308); } }
        public Rectangle Lower_Limit { get { return new Rectangle((int)this.Position.X, (int)this.Position.Y + 460, 55, 340); } }

        public void Draw()
        {
            Const.SPRITEBATCH.Draw(this.texture, this.Position, Color.White);

            if (Const.DEBUG) // debug umieszczone, ponieważ wtedy nie widać koloru granic
                Const.SPRITEBATCH.Draw(Const.PIXEL, this.Upper_Limit, new Color(1f, 0f, 0f, 0.3f));
            if (Const.DEBUG)
                Const.SPRITEBATCH.Draw(Const.PIXEL, this.Lower_Limit, new Color(1f, 0f, 0f, 0.3f));
        }
    }
}