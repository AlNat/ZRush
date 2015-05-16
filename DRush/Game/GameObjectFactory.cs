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

        // Впихнуть невпихуемое !!!

        // класс, только и делающий, что возвращает нужный нам объект
        // 3 аргумента у фабрики, первый - сам выбор из фабрики. Два других - стандартные конструкторы
        // Разумеется, это нифига не паттерн и даже не фабрика, но все-же.

        // Но Who cares - это всего лишь для примера

        public GameObject obj;

        public GameObjectFactory()
        {// Конструктор

        }

        public GameObject Factory (String name, Texture2D inputTexture, Rectangle inputRectangle)
        { 
             //GameObject obj = null;

            if (name.Equals("dragon"))
            {
                obj = new Dragon(inputTexture, inputRectangle);
            }
            else if (name.Equals("flame"))
            {
                obj = new Flame(inputTexture, inputRectangle);
            }

            return obj;
        }

    }
}
