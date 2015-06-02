using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace DRush {// Пространство имен именем нашей игры

    class MainMenu 
    {

        public List<MenuItem> Items { get; set; }
        SpriteFont font; // Шрифт в меню
        MenuImage image;

        int winCounter;
        bool winFlag;

        int currentItem; // Выбранный пунт меню
        KeyboardState oldState; // Предыдущее состояние клавиатуры

        Settings settings; // Настройки
        private Dictionary<string, int> coonfig;

        public MainMenu() // Конструктор
        {
            // Получаем настройки
            settings = new Settings();
            settings.GetData(out coonfig);

            Items = new List<MenuItem>();

            winCounter = 50000;
            winFlag = false;

        }

        public void Update()
        {
            KeyboardState state = Keyboard.GetState(); // Получили состояние
            if (winFlag)
            {
                winCounter--;
            }

            if (state.IsKeyDown(Keys.Enter))
            { //Если нажат enter
                Items[currentItem].OnClick(); // Вызвали метод
            }

            int delta = 0; // Смещение в меню
            if (state.IsKeyDown(Keys.Up) && oldState.IsKeyUp(Keys.Up))
            { // Если нажали вверх и в предыдущем не нажимали вверх
                delta = -1;
            }
            if (state.IsKeyDown(Keys.Down) && oldState.IsKeyUp(Keys.Down))
            { // Если нажали вверх и в предыдущем не нажимали вверх
                delta = 1;
            }

            currentItem += delta;
            // Проверяем на валидность currentItem - что бы не вылезли за границы экрана
            bool ok = false;
            while (!ok)
            {
                if (currentItem < 0)
                { // Если достигли вершины то идем в самый низ 
                    currentItem = Items.Count - 1; 
                }
                else if (currentItem > Items.Count - 1)
                { // Если дошли до низа возвращаемся в самое начало
                    currentItem = 0;
                }
                else if (Items[currentItem].Active == false)
                { // Если неактивен это пункт то прошли через него
                    currentItem += delta;
                }
                else
                { // Если ничего не выполнилось то вышли из цикла
                    ok = true;
                }
            }

            oldState = state; // Сохранили состояние
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            image.Draw(spriteBatch); // Нарисовали заглавную картинку

            /// TODO - сцентрировать меню нормально!

            int y = 150; // Координаты
            int x = 500;

            foreach (MenuItem item in Items)
            { // Проходим для кадого пункта меню из списка

                Color color = Color.White; // Станадартный пункт
                if (item.Active == false) 
                { // Неактивный пункт меню
                    color = Color.Gray;
                }
                if ( item == Items[currentItem] )
                { // Выбранный пункт
                    color = Color.Red;
                }

                spriteBatch.DrawString (
                    font, // Шрифт
                    item.Name, // Текст
                    new Vector2 (x, y), // Ветор позиций
                    color // Цвет
                     );
                y+= 75;
            }

            spriteBatch.End();

        }

        public void LoadContent(ContentManager Content)
        {

            font = Content.Load<SpriteFont>("MenuFont");// Загрузили шрифт

            image = new MenuImage( // Загрузили начальную картинку
                Content.Load<Texture2D>("texture_mainmenu"),
                new Rectangle( 100, 100, 395, 525)
            );

        }

        public void Finish (string input, SpriteBatch spriteBatch)
        {
            winFlag = true;
            if (winCounter > 0) {
                spriteBatch.Begin(); // Начало прорисовки фона
                spriteBatch.DrawString(font, input, new Vector2 (coonfig["widthOfScreen"]/2, coonfig["heightOfScreen"]/2), Color.AntiqueWhite );
                spriteBatch.End(); // Начало прорисовки фона
            }
            // ТИКИ

            // Здесь нужно как-нибудь обождать
        }


    }

}
