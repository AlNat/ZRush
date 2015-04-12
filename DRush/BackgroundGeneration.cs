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

        public int[] coonf; // Коофициенты из настроек - проще один раз взять массив, чем много раз тянуть геттерами
        public Settings settings; 

        int[,] back;
        Rectangle mainFrame = new Rectangle(0, 0, 100, 100); // Примитив чанка - пустой прямоугольник размерами 100х100

        public BackgroundGeneration()
        { // Генерируем расположение элементов фона

            coonf = new int [6]; // Создаем массив значений коофициентов.
            settings = new Settings(); // Создали экземпляр класса настройки
            settings.GetData(ref coonf); // Заполнили коофициенты
            
            back = new int[ coonf[4], coonf[5] ]; // Расположение тестур
            Random rnd = new Random();

            for (int tX = 0; tX < coonf[4]; tX++) // Генерируем фон
            {
                for (int tY = 0; tY < coonf[5]; tY++)
                {
                    int rand = rnd.Next(1, 6);
                    back [tX, tY] = rand; // Числа 1-6 - номера для текстур. TODO - словарь текстур

                    mainFrame.Y = coonf[3] * tY;
                }
                mainFrame.X = coonf[2] * tX;
            }

        }


        public void Draw(SpriteBatch spriteBatch, ref Texture2D[] texture) // Передали массив текстур и все хорошо; ref - замечательная вешь
        { // Функция рисования
            for (int tX = 0; tX < coonf[4]; tX++) // Отрисовывем фон несколькими проходами 
            {
                for (int tY = 0; tY < coonf[5]; tY++)
                {

                    switch (back[tX,tY]) 
                    {
                        case 0:
                            spriteBatch.Draw (texture[0], mainFrame, Color.White);
                            break;
                        case 1:
                            spriteBatch.Draw (texture[1], mainFrame, Color.White);
                            break;
                        case 2:
                            spriteBatch.Draw (texture[2], mainFrame, Color.White);
                            break;
                        case 3:
                            spriteBatch.Draw (texture[3], mainFrame, Color.White);
                            break;
                        case 4:
                            spriteBatch.Draw (texture[4], mainFrame, Color.White);
                            break;
                        case 5:
                            spriteBatch.Draw (texture[5], mainFrame, Color.White);
                            break;
                    }


                    mainFrame.Y = coonf[3] * tY;
                }
                mainFrame.X = coonf[2] * tX;
            }
        }

        public void Update()
        {

        }


    }
}
