using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace seriesProject
{
    internal class Program
    {
        // data
        List<int> series = new List<int>();
        List<int> sortedList = new List<int>();
        List<int> emptyList = new List<int>() { 0};
        bool sorted = false;
        int theLen; 
        Dictionary<string, string> menuData = new Dictionary<string, string>()
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
            string input = Console.ReadLine();
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


        void Start()
        {

            // מתחילה את התוכנית - קולטת קלט ושולחת הלאה
            sorted = false;
            string input = Input("enter a series of numbers" +
                "(Numbers separated by spaces)");
            
            validation(input);
        }

        

        // פונקציות חיצוניות

        void validation(string input)
        {
            /* תיאור: מוודאת שהקלט תקין
            * פירוט:
            * data:
            * 1 = משתנה בולייאן האם תקין
            * 2 = משתנה מספר שמחזיק את אורך הרשימה 
            * 
            * פעולות:
            * 1 הופכת לרשימה לפי הרווחים
            * 2 מוודאת שהאורך תקין
            * או שווה ל3
            * 3 = רצה על הרשימה בלולאת ווייל עד אורך הרשימה
            *   וכל עוד הבולייאן טרו
            *   הבולייאן משתנה אם קיים מינוס או זהו איננו מספר
            * 4 = אם המשתנה תקין שולחת הלאה, אם לא
            *  קוראת לפונקציה הראשונה
           */

            List<string> seriesString = new List<string>(input.Split(" "));
            bool proper = true;
            theLen = seriesString.Count;
            int i = 0;

            if (theLen < 3)
            {
                proper = false;

            }
            else
            {
                while (i < theLen && proper)
                {
                    foreach (char c in seriesString[i])
                    {
                        if (!(char.IsDigit(c)) || (c == '-'))
                        {
                            proper = false;
                            break;
                        }
                    }
                    i++;
                }
            }
            if (proper)
            {
                ListOfInt(seriesString);
            }
            else
            {
                ErroreMeassge("You are entering numbers separated by a space.");
                Start();
            }



           
        }

        void ListOfInt(List<string> properInput)
        {
            /* תיאור: הופכת לרשימה של מספרים 
             * ומעדכנת את "TheSeries"
             * 
             */

            foreach(string number in properInput)
            {
                series.Add(int.Parse(number));
            }
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
            foreach (KeyValuePair <string, string> pair in menuData)
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
            List<int> theObject = new List<int>();
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

       void Print(List<int> theObject)
        {
            foreach (int i in theObject)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n");

        }

       void PrintReverse()
        {
            for (int i = theLen - 1; i >= 0; i--)
            {
                Console.Write(series[i] + " ");
            }
            Console.WriteLine("\n");

        }

        List<int> Sorts()
        {
            if (!sorted)
            {
                sorted = true;
                sortedList = new List<int>(series);
                sortedList.Sort();
            }
            else
            {
                RaningTimeSavings("n*n");
            }
            return sortedList;

        }

        List<int> Max()
        {
            int max = series[0];
            if (sorted)
            {

                emptyList[0] = sortedList[theLen - 1];
                RaningTimeSavings("n");
            }
            else
            {
                foreach (int i in series)
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

        List<int> Min()
        {
            int min = series[0];
            if (sorted)
            {
                emptyList[0] = sortedList[0];
                RaningTimeSavings("n");

            }
            else
            {
                foreach (int i in series)
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

        List<int> Avrerage()
        {
            int average =  Sum()[0] / Len()[0];
            emptyList[0] = average;
            return emptyList;

        }

        List<int> Len()
        {
            int len = 0;
            foreach (int i in series)
            {
                len++;
            }
            emptyList[0] = len;
            return emptyList;

        }

        List<int> Sum()
        {
            int sum = 0;
            foreach (int i in series)
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

