using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Spacex
{
    public class Spacex : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Screens.Screen currentScreen;

        public void Quit()
        {
            this.Exit();
        }

        public Spacex()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Const.CONTENT = Content;
            Const.GRAPHICSDEVICE = GraphicsDevice;


            this.graphics.PreferredBackBufferHeight = Const.GAME_HEIGHT;
            this.graphics.PreferredBackBufferWidth = Const.GAME_WIDTH;
            this.Window.Title = Const.TITLE;

            this.graphics.ApplyChanges();

            Manager.InputManager input = new Manager.InputManager();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Const.SPRITEBATCH = spriteBatch;
            Const.PIXEL = Content.Load<Texture2D>("Texture/pixel");

            currentScreen = new Screens.GameScreen();

            currentScreen.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            Const.GAMETIME = gameTime;
            Const.INPUT.Update();

            // try i catch dodane, ponieważ wtedy mogę używać R do retatu i ESC by zamknąć grę
            try
            {
                currentScreen.Update();
            }
            catch
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Escape)) this.Exit();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            currentScreen.Draw();

            base.Draw(gameTime);
        }
    }
}