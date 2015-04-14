using System;
using System.Collections.Generic;

namespace DRush
{
    class Settings
    {
        // Разрешение экрана
        static int widthOfScreen = 1600;
        static int heightOfScreen = 900;

        // Коофициент для формул 
        static int xBackgroundCooficient = 100;
        static int yBackgroundCooficient = 100;

        // Кол-во чанков(блоков) 
        static int countOfChuncsX = widthOfScreen / xBackgroundCooficient;
        static int countOfChuncsY = heightOfScreen / yBackgroundCooficient; 

        public Settings () 
        {
            // TODO - реализовать работу с конфигурационными файлами
        }

        public void GetData(out Dictionary<string, int> data) // ref и out - отличные инструменты. ref - это передача по ссылке, out - вариант "отложенной инициализации"
        { // Вернули значения коофициентов - TODO СЛОВАРЬ

            data = new Dictionary<string, int>();
            data.Add("widthOfScreen", widthOfScreen);
            data.Add("heightOfScreen", heightOfScreen);
            data.Add("xBackgroundCooficient", xBackgroundCooficient);
            data.Add("yBackgroundCooficient", yBackgroundCooficient);
            data.Add("countOfChuncsX", countOfChuncsX);
            data.Add("countOfChuncsY", countOfChuncsY);
            /*
            data[0] = widthOfScreen; // 0
            data[1] = heightOfScreen; // 1
            data[2] = xBackgroundCooficient; // 2
            data[3] = yBackgroundCooficient; // 3
            data[4] = countOfChuncsX; // 4
            data[5] = countOfChuncsY; // 5
            */
        }

        public int GetWidthOfScreen()
        {
            return widthOfScreen;
        }
        public int GetHeightOfScreen()
        {
            return heightOfScreen;
        }

    }
}
