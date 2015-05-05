using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace DRush {// Пространство имен именем нашей игры

    public class MainMenu : Microsoft.Xna.Framework.Game 
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Game game;
        Settings settings;
        Dictionary<string, int> coonfig; // Коофициенты из настроек


        public MainMenu() // Конструктор по умолчанию
        {

            graphics = new GraphicsDeviceManager(this);
            spriteBatch = new SpriteBatch(GraphicsDevice); // Класс для отрисовки
            settings = new Settings();

            Content.RootDirectory = "Content";
            this.Window.Title = "DRush"; // Название окна

            settings.GetData(out coonfig);
            graphics.PreferredBackBufferWidth = coonfig["widthOfScreen"]; // Разрешение экрана
            graphics.PreferredBackBufferHeight = coonfig["heightOfScreen"];
            graphics.IsFullScreen = true; // Полный экран SETTING

            int choose = 1;

            switch (choose)
            {
                case 1: game = new Game(); break;
                case 2: settings.Change(); break;
                case 3: this.Exit(); break;
            }

            // ToDO реализовать наследование от класса игра
        }

        public void Update() 
        {

        }

        // Изменение состояний. Флаги, следить за состоянием.
        
        protected void LoadContent() {
            game.LoadContent ();
        }

    }



}
