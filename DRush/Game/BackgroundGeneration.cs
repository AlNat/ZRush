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
        private Dictionary<string, int> coonfig; // Коофициенты из настроек
        private Settings settings; 

        public int[,] back; // Да, я все понимаю. Но блин, мне лень писать геттеры
        Rectangle mainFrame = new Rectangle(0, 0, 100, 100); // Примитив чанка - пустой прямоугольник размерами 100х100

        public BackgroundGeneration()
        { // Генерируем расположение элементов фона

            settings = new Settings(); // Создали экземпляр класса настройки
            settings.GetData(out coonfig); // Заполнили коофициенты 

            back = new int[coonfig["countOfChuncsX"], coonfig["countOfChuncsY"]]; // Расположение тестур
            Random rnd = new Random(); // Создали экзмепляр рандома

            for (int tX = 0; tX < coonfig["countOfChuncsX"]; tX++) // Генерируем фон
            {

                for (int tY = 0; tY < coonfig["countOfChuncsY"]; tY++)
                {
                    // TODO - нормальный алгоритм генерации!
                    // Меньше деревень (потом тоже сделаем объектами), домов, озер. Больше травы, ферм, и лесов. Потом нормальная генерация полей около деревень и тд.

                    int rand = rnd.Next(0, 8);
                    if (rand == 1)
                    {
                        rand = 0; // Удалили замок
                    }
                    if (rand == 6) // Проверили деревню
                    {
                        int t = rnd.Next(1, 3); // Уменьшили шанс на выпадение деревни в 3 раз
                        if (t != 2)
                        {
                            rand = rnd.Next(2, 4);
                        }
                    }
                    back [tX, tY] = rand; // Числа 1-7 - номера для текстур.

                }
            }

            // Расставили замки
            back[0, 0] = 1; // Правый нижний
            back[0, 1] = 1; // Правый верхний
            back[1, 0] = 1; // Левый нижний
            back[1, 1] = 1; // Левый верхний

            /// НУ ВООБЩЕ ПРОСТО ЗАМЕЧАТЕЛЬНО! ЧЕРТОВЫ МАССИВЫ

        }


        public void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> texture) // Передали массив текстур и все хорошо;
        { // Функция рисования  
            for (int tX = 0; tX < coonfig["countOfChuncsX"]; tX++) // Отрисовывем фон несколькими проходами 
            {
                
                for (int tY = 0; tY < coonfig["countOfChuncsY"]; tY++)
                {

                    switch (back[tX,tY])
                    { 
                        case 0:
                            spriteBatch.Draw (texture["grass"], mainFrame, Color.White);
                            break;
                        case 1:
                            spriteBatch.Draw (texture["castle"], mainFrame, Color.White);
                            break;
                        case 2:
                            spriteBatch.Draw(texture["home"], mainFrame, Color.White);
                            break;
                        case 3:
                            spriteBatch.Draw (texture["lake"], mainFrame, Color.White);
                            break;
                        case 4:
                            spriteBatch.Draw (texture["tree1"], mainFrame, Color.White);
                            break;
                        case 5:
                            spriteBatch.Draw (texture["tree2"], mainFrame, Color.White);
                            break;
                        case 6:
                            spriteBatch.Draw(texture["village"], mainFrame, Color.White);
                            break;
                        case 7:
                            spriteBatch.Draw (texture["farm"], mainFrame, Color.White);
                            break;                         
                    }
                    mainFrame.Y = coonfig["yBackgroundCooficient"] * tY; // Продвинулись
                }
                mainFrame.X = coonfig["xBackgroundCooficient"] * tX;
            }
        }

        public void Update()
        {
            // TODO - обсчет горящего леса, построек и тд. 

        }


    }
}
