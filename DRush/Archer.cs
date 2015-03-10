using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DRush
{
    class Archer : GameObject
    {

        public Archer(Texture2D inputTexture, Rectangle inputRectangle) // Конструктор
        {
            objectTexture = inputTexture;
            objectCoordinates = inputRectangle;
        }
    }
}
