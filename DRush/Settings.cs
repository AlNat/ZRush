using System;

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

        public void GetData(ref int[] data) // ref и out - отличные инструменты.
        {
            // Вернули значения коофициентов
            data[0] = widthOfScreen; // 0
            data[1] = heightOfScreen; // 1
            data[2] = xBackgroundCooficient; // 2
            data[3] = yBackgroundCooficient; // 3
            data[4] = countOfChuncsX; // 4
            data[5] = countOfChuncsY; // 5
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
