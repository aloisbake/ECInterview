using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Question1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*********    Password Validator Appliccation   ************");
            bool result = false;
            var ErrorMsg = string.Empty;

            while (!result)
            {
                Console.WriteLine("Enter Passord");
                var password = Console.ReadLine();
                result = ValidatePassword(password, out ErrorMsg);
                if (result)
                {
                    Console.WriteLine("Congradulations !!!! Your password meets the basic requirements");
                }
                else {
                    Console.WriteLine(ErrorMsg);
                }
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        static bool ValidatePassword(string password, out string ErrorMsg)
        {
            ErrorMsg = string.Empty;
            Regex checkLength = new Regex(@"(\s*(\S)\s*){6,}");
            Regex hasUpperCase = new Regex(@"[A-Z]+");
            Regex hasLowercase = new Regex(@"[a-z]+");
            Regex hasSpecialCharacters = new Regex(@"[!@#$%^&*()-+]");
            Regex hasNumber = new Regex(@"[0-9]+");

            if (!checkLength.IsMatch(password))
            {
                ErrorMsg = "Password length shoud be at least 6 characters";
                return false;
            }
            else if (!hasUpperCase.IsMatch(password))
            {
                ErrorMsg = "Password should contain at least one uppercase English character";
                return false;
            }
            else if (!hasLowercase.IsMatch(password))
            {
                ErrorMsg = "Password should contain at least one lowercase English character";
                return false;
            }
            else if (!hasNumber.IsMatch(password))
            {
                ErrorMsg = "Password should contain at least a number";
                return false;
            }
            else if (!hasSpecialCharacters.IsMatch(password))
            {
                ErrorMsg = "Password should contain at least a special character in the following list !@#$%^&*()-+";
                return false;
            }
            else
            {           
                return true;
            }
        }
    }
}
