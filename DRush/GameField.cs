using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

/*
 * DONE
 * 
 * 1) Класс игровой объкет
 * 2) Наследуемые от него классы дракона, пламени, деревни, лучника, мечника. Деревня - около нее появляются враги. Когда деревня уничтожается, враги оттуда не появляются
 * 
 * TODO
 * 
 * 3) Генерация фона по рандому
 * 4) Пламя = стрельба
 * 5) Генерация врагов
 * 6) Деревни
 * 
 */

namespace DRush
{// Пространство имен именем нашей игры

    public class GameField : Microsoft.Xna.Framework.Game // Класс игра
    {

        // GameField  - вынесту туда все

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Разрешение экрана
        const int widthOfScreen = 1600;
        const int heightOfScreen = 900;

        // Коофициент для формул background
        const int xBackgroundCooficient = 100;
        const int yBackgroundCooficient = 100;

        // Кол-во чанков(блоков) в background
        int countOfChuncsX = widthOfScreen / xBackgroundCooficient;
        int countOfChuncsY = heightOfScreen / yBackgroundCooficient;

        /* ТЕКСТУРЫ */
        private Texture2D background1;
        private Texture2D background2;
        private Rectangle mainFrame;

        //private Texture2D[] background = new Texture2D[2];
        //private Rectangle mainFrame;

        private Dragon playerDragon;
        private Flame playerFlame;

        // Размеры фигурки дракона - TODO изменять по формуле для разных экранов =Просто что бы не писать числа
        const int dragonLong = 180;
        const int dragonHeit = 100;
        int dragonXCoordinates = widthOfScreen / 2;
        int dragonYCoordinates = heightOfScreen / 2;

        //int[,] back = new int[countOfChuncsX, countOfChuncsY];
        int[,] back = new int[16, 9];

        public GameField() // Конструктор по умолчанию
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this.Window.Title = "DRush"; // Название окна

            graphics.PreferredBackBufferWidth = widthOfScreen; // Разрешение экрана SETTINGS
            graphics.PreferredBackBufferHeight = heightOfScreen;
            graphics.IsFullScreen = true; // Полный экран SETTING



            Random rnd = new Random();

            for (int tX = 0; tX < countOfChuncsX; tX++) // Отрисовывем фон несколькими проходами 
            {
                for (int tY = 0; tY < countOfChuncsY; tY++)
                {
                    int rand = rnd.Next(1, 3);

                    back[tX, tY] = rand;

                    mainFrame.Y = yBackgroundCooficient * tY;
                }
                mainFrame.X = xBackgroundCooficient * tX;
            }


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

            background1 = Content.Load<Texture2D>("texture_greece");
            background2 = Content.Load<Texture2D>("texture_forest");
            mainFrame = new Rectangle(0, 0, 100, 100); // Создаем чанк

            //redDragon = new dragon(redDragonTexture, redDragonTextureRectangle);

            playerDragon = new Dragon(Content.Load<Texture2D>("texture_reddragon"), new Rectangle(dragonXCoordinates, dragonYCoordinates, dragonLong, dragonHeit));

        }


        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            playerDragon.Update();

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black); // Цвет начального фона

            spriteBatch.Begin(); // Начало прорисовки фона
            //Random rnd = new Random();

            for (int tX = 0; tX < countOfChuncsX; tX++) // Отрисовывем фон несколькими проходами 
            {
                for (int tY = 0; tY < countOfChuncsY; tY++)
                {
                    //int rand = rnd.Next(1, 3);
                    // TODO - генерация чанков по формулам - дороги, реки и тд.
                    //spriteBatch.Draw (background[rand], mainFrame, Color.White); - не хочет из массива тянуть :(
                    switch (back[tX, tY]) // Ха ха ха - бесконечно генерируется
                    //switch (back[tX,tY])
                    {
                        case 1:
                            spriteBatch.Draw(background1, mainFrame, Color.White);
                            break;
                        case 2:
                            spriteBatch.Draw(background2, mainFrame, Color.White);
                            break;
                        default:
                            break;
                    }
                    //spriteBatch.Draw(background1, mainFrame, Color.White); // ToDel when fix
                    mainFrame.Y = yBackgroundCooficient * tY;
                }
                mainFrame.X = xBackgroundCooficient * tX;
            }
            spriteBatch.End(); // Конец прорисовки фона


            spriteBatch.Begin(); // Начало прорисовки

            playerDragon.Draw(spriteBatch);

            spriteBatch.End(); // Конец прорисовки


            base.Draw(gameTime);
        }


    }

}
