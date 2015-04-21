using System;

namespace DRush
{
#if WINDOWS || XBOX
    static class Program
    {
        static void Main(string[] args)
        {
            using (MainMenu main = new MainMenu())
            {
                main.Run();

                /*
                 * Иерархия наследования
                 * 
                 * Итого если коротко - Класс Program на самом верху, вызывает класс Главное меню
                 * Затем идет класс MainMenu (Главное меню), который сейчас вызвает Game (игра), но в будущем будет вызывать Settings (настройки), мультиплеер и тд
                 * Класс (Game) (игра), в котором все GameObject-ы (игровые объекты) и генерирутся. Кроме того вызывается BackgroundGeneration (создание фона)
                 * Потом есть класс GameObject (игровой объект), от которого уже наследуются все объекты
                 * И наконце идут игровые объекты - Dragon (дракон), Archer (лучник), Swordsman (мечник)
                 * 
                 * Program -> MainMenu
                 * MainMenu -> Game, Settings
                 * Game -> GameObject, BackgroundGeneration
                 * GameObject -> Dragon, Archer etc.
                 *
                 */

            }
        }
    }
#endif
}

