using System;
using System.Collections.Generic;

namespace DRush
{
    class Settings
    {
        // static - ибо настройки везде одинаковые
        // Разрешение экрана
        static int widthOfScreen = 1600;
        static int heightOfScreen = 900;

        // Коофициент для формул 
        static int xBackgroundCooficient = 100;
        static int yBackgroundCooficient = 100;

        // Кол-во чанков(блоков) 
        static int countOfChuncsX;// = widthOfScreen / xBackgroundCooficient;
        static int countOfChuncsY;// = heightOfScreen / yBackgroundCooficient; 

        public Settings () 
        {
            ReadXML();
        }

        public void GetData(out Dictionary<string, int> data) // ref и out - отличные инструменты. ref - это передача по ссылке, out - вариант "отложенной инициализации"
        {

            data = new Dictionary<string, int>();
            data.Add("widthOfScreen", widthOfScreen);
            data.Add("heightOfScreen", heightOfScreen);
            data.Add("xBackgroundCooficient", xBackgroundCooficient);
            data.Add("yBackgroundCooficient", yBackgroundCooficient);
            data.Add("countOfChuncsX", countOfChuncsX);
            data.Add("countOfChuncsY", countOfChuncsY);
        }

        public void ReadXML() // Реализовал функцией, а не конструтором, ибо возмоно обновление на лету и придется функцию вызывать заново
        {
            /*
                
            */

            // TODO - реализовать работу с конфигурационными файлами
            countOfChuncsX = widthOfScreen / xBackgroundCooficient;
            countOfChuncsY = heightOfScreen / yBackgroundCooficient; 
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
