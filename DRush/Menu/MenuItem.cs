using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DRush
{
    class MenuItem
    {

        public string Name { get; set; } // Имя
        public bool Active { get; set; } // Активен\неактивен

        public event EventHandler Click;

        public MenuItem (string inputName) 
        {
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
