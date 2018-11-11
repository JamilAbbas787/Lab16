using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab16
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the Countries Maintence Application!");


            while (true)
            {

                var userSelectionApp = new CountriesApp();
                var userSelection = userSelectionApp.PickCountry();

                if (!Validation.SelectionValidation(userSelection))
                {
                    Console.WriteLine("Enter a number 1-3");
                    continue;
                }
                else if (Validation.SelectionValidation(userSelection) && userSelection == "1")
                {
                    CountriesTextFile.WriteCountries();
                    CountriesTextFile.ReadCountries();
                }
                else if (Validation.SelectionValidation(userSelection) && userSelection == "2")
                {
                    CountriesTextFile.AddCountry();

                }
                else if (Validation.SelectionValidation(userSelection) && userSelection == "3")
                {
                    break;

                }

            }

            Console.ReadKey();

        }
    }


    class Validation
    {
        public static bool SelectionValidation(string userEntry)
        {
            if (userEntry == "1" || userEntry == "2" || userEntry == "3")
            {
                return true;
            }

            return false;
        }

    }

    class CountriesTextFile
    {
        private static string _filePath = @"C:\Users\jamil\Desktop\GrandCircus\Lab16";
        private static string _fileName = "Countries.txt";
        private static string _file = Path.Combine(_filePath, _fileName);


        public static void ReadCountries()
        {

            using (var reader = new StreamReader(_file))
            {

                string line;
                do
                {
                    line = reader.ReadLine();
                    Console.WriteLine(line);
                } while (line != null);

            }

        }
        public static void WriteCountries()
        {
            using (var writer = new StreamWriter(_file))
            {
                writer.WriteLine("USA");
                writer.WriteLine("Canada");
                writer.WriteLine("Lebanon");
            }
        }

        public static string AddCountry()
        {
            Console.WriteLine("Enter a country name:  ");
            string newCountry = Console.ReadLine();
            using (var writer = new StreamWriter(_file))
            {
                writer.WriteLine(newCountry);
            }


        }

    }


    class CountriesApp
    {
        public string PickCountry()
        {
            string menuOptions = "1 - See the list of countries \n" +
                "2 - Add a country \n" +
                "3 - Exit";
            Console.WriteLine(menuOptions);
            string userSelection = Console.ReadLine();
            return userSelection;
        }

    }

}


