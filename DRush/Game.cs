using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace DRush {// Пространство имен именем нашей игры

    public class Game //: Microsoft.Xna.Framework.Game // Класс игра
    {

        private Settings settings;
        private BackgroundGeneration background;
        private Dictionary<string, Texture2D> texture;
        private Dictionary<string, int> coonfig; // Коофициенты из настроек

        private Dragon playerDragon; // Дракон
        private Flame playerFlame;

        //public Game(SpriteBatch spriteBatch) // Конструктор
        public Game (Dictionary<string, Texture2D> loadDictionary) // Конструктор
        {
            texture = new Dictionary<string, Texture2D>(loadDictionary); // Скопировали тексутры
            settings = new Settings();
            background = new BackgroundGeneration();

            //LoadTexture(spriteBatch);
            Generate();
            //Update();
        }

        /*
        public void LoadTexture(SpriteBatch spriteBatch)
        {
            // Словарь текстур:
            texture = new Dictionary<string, Texture2D>();
     
            texture.Add("grass", Content.Load<Texture2D>("texture_grass"));
            texture.Add("castle", Content.Load<Texture2D>("texture_castle"));
            texture.Add("home", Content.Load<Texture2D>("texture_home"));
            texture.Add("lake", Content.Load<Texture2D>("texture_lake"));
            texture.Add("tree1", Content.Load<Texture2D>("texture_tree1"));
            texture.Add("tree2", Content.Load<Texture2D>("texture_tree2"));
            texture.Add("village", Content.Load<Texture2D>("texture_village"));
            texture.Add ("reddragon",Content.Load<Texture2D>("texture_reddragon"));
            texture.Add ("flame",Content.Load<Texture2D>("texture_flame"));
            texture.Add ("farm", Content.Load<Texture2D>("texture_farm"));
        }
        */

        /// <summary>
        /// ИТОГО
        /// Сейчас не находит тестуры в словаре
        /// А если загруать отсюда то ругается на null в GraphicsDevice
        /// Похже просто не отдает текстуры вне LoadContent. И грузить их придется оттуда - 
        ///  напрямую вызвать из функции все методы для загрузки
        /// </summary>

        public void Generate()
        {

            // Создаем экземпляр дракона и инициализирем его
            playerDragon = new Dragon(texture["reddragon"],
                new Rectangle(
                    (1000 / 2),
                    (1000 / 2),
                    180,
                    100
                )
            );
            playerFlame = new Flame(
                texture["flame"],
                new Rectangle(0, 0, 100, 100)
            );
        }


        /*
         *  Сохранять все переменные из этого класса для сохранения
         *  Сохранение, отмена и вперед (ворд). 
         *  Паттерн Команда.
         *  
         *  Вызываем только после  CTRL P и 
         *  
         *  Отдельный класс
         * 
         */

        public void Update()
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {

                // Переход в меню
                //this.Exit();
            }

            // TODO каждые n секунд генерировать нового врага, из замка.
            playerDragon.Update();
            // Пока не будем изменять фон, но в будущем будем изменять и вызывать отсюда background.Update();

            /*
            for (int t = 0; t < countOfEnemies; t++) {
                Enemies[t].Update(); // Обновляем врагов 
            }
            // ToDo - обновлять пламя и врагов
            */

        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(); // Начало прорисовки фона

            background.Draw (spriteBatch, texture); // Прорисовали фон

            spriteBatch.End(); // Конец прорисовки фона
            

            spriteBatch.Begin(); // Начало прорисовки

            playerDragon.Draw(spriteBatch);

            //playerFlame.Draw(spriteBatch);

            spriteBatch.End(); // Конец прорисовки

        }


    }

}
