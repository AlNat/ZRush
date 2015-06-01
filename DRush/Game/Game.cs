using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

// Геттеры\сеттеры   или конструктор с переменным числом аргументов - загрузка сохранение
// Интерфейс для метода save и load  в кадом классе.


namespace DRush {// Пространство имен именем нашей игры

    enum GameState
    { // Игровые состояния
        Game,
        Menu,
        Settings,
    }

    public class Game : Microsoft.Xna.Framework.Game // Класс игра
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Максимальное кол-во врагов
        int maxFlame = 3;
        int maxEnemy = 5;

        // Кол-во активных сейчас
        int nowFlame;
        int nowEnemy;

        private SpriteFont scoreFont;

        private Settings settings; // Настройки
        //private Saving saver; // Класс для сохранения\загрузи
        //private AllData data; // Объет - данные

        private BackgroundGeneration background; // Класс для фона генерации
        private Dictionary<string, Texture2D> texture; // Список тестук
        private Dictionary<string, int> coonfig; // Список настроек
        
        private Dragon playerDragon; // Дракон
        //private Flame tempFlame;
        public List<Flame> playerFlames = new List<Flame>(); // Список выстрелов
        public List<Swordsman> enemies = new List<Swordsman>(); // Список противников

        MainMenu menu; // Меню
        GameState gamestate = GameState.Menu; // Установили игровое состояние в меню

        public Game() // Конструктор по умолчанию
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.Window.Title = "DRush"; // Название окна

            settings = new Settings();
            settings.GetData(out coonfig);

            graphics.PreferredBackBufferWidth = coonfig["widthOfScreen"]; // Разрешение экрана
            graphics.PreferredBackBufferHeight = coonfig["heightOfScreen"];
            graphics.IsFullScreen = true; // Полный экран SETTING

            nowFlame = 0;
            nowEnemy = 0;

