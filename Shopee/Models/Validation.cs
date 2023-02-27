using System.Net.Mail;

namespace Shopee.Models
{
    public class Validation
    {
        public bool IsEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public bool IsNumber(string number)
        {
            foreach (Char c in number)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            if (number.Length != 10)
            {
                return false;
            }
            return true;
        }
    }
}
