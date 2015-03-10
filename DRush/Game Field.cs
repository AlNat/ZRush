using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace DRush {// Пространство имен именем нашей игры
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GameField : Microsoft.Xna.Framework.Game // Класс игра
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Texture2D redDragonTexture; // Текстура красного дракона
        private Rectangle redDragonTextureRectangle; // Прямоугольник тестуры - координты


        public GameField() // Конструктор по умолчанию
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 800; // Разрешение экрана SETTINGS
            graphics.PreferredBackBufferHeight = 600;
            graphics.IsFullScreen = false; // Полный экран SETTING


        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // СЮДА ЗАГРУАЕМ ТЕКСТУРЫ
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            redDragonTexture = Content.Load<Texture2D>("texture_reddragon"); // Загрузили текстуру
            redDragonTextureRectangle = new Rectangle (100, 100, 360, 195); // Координты по x, y и длинной и шириной


        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black); // Цвет фона


            spriteBatch.Begin(); // Начало прорисовки
            
            spriteBatch.Draw (redDragonTexture, redDragonTextureRectangle, Color.Wheat); // Текстура, прямоугольник координат, цвет

            spriteBatch.End(); // Конец прорисовки


            base.Draw(gameTime);
        }
    }
}
