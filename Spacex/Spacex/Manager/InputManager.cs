﻿using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spacex.Manager
{
    public class InputManager
    {
        private KeyboardState _oldKS;
        private KeyboardState _KS;

        public InputManager()
        {
            Const.INPUT = this;
        }

        public void Update()
        {
            if (_KS != null)
                _oldKS = _KS;

            _KS = Keyboard.GetState();
        }

        public bool isKeyPressed(Keys k)
        {
            return (_oldKS.IsKeyUp(k) && _KS.IsKeyDown(k));
        }

        public bool isKeyRelease(Keys k)
        {
            return (_oldKS.IsKeyUp(k) && _KS.IsKeyDown(k));
        }

        public KeyboardState currentState()
        {
            return this._KS;
        }
    }
}