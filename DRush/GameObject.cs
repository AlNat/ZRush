using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DRush
{
    class GameObject
    {

        // СЛОВАРЬ DICTIONAY, МУВ ОБДЖЕТ 
        public Texture2D objectTexture; // Текстура
        public Rectangle objectCoordinates; // Прямоугольник тестуры - координаты
        public int angle; // Угол поворота

        private int live; // Характеристика персонажа - жизнь
        private int level; // Уровень
        private int exp; // Кол-во опыта

        public virtual void Update() // Виртуальный метод
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        { // Функция рисования
            spriteBatch.Draw(objectTexture, objectCoordinates, Color.White);
        }

        public bool IsCollapse(GameObject inputGameObject)
        {
            if (inputGameObject.objectCoordinates.Intersects (objectCoordinates)) //Если прямоугольники координат пересеклись 
                return true;
            else
                return false;
        }

        public bool IsAlive ()
        {
            if ( live > 0 ) 
                return true;
            else
                return false;
        }

        public int HowMuchLive()
        {
            return live;
        }


    }
}
