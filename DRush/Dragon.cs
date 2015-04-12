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

        Settings settings;
        int []coonf;

        public Dragon(Texture2D inputTexture, Rectangle inputRectangle) // Конструктор
        {
            settings = new Settings();
            coonf = new int[6];
            settings.GetData(ref coonf); 

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

            // Описание поворота

            // Границы экрана
            if (objectCoordinates.X < -20)
            {
                objectCoordinates.X = coonf[0] - 20; 
            }
            if (objectCoordinates.X > coonf[0] - 20)
            {
                objectCoordinates.X = 0; 
            }
            if (objectCoordinates.Y < -20)
            {
                objectCoordinates.Y = coonf[1] - 10;
            }
            if (objectCoordinates.Y > coonf[1] - 10)
            {
                objectCoordinates.Y = 0;
            }

            // Создание выстрела
            if ( Keyboard.GetState().IsKeyDown(Keys.Space) )
            { 
                
            }

        }

    }
}
