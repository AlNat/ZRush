using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DRush
{
    class MenuItem
    {
        /// <summary>
        /// Класс пункт меню
        /// Используется для отрисовки пунктов в меню
        /// </summary>

        public string Name { get; set; } // Имя
        public bool Active { get; set; } // Активен\неактивен

        public event EventHandler Click;

        public MenuItem (string inputName) 
        {
            /// Конструктор
            /// Принимает имя
            this.Name = inputName;
            Active = true;
        }

        public void OnClick()
        {
            if (Click != null)
            {
                Click(this, null);
            }
        }
    }
}
