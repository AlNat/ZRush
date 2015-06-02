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


        public bool shootSignal;
        Settings settings;
        Dictionary<string, int> coonfig;
        
        public Dragon(Texture2D inputTexture,  Vector2 inDirection) // Конструктор
        {
            settings = new Settings();
            settings.GetData (out coonfig); 

            // Технические переменные:
            objectTexture = inputTexture;
            originalDirection = inDirection;

            angle = 0; // Угол поворота
            staticSetting = false; // Статичен ли объект или нет
            shootSignal = false;

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

        public void Sett (int x, int y)
        {
            originalDirection.X = x;
            originalDirection.Y = y;
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
                angle += 0.06f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                angle -= 0.06f;
            }

            // Границы экрана
            if (originalDirection.X < -40)
            {
                originalDirection.X = coonfig["widthOfScreen"] - 20; 
            }
            if (originalDirection.X > coonfig["widthOfScreen"] - 20)
            {
                originalDirection.X = -20; 
            }
            if (originalDirection.Y < -40)
            {
                originalDirection.Y = coonfig["heightOfScreen"] - 20;
            }
            if (originalDirection.Y > coonfig["heightOfScreen"] - 20)
            {
                originalDirection.Y = -20;
            }

            // Создание выстрела
            if ( Keyboard.GetState().IsKeyDown(Keys.Space) )
            {
                shootSignal = true;     
            }

        }

         
        public void Draw (SpriteBatch spriteBatch) // Переписали метод отрисовки
        {
            spriteBatch.Draw(objectTexture, originalDirection, null, Color.White, angle, newDirection, 1f, SpriteEffects.None, 0); // Рисуем его под углом ДОДЕЛАТЬ
        }
        
        public void Shoot (ref Flame flame) 
        { // При выстреле описали где выстрелели, напрвление и отдали наружу

            shootSignal = false;
            flame.isVisible = true;
            // ХЗ почему тут не работает - оставлю на доделать
            // Скажем что драконы, даже если бы существовали все равно не могли бы дышат ьпламенем
            flame.flameVelocity = new Vector2 (
            (float)Math.Cos(originalDirection.X),
            (float)Math.Sin(originalDirection.Y)
             );
            flame.originalDirection = originalDirection + flame.flameVelocity * 5f;

        }

        public void KillEnemy(int expa)
        {
            // Принимает кол-во очков опыта, которые надо добавить
            points += expa;
        }

    }
}
