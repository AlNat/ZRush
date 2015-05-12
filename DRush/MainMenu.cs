using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace DRush {// Пространство имен именем нашей игры

    public class MainMenu : Microsoft.Xna.Framework.Game 
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Game game;
        Settings settings;
        Dictionary<string, int> coonfig; // Коофициенты из настроек
        Dictionary<string, Texture2D> textures;

        public MainMenu() // Конструктор по умолчанию
        {

            graphics = new GraphicsDeviceManager(this);
            spriteBatch = new SpriteBatch(GraphicsDevice); // Класс для отрисовки
            settings = new Settings();
            textures = new Dictionary<string, Texture2D>();

            Content.RootDirectory = "Content";
            this.Window.Title = "DRush"; // Название окна

            settings.GetData(out coonfig);
            graphics.PreferredBackBufferWidth = coonfig["widthOfScreen"]; // Разрешение экрана
            graphics.PreferredBackBufferHeight = coonfig["heightOfScreen"];
            graphics.IsFullScreen = true; // Полный экран SETTING


            LoadContent();
            Welcome();
        }

        // Изменение состояний. Флаги, следить за состоянием.
        /*
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }
        */
        // ВОПРОС - КАК ПЕРЕДАТЬ ТЕКСТУРЫ В КЛАСС GAME ???

        
        protected override void LoadContent()
        {
            //spriteBatch = new SpriteBatch(GraphicsDevice); // Класс для отрисовки
            
            // Словарь текстур:
           
            textures.Add("grass", Content.Load<Texture2D>("texture_grass"));
            textures.Add("castle", Content.Load<Texture2D>("texture_castle"));
            textures.Add("home", Content.Load<Texture2D>("texture_home"));
            textures.Add("lake", Content.Load<Texture2D>("texture_lake"));
            textures.Add("tree1", Content.Load<Texture2D>("texture_tree1"));
            textures.Add("tree2", Content.Load<Texture2D>("texture_tree2"));
            textures.Add("village", Content.Load<Texture2D>("texture_village"));
            textures.Add("reddragon", Content.Load<Texture2D>("texture_reddragon"));
            textures.Add("flame", Content.Load<Texture2D>("texture_flame"));
            textures.Add("farm", Content.Load<Texture2D>("texture_farm"));
        }
        
        protected override void Update(GameTime gameTime)
        {
            // TODO - Add signals here
            game.Update();

            if (settings.wasUpdate() == true)
            {
                settings.Update();
            }

        }

        public void Draw()
        {
            game.Draw(spriteBatch);
        }

        private void Welcome()
        {
            int choose = 1;

            switch (choose)
            {
                case 1: game = new Game(textures); break;
                case 2: settings.Change(); break;
                case 3: this.Exit(); break;
            }


        }

    }



}
