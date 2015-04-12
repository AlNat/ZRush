using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Audio;
//using Microsoft.Xna.Framework.GamerServices;
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
        private BackgroundGeneration background;// = new BackgroundGeneration();
        private Dragon playerDragon; // Дракон
        private Flame playerFlame;
        private Texture2D[] texture;// = new Texture2D[6];

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

            // Загрузили текстуры -TODO надо подумать насчет более оптимально варианта.
            texture = new Texture2D[6];
            texture[0] = Content.Load<Texture2D>("texture_grass");
            texture[1] = Content.Load<Texture2D>("texture_forest");
            texture[2] = Content.Load<Texture2D>("texture_farm");
            texture[3] = Content.Load<Texture2D>("texture_road");
            texture[4] = Content.Load<Texture2D>("texture_villige");
            texture[5] = Content.Load<Texture2D>("texture_water");

            // Создаем экземпляр дракона и инициализирем его
            playerDragon = new Dragon(Content.Load<Texture2D>("texture_reddragon"), new Rectangle((settings.GetWidthOfScreen() / 2), (settings.GetHeightOfScreen() / 2), 180, 100));

        }


        protected override void Update(GameTime gameTime)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

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

            background.Draw (spriteBatch, ref texture); // Прорисовали фон

            spriteBatch.End(); // Конец прорисовки фона
            

            spriteBatch.Begin(); // Начало прорисовки

            playerDragon.Draw(spriteBatch);

            spriteBatch.End(); // Конец прорисовки

            base.Draw(gameTime);
        }


    }

}
