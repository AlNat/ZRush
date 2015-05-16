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

        int currentItem; // Выбранный пунт меню
        KeyboardState oldState; // Предыдущее состояние клавиатуры
 
        public MainMenu() // Конструктор по умолчанию
        {

            Items = new List<MenuItem>();

            /*
            using (Game game = new Game())
            {
                game.Run();
            }
            */


        }

        public void Update()
        {
            KeyboardState state = Keyboard.GetState(); // Получили состояние

            if (state.IsKeyDown(Keys.Enter))
            { //Если нажат enter
                Items[currentItem].OnClick(); // Вызвали метод
            }

            int delta = 0; // Смещение в меню
            if (state.IsKeyDown(Keys.Up) && state.IsKeyUp(Keys.Up))
            { // Если нажали вверх и в предыдущем не нажимали вверх
                delta = -1;
            }
            if (state.IsKeyDown(Keys.Down) && state.IsKeyUp(Keys.Down))
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

            int y = 100; // Координата

            foreach (MenuItem item in Items)
            { // Проходим для кадого пункта меню из списка

                Color color = Color.White; // Станадартный пункт
                if (item.Active == false) 
                { // Неактивный пункт меню
                    color = Color.Gray;
                }
                if ( item == Items[currentItem] )
                { // Выбранный пункт
                    color = Color.Brown;
                }

                spriteBatch.DrawString (
                    font, // Шрифт
                    item.Name, // Текст
                    new Vector2 (100, y), // Ветор позиций
                    color // Цвет
                     );
                y+= 50;
            }

            spriteBatch.End();

        }

        public void LoadContent(ContentManager Content)
        { // Загрузили шрифт
            font = Content.Load<SpriteFont>("MenuFont");
        }

    }

}
