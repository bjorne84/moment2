using System;
using static System.Console;

namespace moment2
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Ange ditt födelsedatum för att få reda på vilken veckodag du är född!");
            WriteLine("Format: YYYY-MM-DD, skriv in här och tryck på enter!");
            string inputDate = ReadLine();
            DateTime dateValue;

            if (DateTime.TryParse(inputDate, out dateValue) == false)
            {
                WriteLine($"Det går inte att konvertera {inputDate}, till ett datum!");
                WriteLine("Prova igen med följande format. yyyy-mm-dd");
            }
            // harvest data fråm dateValue           
            int year = dateValue.Year;
            int month = dateValue.Month;
            int day = dateValue.Day;
   
            // split year anmd get decade and year in doubeldigit
            // part influenced by https://www.codeproject.com/Questions/1081689/How-do-i-split-my-my-string-in-equal-half-and-stor 
            string tempString = year.ToString();
            var first = tempString.Substring(0, (int)(tempString.Length / 2));
            var last = tempString.Substring((int)(tempString.Length / 2), (int)(tempString.Length / 2));
            // end influenced part

            //convert dacade and year to int32
            int century = Int32.Parse(first);
            int year2 = Int32.Parse(last);
   
       
            // test for leap years and adjust values if so
            if (month<3)
            {
                month = month + 12;
                year2 = year2 - 1;

            }
            // WriteLine($"test av skottår efter if, månad: {month} och år: {year2}");

            /* *****************************************
             * *******Zeller´s Algorithm start *********
             * ******************************************/

            // Convert to double
            double dMonth = Convert.ToDouble(month);
            double dYear2 = Convert.ToDouble(year2);
            double dCentury = Convert.ToDouble(century);

            // Month (2.6 * month - 5.39)
            double fMonth = Math.Floor((2.6 * dMonth - 5.39));

            // Year/4
            double fYear2 = Math.Floor((dYear2/4));
     
            // century
            double fCentury = Math.Floor((dCentury / 4));

            // Add Floor with day and year from input
            double result = ((fMonth + fYear2 + fCentury + day +year2) + (-century*2));
            // modulus 7 of result
            double ISOnumber = result % 7;


            // Translate  ISO 8601 week numbers to mounth 
            switch (ISOnumber)
            {
                case 1:
                    WriteLine("Du föddes på en Måndag");
                    break;
                case 2:
                    WriteLine("Du föddes på en Tisdag");
                    break;
                case 3:
                    WriteLine("Du föddes på en Onsdag");
                    break;
                case 4:
                    WriteLine("Du föddes på en Torsdag");
                    break;
                case 5:
                    WriteLine("Du föddes på en Fredag");
                    break;
                case 6:
                    WriteLine("Du föddes på en Lördag");
                    break;
                case 7:
                    WriteLine("Du föddes på en Söndag");
                    break;

            }

        }
    }
}
