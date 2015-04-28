using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DRush
{
    public class Dragon : GameObject
    {

        Settings settings;
        Dictionary<string, int> coonfig;

        public Dragon(Texture2D inputTexture, Rectangle inputRectangle) // Конструктор
        {
            settings = new Settings();
            settings.GetData (out coonfig); 

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
                objectCoordinates.X = coonfig["widthOfScreen"] - 20; 
            }
            if (objectCoordinates.X > coonfig["widthOfScreen"] - 20)
            {
                objectCoordinates.X = -10; 
            }
            if (objectCoordinates.Y < -20)
            {
                objectCoordinates.Y = coonfig["heightOfScreen"] - 10;
            }
            if (objectCoordinates.Y > coonfig["heightOfScreen"] - 10)
            {
                objectCoordinates.Y = -5;
            }

            // Создание выстрела
            if ( Keyboard.GetState().IsKeyDown(Keys.Space) )
            {
                //Shoot();        
            }

        }

        public void Shoot (ref Rectangle rectangle) {
            rectangle.X = objectCoordinates.X;
            rectangle.Y = objectCoordinates.Y;        
        }

    }
}
