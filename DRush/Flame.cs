using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DRush
{
    class Flame : GameObject
    {

        private int damage = 100; // Пусть пока будет 100 дамага

        public Flame(Texture2D inputTexture, Rectangle inputRectangle) // Конструктор
        {
            objectTexture = inputTexture;
            objectCoordinates = inputRectangle;
        }


    }
}
