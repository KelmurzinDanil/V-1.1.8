using DB_993.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_993.Classes
{
    internal class PasswordEnter : IEditInput
    {
        public void ProcessingText(KeyPressEventArgs e) 
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

    }
}
