using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DRush
{
    public class Flame : GameObject
    {
        public bool isVisible;
        public Vector2 flameVelocity; // Ускорение - или коофициент двиения

        public Flame(Texture2D inputTexture, Vector2 inDirection) // Конструктор
        {
            objectTexture = inputTexture;
            //objectCoordinates = inputRectangle;
            newDirection = inDirection;
            isVisible = false;
        }



        public override void Update() // Метод обновления
        {

            
        }

        public void Draw(SpriteBatch spriteBatch) // Переписали метод отрисовки
        {
            spriteBatch.Draw(objectTexture, newDirection, null, Color.White, angle, originalDirection, 1f, SpriteEffects.None, 0); 
        }


    }
}
