using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace DRush
{
    public class GameObjectFactory
    {
        /// Реализация паттерна Фабрика

        // Впихнуть невпихуемое !!!
        // Разумеется, это нифига не паттерн и даже не фабрика, но все-же.
        // Но Who cares - это всего лишь для примера

        private GameObject obj;

        public GameObject Factory (String name, Texture2D inputTexture, Rectangle inputRectangle)
        { 
            /// Конструктор
            /// Принимает строку с именем, тестуру и прямоугольник координат
            /// Возвращает созданный объект класса GameObject


            if (name.Equals("dragon"))
            {
                obj = new Dragon(inputTexture, inputRectangle, new Vector2(200, 200));
            }
            else if (name.Equals("flame"))
            {
                obj = new Flame(inputTexture, inputRectangle);
            }

            return obj;
        }

    }
}
