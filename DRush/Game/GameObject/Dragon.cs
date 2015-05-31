﻿using System;
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

        public Dragon(Texture2D inputTexture, Rectangle inputRectangle, Vector2 newDirection) // Конструктор
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

        public void SetToStart()
        { // Обнуление координат

            objectCoordinates.X = (coonfig["widthOfScreen"] / 2) - 90;
            objectCoordinates.Y = (coonfig["heightOfScreen"] / 2) - 50;

            // Обнуление вектора

        }

        public override void Update() 
        {

            objectCoordinates = new Rectangle((int)newDirection.X, (int)newDirection.Y, objectTexture.Width, objectTexture.Height);

            // Описание движения
            if ( Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S))
            {
                objectCoordinates.Y += moveCooficient;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W) )
            {
                objectCoordinates.Y -= moveCooficient;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A))
            {
                objectCoordinates.X -= moveCooficient;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                objectCoordinates.X += moveCooficient;
            }

            // Описание поворота
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                angle += 0.1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                angle -= 0.1f;
            }

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

         
        public void Draw(SpriteBatch spriteBatch) // Переписали метод отрисовки
        {
            spriteBatch.Draw(objectTexture, originalDirection, null, Color.White, angle, newDirection, 1f, SpriteEffects.None, 0); // Рисуем его под углом ДОДЕЛАТЬ
        }
        
        public void Shoot (ref Rectangle rectangle) {
            rectangle.X = objectCoordinates.X;
            rectangle.Y = objectCoordinates.Y;        
        }

    }
}
