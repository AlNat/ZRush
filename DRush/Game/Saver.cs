using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Microsoft.Xna.Framework;

namespace DRush
{
    public class Saver
    {

        // Все данные для сохранения
        public int[,] background; //
        public List<Swordsman> enemies; // Список противников
        public Dragon dragon; // Дракон

        private Dictionary<string, int> coonfig; // Список настроек
        private Settings settings; 

        public Saver()
        {
            // Получили данные настроек
            settings = new Settings();
            settings.GetData(out coonfig);

            background = new int[coonfig["countOfChuncsX"], coonfig["countOfChuncsY"]]; // Инициализировали фон

        }

        public void Save (Dragon dg, List<Swordsman> sw, int[,]bc) 
        {
            // Принимать дракона, лист противников, фон.
            SaveBackground(bc);
            SaveEnemies(sw);
            SaveDragon(dg);
            WriteSave();
        }

        public void Load(ref Dragon playerDragon, ref List<Swordsman> en, ref int[,] back) // Будем принимать по ссылке все данные и изменять их
        {
            // МОЯ ЛЮБИМАЯ ПРОБЛЕМА - НИХРЕНА НЕ СОЗДАЕТСЯ ИГРОВЫЕ ОБЕТЫ
            dragon = playerDragon;
            enemies = en;

            ReadSave(); // Считали из файла

            // Отдали значения наружу
            playerDragon = dragon;
            en = enemies;
            back = background;
        }


        private void SaveBackground (int [,] back)
        {
            background = back;
        }
        private void SaveEnemies(List<Swordsman> sword)
        {
            enemies = new List<Swordsman>(sword); // Скопировали данные
        }
        private void SaveDragon(Dragon drg)
        {
            dragon = drg; // Скопировали дракона
        }


        private void ReadSave()
        {
            // Читаем из xml файла
            string inputAttribute;
            XDocument xmlSettings = XDocument.Load("save.xml"); // Открыли доумент
            int xt, yt; // Темпы 
            
            inputAttribute = xmlSettings.Element("Data").Element("Enemies").Attribute("count").Value;
            int maxCount = Convert.ToInt32(inputAttribute);
            //enemies = new List<Swordsman>(en);
            //dragon = playerDragon;

            // Читаем и пишем массив координат объектов
            for (int count = 0; count < maxCount - 1; count++)
            {

                string t = Convert.ToString(count + 1);
                Console.WriteLine("Swordsman"+t);
                inputAttribute = xmlSettings.Element("Data").Element("Enemies").Element("Swordsman" + t).Attribute("xPosition").Value;
                xt = Convert.ToInt32(inputAttribute);

                inputAttribute = xmlSettings.Element("Data").Element("Enemies").Element("Swordsman" + t).Attribute("yPosition").Value;
                yt = Convert.ToInt32(inputAttribute);
                enemies[count+1].SetToStart(xt, yt); // Изменили объект
            }

            // Читаем данные дракона
            inputAttribute = xmlSettings.Element("Data").Element("Dragon").Element("dragon").Attribute("xPosition").Value;
            xt = Convert.ToInt32(inputAttribute);
            inputAttribute = xmlSettings.Element("Data").Element("Dragon").Element("dragon").Attribute("yPosition").Value;
            yt = Convert.ToInt32(inputAttribute);
            dragon.Sett(xt, yt);// = new Vector2(xt, yt);

            // Читаем данные фона
            inputAttribute = xmlSettings.Element("Data").Element("Background").Element("count").Attribute("x").Value;
            int maxX = Convert.ToInt32(inputAttribute);
            inputAttribute = xmlSettings.Element("Data").Element("Background").Element("count").Attribute("y").Value;
            int maxY = Convert.ToInt32(inputAttribute);

            for (int t1 = 0; t1 < maxX; t1++)
            {
                string t = Convert.ToString(t1 + 1);
                for (int t2 = 0; t2 < maxY; t2++)
                {
                    // Считали данные и записали
                    string tt = Convert.ToString(t2 + 1);
                    inputAttribute = xmlSettings.Element("Data").Element("Background").Element("x" + t).Attribute("y" + tt).Value;
                    background[t1, t2] = Convert.ToInt32(inputAttribute);
                    /// НЕ УСТАЮ ХВАЛИТЬ СТРОКОВЫЕ КОНКАТЕНАЦИИ

                /// ТУТ БАГ = двумерные массивы не особо в C#
                }
            }
        }

        private void WriteSave()
        {
            // Пишем в xml все данные


        }

    }
}
