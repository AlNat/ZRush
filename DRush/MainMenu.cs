using System;

namespace DRush {// Пространство имен именем нашей игры

    public class MainMenu : Microsoft.Xna.Framework.Game 
    {

        public MainMenu() // Конструктор по умолчанию
        {

            // TODO - главное меню!!!

            /*
             * int choose;
             * GameField game = new GameField();
             * Settings settings = new Settings();
             * 
             * Input choose;
             * 
             * switch (choose) {
             * case 1: game.Run (); break;
             * case 2: settings.Run(); break;
             * case 3: 
             * 
            */

            using (Game game = new Game())
            {
                game.Run();
            }
        
        }

    }



}
