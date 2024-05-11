using DB_993.Interfaces;

namespace DB_993.Classes
{
    internal class FalseText : IEditInput
    {
        public void ProcessingText(KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '@' && e.KeyChar != '.'
            && !char.GetUnicodeCategory(e.KeyChar).Equals(System.Globalization.UnicodeCategory.LowercaseLetter)
            && !char.GetUnicodeCategory(e.KeyChar).Equals(System.Globalization.UnicodeCategory.UppercaseLetter))
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar >= 'А' && e.KeyChar <= 'я')
                {
                    e.Handled = true;
                }
            }
        }
    }
}
