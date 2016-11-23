using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spacex
{
    public class Stale
    {
        public static int GRA_SZEROKOSC = 400;
        public static int GRA_WYSOKOSC = 600;
        public static string GRA_TYTUL = "Spacex";

        public static GameTime GAMETIME;
        public static SpriteBatch SPRITEBATCH;
        public static ContentManager CONTENT;
        public static GraphicsDevice GRAPHICSDEVICE;
        public static Texture2D PIXEL;

        public static Menedzer.InputManager INPUT;
    }
}