using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DRush
{
    class BackgroundGeneration
    {
        int[,] back;
        Rectangle mainFrame = new Rectangle(0, 0, 100, 100); // Примитив чанка - пустой прямоугольник размерами 100х100

        public BackgroundGeneration(Texture2D texture1) // Может лучше лист текстур? И как лучше организовать работу с конфигом?
        {

            int[,] back = new int[countOfChuncsX, countOfChuncsY];

            Random rnd = new Random();
            for (int tX = 0; tX < countOfChuncsX; tX++) // Генерируем фон
            {
                for (int tY = 0; tY < countOfChuncsY; tY++)
                {
                    int rand = rnd.Next(1, 6);
                    back[tX, tY] = rand; // Числа 1-2 - номера для текстур. TODO - словарь текстур

                    mainFrame.Y = yBackgroundCooficient * tY;
                }
                mainFrame.X = xBackgroundCooficient * tX;
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        { // Функция рисования
            for (int tX = 0; tX < countOfChuncsX; tX++) // Отрисовывем фон несколькими проходами 
            {
                for (int tY = 0; tY < countOfChuncsY; tY++)
                {
                    //spriteBatch.Draw (background[rand], mainFrame, Color.White); - не хочет из массива тянуть :(
                    switch (back[tX, tY])
                    {
                        case 1:
                            spriteBatch.Draw(background1, mainFrame, Color.White);
                            break;
                        case 2:
                            spriteBatch.Draw(background2, mainFrame, Color.White);
                            break;
                        case 3:
                            spriteBatch.Draw(background3, mainFrame, Color.White);
                            break;
                        case 4:
                            spriteBatch.Draw(background4, mainFrame, Color.White);
                            break;
                        case 5:
                            spriteBatch.Draw(background5, mainFrame, Color.White);
                            break;
                        default:
                            break;
                    }
                    mainFrame.Y = yBackgroundCooficient * tY;
                }
                mainFrame.X = xBackgroundCooficient * tX;
            }
        }

        public void Update()
        {

        }


    }
}
