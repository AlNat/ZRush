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
                 * Итого если коротко - Класс Program на самом верху, вызывает класс игра
                 * Затем идет класс MainMenu (игра), который сейчас вызвает Game (игра), но в будущем будет вызывать Settings (настройки), мультиплеер и тд
                 * Класс (Game) (игра), в котором все GameObject-ы (игровые объекты) и генерирутся
                 * Потом есть класс GameObject (игровой объект), от которого уже наследуются все объекты
                 * И наконце идут игровые объекты - Dragon (дракон)
                 * 
                 * Program -> MainMenu
                 * MainMenu -> Game, Settings
                 * Game -> GameObject
                 * GameObject -> Dragon, Archer etc.
                 *
                 */

            }
        }
    }
#endif
}

