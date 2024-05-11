using DB_993.Interfaces;

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
