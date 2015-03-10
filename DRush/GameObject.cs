using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DRush
{
    class GameObject // Класс для обозначения некого примитива (в 20 кб, ага :) ) - от него происходят все остальные объекты
    {

        // СЛОВАРЬ DICTIONAY, МУВ ОБДЖЕТ - to think


        // Переменные описания объекта
        // DISCLAMER = Я конечно понимаю, что не стоит делать их public, но очень лень геттеры\сеттеры делать.
        // Если есть удобный способ снаследовать их и изменять напрямую, то будет отлично.
        public Texture2D objectTexture; // Текстура
        public Rectangle objectCoordinates; // Прямоугольник тестуры - координаты
        public int angle; // Угол поворота
        public bool staticSetting; // Статичен ли объект или нет
        public int live; // Характеристика жизнь
        public int level; // Уровень
        public int exp; // Кол-во очков опыта
        public int points; // Кол-во очков
        public int hardCooficient; // Коофицент сложности - СЛОЖНОСТЬ
        public int moveCooficient = 5; // Коофициент движения - для больших экранов и тд
        public int damage; // Урон

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
            if ( live > 0 ) // Если объект жив
                return true;
            else
                return false;
        }

        public bool IsStatic()
        {
            return staticSetting;
        } 

        public int HowMuchLive() // Вернули кол-во жизни - для HealthBar
        {
            return live;
        }


    }
}
