using System;
using System.Collections.Generic;

using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;


namespace DRush
{
    class Settings
    {
        /// Класс настроек - прокси между файлами и другими частями приложения

        // Разрешение экрана
        int widthOfScreen;
        int heightOfScreen;

        // Коофициент для формул 
        int xBackgroundCooficient;
        int yBackgroundCooficient;

        // Кол-во чанков(блоков) 
        static int countOfChuncsX;
        static int countOfChuncsY;

        bool updateFlag; // Флаг обновления

        public Settings()
        {
            /// Конструктор

            ReadXML(); 
        }

        public void GetData(out Dictionary<string, int> data) 
        {
            /// Функция для передачи данных
            /// Отдает словарь с настройками

            // ref и out - отличные инструменты. ref - это передача по ссылке, out - вариант "отложенной инициализации"
            data = new Dictionary<string, int>();
            data.Add("widthOfScreen", widthOfScreen);
            data.Add("heightOfScreen", heightOfScreen);
            data.Add("xBackgroundCooficient", xBackgroundCooficient);
            data.Add("yBackgroundCooficient", yBackgroundCooficient);
            data.Add("countOfChuncsX", countOfChuncsX);
            data.Add("countOfChuncsY", countOfChuncsY);
        }

        public void ReadXML() 
        {
            /// Функция чтения данных из xml файла

            string inputAttribute;
            XDocument xmlSettings = XDocument.Load("settings.xml"); // Открыли доумент

            // Парсим вручную дерево XML и читаем нуный элемент
            inputAttribute = xmlSettings.Element("Settings").Element("graphics").Element("widthOfScreen").Attribute("value").Value;
            widthOfScreen = Convert.ToInt32(inputAttribute);
            // Это эквавалентно строчке widthOfScreen = Convert.ToInt32( xmlSettings.Element("Settings").Element("graphics").Element("widthOfScreen").Attribute("value").Value );
            // Но слишком сложно читать да и вообще...

            inputAttribute = xmlSettings.Element("Settings").Element("graphics").Element("heightOfScreen").Attribute("value").Value;
            heightOfScreen = Convert.ToInt32(inputAttribute);

            inputAttribute = xmlSettings.Element("Settings").Element("graphics").Element("xBackgroundCooficient").Attribute("value").Value;
            xBackgroundCooficient = Convert.ToInt32(inputAttribute);

            inputAttribute = xmlSettings.Element("Settings").Element("graphics").Element("yBackgroundCooficient").Attribute("value").Value;
            yBackgroundCooficient = Convert.ToInt32(inputAttribute);

            countOfChuncsX = widthOfScreen / xBackgroundCooficient;
            countOfChuncsY = heightOfScreen / yBackgroundCooficient;

            updateFlag = true;
        }

        public void WriteXML(ref Dictionary<string, int> data)
        {
            // TODO
            // Вызываем его, когда игро вызвал настройки и изменил их
            // Принимаем словарь настроек и записываем их

            updateFlag = true;
        }

        public void Change()
        {
            // TODO
            // Фунция для изменения пользователем.
            updateFlag = true;
        }

        public bool wasUpdate()
        { 
            // Геттер флага обновления
            return updateFlag;
        }

        public void Update()
        { 
            // При вызове обновления читаем файл и обновляем флаг
            ReadXML();
            updateFlag = false;
        }
    }
}
