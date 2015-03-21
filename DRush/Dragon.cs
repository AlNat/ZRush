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
            // Технические переменные:
            objectTexture = inputTexture;
            objectCoordinates = inputRectangle;
            angle = 0; // Угол поворота
            staticSetting = false; // Статичен ли объект или нет

            // Перемнные персонажа:
            level = 1; // Уровень
            exp = 0; // Кол-во очков опыта
            points = 0; // Кол-во очков

            // Переменные игровой механики и баланса:
            hardCooficient = 1; // Коофиуиент слоности - ЗАДАВАТЬ ЧЕРЕЗ НАСТРОЙКИ
            live = 100 / hardCooficient; // Характеристика жизнь
            damage = 100 / hardCooficient; // Характеристика урона

        }

        public override void Update() 
        { 
            // Описание движения
            if ( Keyboard.GetState().IsKeyDown(Keys.Down) )
            {
                objectCoordinates.Y += moveCooficient;
            }
            if ( Keyboard.GetState().IsKeyDown(Keys.Up) )
            {
                objectCoordinates.Y -= moveCooficient;
            }
            if ( Keyboard.GetState().IsKeyDown(Keys.Left) )
            {
                objectCoordinates.X -= moveCooficient;
            }
            if ( Keyboard.GetState().IsKeyDown(Keys.Right) )
            {
                objectCoordinates.X += moveCooficient;
            }

            // Границы экрана - у нас типа шар
            if (objectCoordinates.X < -5)
            {
                objectCoordinates.X = 1580; // В будущем пойдет читать из конфига!
            }
            if (objectCoordinates.X > 1600)
            {
                objectCoordinates.X = 0; // В будущем пойдет читать из конфига!
            }
            if (objectCoordinates.Y < -10)
            {
                objectCoordinates.Y = 900; // В будущем пойдет читать из конфига!
            }
            if (objectCoordinates.Y > 910)
            {
                objectCoordinates.Y = 0; // В будущем пойдет читать из конфига!
            }

            // Создание выстрела
            if ( Keyboard.GetState().IsKeyDown(Keys.Space) )
            { 
                
            }

        }

    }
}