            GreateGame(Content); // Вызвали создание новой игры

        }

        /// <summary>
        ///  Методы для меню
        /// </summary>

        protected override void Initialize()
        {
            // Инициализировали меню
            menu = new MainMenu();
            MenuItem newGame = new MenuItem("New game"); // Новая игра
            MenuItem resumeGame = new MenuItem("Resume game"); // Продолить игру

            MenuItem saveGame = new MenuItem("Save game"); // Сохранить игру
            MenuItem loadGame = new MenuItem("Load game"); // Загрузить игру

            MenuItem changeSettings = new MenuItem ("Settings"); // Настройки
            MenuItem exitGame = new MenuItem("Exit"); // Выход

            resumeGame.Active = false; // По умолчанию неактивен
            saveGame.Active = false;

            // Обработчики
            newGame.Click +=new EventHandler(newGame_Click);
            resumeGame.Click +=new EventHandler(resumeGame_Click);

            saveGame.Click += new EventHandler(saveGame_Click);
            loadGame.Click += new EventHandler(loadGame_Click);

            changeSettings.Click += new EventHandler(changeSettings_Click);
            exitGame.Click +=new EventHandler(exitGame_Click);

            // Добавляем элеменыт меню
            menu.Items.Add(newGame);
            menu.Items.Add(resumeGame);

            menu.Items.Add(saveGame);
            menu.Items.Add(loadGame);

            menu.Items.Add(changeSettings);
            menu.Items.Add(exitGame);

            base.Initialize();
        }

        void newGame_Click(object sender, EventArgs e)
        { // Новая игра
            menu.Items[1].Active = true; // Сделали активным обработчик продолжения игры и сохранения
            menu.Items[2].Active = true;
            gamestate = GameState.Game;

            GreateGame(Content);
            playerDragon.SetToStart(); 

            ////// БАГА - остается при новой игре только несожранные люди.
            Random rnd = new Random(); // Создали экзмепляр рандома
            foreach (Swordsman s in enemies)
            {

                int rX = rnd.Next(50, coonfig["widthOfScreen"] - 100);
                int rY = rnd.Next(50, coonfig["heightOfScreen"] - 100);
                s.SetToStart(rX, rY);
            }
        }

        void resumeGame_Click(object sender, EventArgs e)
        { // Продолжить игру
            gamestate = GameState.Game;
        }

        void saveGame_Click(object sender, EventArgs e)
        { // Сохранить игру
            //data.GetData();
            //saver.Save();
        }

        void loadGame_Click(object sender, EventArgs e)
        { // Загрузить игру
            //saver.Load(); 
            //data.GiveData();
        }

        void changeSettings_Click(object sender, EventArgs e)
        { // Изменение настроек

        }

        void exitGame_Click(object sender, EventArgs e)
        { // Выход из игры
            this.Exit();
        }

        /// <summary>
        /// Загрузка контента
        /// </summary>
  
        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice); // Класс для отрисовки

            /////// Как я понял - все действия с текстурами нуно проводить только здесь

            scoreFont = Content.Load<SpriteFont>("ScoreFont");

            // Словарь текстур:
            texture = new Dictionary<string, Texture2D>();
            texture.Add("grass", Content.Load<Texture2D>("Background\\texture_grass"));
            texture.Add("castle", Content.Load<Texture2D>("Background\\texture_castle"));
            texture.Add("home", Content.Load<Texture2D>("Background\\texture_home"));
            texture.Add("lake", Content.Load<Texture2D>("Background\\texture_lake"));
            texture.Add("tree1", Content.Load<Texture2D>("Background\\texture_tree1"));
            texture.Add("tree2", Content.Load<Texture2D>("Background\\texture_tree2"));
            texture.Add("village", Content.Load<Texture2D>("Background\\texture_village"));
            texture.Add("farm", Content.Load<Texture2D>("Background\\texture_farm"));
            texture.Add("reddragon", Content.Load<Texture2D>("Dragons\\texture_reddragon"));
            texture.Add("flame", Content.Load<Texture2D>("Dragons\\texture_flame"));
            texture.Add("swordsman", Content.Load<Texture2D>("Mobs\\texture_swordsman"));

            /// <summary>
            /// BIF PROBLEMS HERE
            /// 
            /// Не получается по нормальному создавать объеты вне этой функции
            /// </summary>

            playerDragon = new Dragon(
                texture["reddragon"],
                new Vector2(
                    (coonfig["widthOfScreen"] / 2) - 90,
                    (coonfig["heightOfScreen"] / 2) - 50
                )
            );

            Random rnd = new Random(); // Создали экзмепляр рандома
            for (int t = 0; t < maxEnemy; t++)
            {
                int rX = rnd.Next(50, coonfig["widthOfScreen"] - 100);
                int rY = rnd.Next(50, coonfig["heightOfScreen"] - 100);
                enemies.Add(new Swordsman (texture["swordsman"], new Rectangle(rX,  rY,  100, 100)) );
                nowEnemy++;
            }
          
            /*
                tempFlame = new Flame(
                    texture["flame"],
                    //new Rectangle(100, 100, 100, 100),
                    new Vector2(100, 100)
                ); 
            */
            menu.LoadContent(Content); // Передали Content

            GreateGame(Content); // Вызвали метод инициализации нового игры
        }

        private void GreateGame(ContentManager Content)
        { // Инициализация нового уровня
            // Генерируем новый фон и ставим дракона, и противников

            background = new BackgroundGeneration();

        }

        /// <summary>
        /// Методы обновления 
        /// </summary>


        protected override void Update(GameTime gameTime)
        {
            if (gamestate == GameState.Game)
            { // Если игровое состояние - игра то обновляем игру
                UpdateGame(); // Выделели обновление игры в отдельный метод
            }
            else if (gamestate == GameState.Menu)
            {
                menu.Update();
            }

        }

        private void UpdateGame()
        { // Обновление игры
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Escape))
            { // Если нажали ESC то изменили состояние на меню - начали работать с меню
                gamestate = GameState.Menu;
            }

            playerDragon.Update();
            EnemiesUpdate();
            
            if (playerDragon.shootSignal ) // Если приняли СИГНАЛ о том что произвели выстре и есть еще возможость для выстрелов то стреляем
            {
                if (nowFlame < maxFlame)
                {
                    Flame tempFlame = new Flame(
                        texture["flame"], 
                        //new Rectangle(0, 0, 0, 0),
                        new Vector2 (100, 100)
                    );
                    Flame tmp = tempFlame;
                    playerDragon.Shoot(ref tmp); // Инициализировали выстрел там 
                    playerFlames.Add(tmp);
                    nowFlame++;
                }
            }
            FlameUpdate();

            // Пока не будем изменять фон, но в будущем будем изменять и вызывать отсюда background.Update();

        }

        public void EnemiesUpdate()
        {
            foreach (Swordsman sw in enemies)
            { 
                if (sw.IsCollapse(playerDragon))
                { 
                    sw.isVisible = false;
                    playerDragon.KillEnemy(sw.points);
                }
            }
            
            for (int t = 0; t < enemies.Count; t++)
            { // Удаляем неактивные элементы
                if (!enemies[t].isVisible)
                {
                    enemies.RemoveAt(t);
                    t--;
                    nowEnemy -= 1;
                }
            }
            
        }

        private void FlameUpdate()
        {
            foreach (Flame flames in playerFlames)
            { // Прошли по списку пламеней и продвинули их
                flames.originalDirection.X += 5;
                flames.originalDirection.Y += 5;
                //if (Vector2.Distance(playerDragon.newDirection, flames.originalDirection) > coonfig["heightOfScreen"] / 2)
                //{ // Если палмя слишком далеко то удалить его
                  //  flames.isVisible = false; 
                //}
            }

            for (int t = 0; t < playerFlames.Count; t++)
            { // Удаляем неактивные элементы
                if (!playerFlames[t].isVisible)
                {
                    playerFlames.RemoveAt(t);
                    t--;
                    nowFlame -= 1;
                }
            }

        }

        /// <summary>
        /// Рисование
        /// </summary>


        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black); // Цвет начального фона

            if (playerDragon.points >= maxEnemy * 10)
            {
                DrawFinish(spriteBatch);
            }
            else if (gamestate == GameState.Game)
            { // Если игровое состояние - игра то рисуем игру
                DrawGame(spriteBatch); // Просто выделили рисование игры в отедльный метод
            }
            else if (gamestate == GameState.Menu)
            {
                menu.Draw(spriteBatch);
            }

            base.Draw(gameTime);
        }

        private void DrawGame(SpriteBatch spriteBatch)
        { // Рисуем игру

            spriteBatch.Begin(); // Начало прорисовки фона
            background.Draw (spriteBatch, texture); // Прорисовали фон
            spriteBatch.DrawString(scoreFont, "Score = " + playerDragon.points, new Vector2((coonfig["widthOfScreen"] / 2) - 50, 1), Color.OrangeRed);
            spriteBatch.End(); // Конец прорисовки фона

            spriteBatch.Begin(); // Начало прорисовки
            foreach (Flame fl in playerFlames)
            {
                fl.Draw(spriteBatch);
            }
            spriteBatch.End(); // Конец прорисовки
            
            spriteBatch.Begin(); // Начало прорисовки
            foreach (Swordsman sw in enemies)
            {
                if (sw.isVisible)
                sw.Draw(spriteBatch);
            }
            spriteBatch.End(); // Конец прорисовки

            spriteBatch.Begin(); // Начало прорисовки
            playerDragon.Draw(spriteBatch);          
            spriteBatch.End(); // Конец прорисовки
        }


         void DrawFinish(SpriteBatch spriteBatch)
         {
            gamestate = GameState.Menu;
            menu.Finish("YOU WIN! Score = " + playerDragon.points, spriteBatch);
            playerDragon.points = 0;
            menu.Draw(spriteBatch);
         }


    }

}
