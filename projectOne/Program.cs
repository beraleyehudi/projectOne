using System;
using System.Collections.Generic;
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
        Dictionary<string, string> menu = new Dictionary<string, string>();

        // פונקציות עזר

        string Input(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();
            return input;
        }

        void ErroreMeassge(string s)
        {

        }


        string Start()
        {

            // מתחילה את התוכנית - קולטת קלט ושולחת הלאה

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
            int len = Len(seriesString);
            int i = 0;

            if (len < 3)
            {
                proper = false;

            }
            else
            {
                while (i < len && proper)
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
                ErroreMeassge("");
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
            foreach (KeyValuePair <string, string> pair in menu)
                {
                    Console.WriteLine($"{pair.Key}. {pair.Value}");
                }
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


        }

        // פונקציות פנימיות

       void Print()
        {

        }

       void PrintReverse()
        {

        }

        void Sort()
        {

        }

        void Max()
        {

        }

        void Min()
        {

        }

        void Avrerage()
        {

        }
         
        void Len()
        {

        }

        void Sum()
        {

        }


        static void Main(string[] args)
        {
            Start();


        }
    }
}

