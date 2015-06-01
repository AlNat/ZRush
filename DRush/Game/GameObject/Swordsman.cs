using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DRush
{
    public class Swordsman : GameObject
    {

        public bool isVisible;

        public Swordsman(Texture2D inputTexture, Rectangle inputRectangle) // Конструктор
        {
            objectTexture = inputTexture;
            objectCoordinates = inputRectangle;
            isVisible = true;
            points = 10;
        }

        public int HowMuchPoint()
        {
            return points;
        }

        public void SetToStart(int rX, int rY)
        {
            objectCoordinates.X = rX;
            objectCoordinates.Y = rY;
        }
    }
}
