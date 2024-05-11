using DB_993.Interfaces;
using System.Text.RegularExpressions;

namespace DB_993.Classes
{
    /// <summary>
    /// Класс содержит методы для обработки ввода текста в текстовых полях, 
    /// предназначенных для ввода пароля и текста, с ограничениями на допустимые символы.
    /// </summary>
    public class PatternLogin : IPattern
    {
        public PatternLogin() { }
        public bool CheckPattern(string email)
        {
            string pattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";

            var regex = new Regex(pattern);

            return regex.IsMatch(email);
        }

    }
}
