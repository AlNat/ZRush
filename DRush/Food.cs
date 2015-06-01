using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DRush
{
    class Food : GameObject
    {
        public bool isVisible;
        public Food(Texture2D inputTexture, Rectangle inputRectangle) // Конструктор
        {
            objectTexture = inputTexture;
            objectCoordinates = inputRectangle;

            points = 10;
        }

        public int HowMuchPoint()
        {
            return points;
        }



    }

}
