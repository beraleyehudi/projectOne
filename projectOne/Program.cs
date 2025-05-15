using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace seriesProject
{
    internal class Program
    {
        // data
        List<double> series = new List<double>(); // כאן נשמרת סדרת המספרים

        List<double> sortedList = new List<double>(); // כאן נשמרת הרשימה הממויינת - לחסוך זמן ריצה

        bool sorted = false; // כך אדע האם המשתמש כבר ביקש למיין

        List<double> emptyList = new List<double>() { 0 }; // אינו נצרך - אך רציתי לחסוך כתיבת שורות - באמצעות משתנה זה
        // פונקציית manage מבצעת קריאה אחת להדפסה

        int theLen; // כיוון שפונקציית האימות צריכה לוודא את האורך - העדפתי להשתמש במה שהיא מפיקה ולא ליצור פונקציית אורך שתרוץ אן פעמים

        Dictionary<string, string> menuData = new Dictionary<string, string>() // לולאת התפריט תעבור על המילון ותציג את האופציות
        {
            {"1", "Switch series"},
            {"2",  "print"},
            {"3", "print reverse" },
            {"4", "print sorted series" },
            {"5",  "find max number"},
            {"6", "find min number" },
            {"7", "average" },
            {"8", "lengh" },
            {"9", "sum" },
            {"10", "exit from the program" }
        };


        // פונקציות עזר


        string Input(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("\n");
            string input = Console.ReadLine();
            Console.WriteLine("\n");
            return input;
        }

        void ErroreMeassge(string specificlyMeassage)
        {
            Console.WriteLine($"Incorrect input \n Please note that {specificlyMeassage}");

        }

        void RaningTimeSavings(string ranTime)
        {
            Console.WriteLine($"Thanks to our sophisticated system, we save you {ranTime} running time.");
        }




        // פונקציות חיצוניות


        void Start()
        {

            // מתחילה את התוכנית - קולטת קלט ושולחת הלאה
            sorted = false;
            string input = Input("enter a series of numbers" +
                "(Numbers separated by spaces)");

            Validation(input);
        }

        void Validation(string input)
        {
            int len = 0;
            string[] listOfInput = input.Split();

            foreach (string s in listOfInput)
            {
                if (double.TryParse(s, out double number) && number > 0)
                {
                    len++;
                    ListOfNumbers(number);

                }
                else if (s == " ")
                {
                    continue;
                }

                else
                {
                    ErroreMeassge("You are entering numbers separated by a space.");
                    Start();
                }

            }

            theLen = len;
            if (theLen < 3)
            {
                ErroreMeassge("you enter least 3 numbers");
                Start();
            }
        }

        void ListOfNumbers(double number)
        {
            /* תיאור: הופכת לרשימה של מספרים 
             * מעדכנת את "series"
             
             */


            series.Add(number);

            Menu();



        }

        void Menu()
        {
            /* תיאור: מציגה את התפריט
             * data:
             * מילון התפריט
             * פעולה:
             * רצה על המילון "menu" ומדפיסה למשתמש
             * וקוראת לפונקציה הבאה
             */
            foreach (KeyValuePair<string, string> pair in menuData)
            {
                Console.WriteLine($"{pair.Key}. {pair.Value}");
            }
            Manage();
        }

        void Manage()
        {

            /* תיאור: מנהלת ושולחת לכל פונקציה 
             * לפי בחירת המשתמש
             * data:
             * theSirius
             * bool exit = false
             * 
             * פעולות:
             * קולטת מהמשתמש
             * אם הקליטה אינה טובה מציגה הודעת 
             * שגיאה
             * בסוף הפונקציה קוראת לפונקציית התפריט
             * אלא אם אקסיט
             */
            string input = Input("type your chiose \n");
            Console.WriteLine("\n \n");
            List<double> theObject = new List<double>();
            bool exit = false;

            switch (input)
            {
                case "1":
                    Start();
                    break;

                case "2":
                    Print(series);
                    break;

                case "3":
                    PrintReverse();
                    break;

                case "4":
                    theObject = Sorts();
                    break;

                case "5":
                    theObject = Max();
                    break;

                case "6":
                    theObject = Min();
                    break;

                case "7":
                    theObject = Avrerage();
                    break;

                case "8":
                    theObject = Len();
                    break;

                case "9":
                    theObject = Sum();
                    break;

                case "10":
                    exit = true;
                    break;

                default:
                    ErroreMeassge("Enter a number between 1 and 10.");
                    Menu();
                    break;
            }
            if (!exit)
            {
                if (input != "2")
                {
                    Print(theObject);

                }
                Menu();
            }
            else
            {
                Console.WriteLine("היה כיף אח שלי");
            }



        }









        // פונקציות פנימיות

        void Print(List<double> theObject)
        {
            foreach (double i in theObject)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n \n");

        }

        void PrintReverse()
        {
            for (int i = theLen - 1; i >= 0; i--)
            {
                Console.Write(series[i] + " ");
            }
            Console.WriteLine("\n");

        }

        List<double> Sorts()
        {
            if (!sorted)
            {
                sorted = true;
                sortedList = series;
                sortedList.Sort();
            }
            else
            {
                RaningTimeSavings("n*n");
            }
            return sortedList;

        }

        List<double> Max()
        {
            double max = series[0];
            if (sorted)
            {

                emptyList[0] = sortedList[theLen - 1];
                RaningTimeSavings("n");
            }
            else
            {
                foreach (double i in series)
                {
                    if (i > max)
                    {
                        max = i;
                    }
                }

                emptyList[0] = max;
            }
            return emptyList;

        }

        List<double> Min()
        {
            double min = series[0];
            if (sorted)
            {
                emptyList[0] = sortedList[0];
                RaningTimeSavings("n");

            }
            else
            {
                foreach (double i in series)
                {
                    if (i < min)
                    {
                        min = i;

                    }
                }
                emptyList[0] = min;
            }
            return emptyList;


        }

        List<double> Avrerage()
        {
            double average = Sum()[0] / Len()[0];
            emptyList[0] = average;
            return emptyList;

        }

        List<double> Len()
        {

            emptyList[0] = theLen;
            return emptyList;

        }

        List<double> Sum()
        {
            double sum = 0;
            foreach (double i in series)
            {
                sum += i;
            }
            emptyList[0] = sum;
            return emptyList;

        }


        static void Main(string[] args)
        {
            new Program().Start();



        }
    }
}

