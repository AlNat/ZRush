using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DRush
{
    class Dragon : GameObject
    {

        public Dragon(Texture2D inputTexture, Rectangle inputRectangle) // Конструктор
        {
            objectTexture = inputTexture;
            objectCoordinates = inputRectangle;
        }

        public override void Update() 
        { 
            // Описание двиения
            if ( Keyboard.GetState().IsKeyDown(Keys.Down) )
            {
                objectCoordinates.Y += 5;
            }
            if ( Keyboard.GetState().IsKeyDown(Keys.Up) )
            {
                objectCoordinates.Y -= 5;
            }
            if ( Keyboard.GetState().IsKeyDown(Keys.Left) )
            {
                objectCoordinates.X -= 5;
            }
            if ( Keyboard.GetState().IsKeyDown(Keys.Right) )
            {
                objectCoordinates.X += 5;
            }
            if ( Keyboard.GetState().IsKeyDown(Keys.Space) )
            { 
                
            }
            if ( Keyboard.GetState().IsKeyDown(Keys.Escape) )
            {

            }

        }

    }
}
