using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace DRush {// Пространство имен именем нашей игры

    public class Game : Microsoft.Xna.Framework.Game // Класс игра
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Settings settings;
        private BackgroundGeneration background;
        private Dragon playerDragon; // Дракон
        private Flame playerFlame;
        private Dictionary<string, Texture2D> texture;

        public Game() // Конструктор по умолчанию
        {
            graphics = new GraphicsDeviceManager(this);
            settings = new Settings();
            background = new BackgroundGeneration();

            Content.RootDirectory = "Content";
            this.Window.Title = "DRush"; // Название окна

            graphics.PreferredBackBufferWidth = settings.GetWidthOfScreen(); // Разрешение экрана
            graphics.PreferredBackBufferHeight = settings.GetHeightOfScreen();
            graphics.IsFullScreen = true; // Полный экран SETTING

        }


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

  
        protected override void LoadContent()
        {
            // СЮДА ЗАГРУАЕМ ТЕКСТУРЫ
            spriteBatch = new SpriteBatch(GraphicsDevice); // Класс для отрисовки

            // Словарь текстур:
            texture = new Dictionary<string, Texture2D>();
            texture.Add("grass", Content.Load<Texture2D>("texture_grass"));
            texture.Add("castle", Content.Load<Texture2D>("texture_castle"));
            texture.Add("home", Content.Load<Texture2D>("texture_home"));
            texture.Add("lake", Content.Load<Texture2D>("texture_lake"));
            texture.Add("tree1", Content.Load<Texture2D>("texture_tree1"));
            texture.Add("tree2", Content.Load<Texture2D>("texture_tree2"));
            texture.Add("village", Content.Load<Texture2D>("texture_village"));

            // Создаем экземпляр дракона и инициализирем его
            playerDragon = new Dragon(
                Content.Load<Texture2D>("texture_reddragon"), 
                new Rectangle(
                    (settings.GetWidthOfScreen() / 2), 
                    (settings.GetHeightOfScreen() / 2), 
                    180, 
                    100
                    )
            );
            playerFlame = new Flame(
                Content.Load<Texture2D>("texture_flame"),
                new Rectangle(0, 0, 100, 100)
            );

        }


        protected override void Update(GameTime gameTime)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.Exit();
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

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black); // Цвет начального фона


            spriteBatch.Begin(); // Начало прорисовки фона

            background.Draw (spriteBatch, texture); // Прорисовали фон

            spriteBatch.End(); // Конец прорисовки фона
            

            spriteBatch.Begin(); // Начало прорисовки

            playerDragon.Draw(spriteBatch);

            //playerFlame.Draw(spriteBatch);

            spriteBatch.End(); // Конец прорисовки


            base.Draw(gameTime);
        }


    }

}
