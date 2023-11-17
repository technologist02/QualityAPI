using Quality2.Entities;
using Quality2.Exceptions;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Quality2.IRepository
{
    public interface IUser
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }

    public static class IUserExtansions
    {
        public static bool Validate(this IUser user)
        {
            var patternLogin = @"^[a-zA-Z][\w]*[a-zA-Z0-9]$";
            var patternName = "^[A-Z][a-zA-Z]*$|^[А-Я][а-яА-Я]*$";
            var patternEmail = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
            var errors = new List<string>();
            if (!Regex.IsMatch(user.Login, patternLogin, RegexOptions.IgnoreCase))
            {
                errors.Add("Логин может содержать только буквы a-Z, символ \"_\", и цифры");
            }
            if (!Regex.IsMatch(user.Email, patternEmail, RegexOptions.IgnoreCase))
            {
                errors.Add("Некорректный формат Email");
            }
            if (!string.IsNullOrEmpty(user.Name) && !Regex.IsMatch(user.Name, patternName, RegexOptions.IgnoreCase))
            {
                errors.Add("Имя может содержать только буквы");
            }
            if (!string.IsNullOrEmpty(user.Surname) && !Regex.IsMatch(user.Surname, patternName, RegexOptions.IgnoreCase))
            {
                errors.Add("Фамилия может содержать только буквы");
            }
            if (errors.Count > 0)
            {
                throw new BadRequestException(string.Join('\n', errors));
            }
            return true;
        }
    }
}
