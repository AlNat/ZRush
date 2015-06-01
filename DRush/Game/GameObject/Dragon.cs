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
        Vector2 saveDirection;

        public Dragon(Texture2D inputTexture,  Vector2 inDirection) // Конструктор
        {
            settings = new Settings();
            settings.GetData (out coonfig); 

            // Технические переменные:
            objectTexture = inputTexture;
            originalDirection = inDirection;
            saveDirection = inDirection; // Это для новой игры

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

            originalDirection.X = (coonfig["widthOfScreen"] / 2) - 90;
            originalDirection.Y = (coonfig["heightOfScreen"] / 2) - 50;

        }

        public override void Update() 
        {

            // Описание движения
            if ( Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S))
            {
                originalDirection.Y += moveCooficient;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W) )
            {
                originalDirection.Y -= moveCooficient;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A))
            {
                originalDirection.X -= moveCooficient;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                originalDirection.X += moveCooficient;
            }

            // Описание поворота
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                angle += 0.04f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                angle -= 0.04f;
            }

            // Границы экрана
            if (originalDirection.X < -20)
            {
                originalDirection.X = coonfig["widthOfScreen"] - 20; 
            }
            if (originalDirection.X > coonfig["widthOfScreen"] - 20)
            {
                originalDirection.X = -10; 
            }
            if (originalDirection.Y < -20)
            {
                originalDirection.Y = coonfig["heightOfScreen"] - 10;
            }
            if (originalDirection.Y > coonfig["heightOfScreen"] - 10)
            {
                originalDirection.Y = -5;
            }

            // Создание выстрела
            if ( Keyboard.GetState().IsKeyDown(Keys.Space) )
            {
                //Shoot();        
            }

        }

         
        public void Draw (SpriteBatch spriteBatch) // Переписали метод отрисовки
        {
            spriteBatch.Draw(objectTexture, originalDirection, null, Color.White, angle, newDirection, 1f, SpriteEffects.None, 0); // Рисуем его под углом ДОДЕЛАТЬ
        }
        
        public void Shoot (ref Rectangle rectangle) {
            rectangle.X = objectCoordinates.X;
            rectangle.Y = objectCoordinates.Y;        
        }

        public void KillEnemy(int expa)
        {
            // Принимает кол-во очков опыта, которые надо добавить
            points += expa;
        }

    }
}
