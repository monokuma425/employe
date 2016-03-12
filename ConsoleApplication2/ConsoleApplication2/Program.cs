using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new StreamReader(@"C:\Users\User\Desktop\input_data\DATA (1).csv");
            

            string str;
            List<Employe> myList = new List<Employe>();
            while (!reader.EndOfStream) //Цикл длиться пока не будет достигнут конец файла
            {
                str = reader.ReadLine(); //В переменную str по строчно записываем содержимое файла
                var values = str.Split(',');
                
                var isHourlyWages = values[4] == "true";
                var fName = values[1];
                var lName = values[2];
                var wage = double.Parse(values[3].Replace('.',','));

                

                Employe employe;
                if (isHourlyWages)
                    employe = new HourlyEmploye(fName, lName, wage);
                else
                    employe = new AlwaysEmploye(fName, lName, wage);
                myList.Add(employe);

            }
            myList = myList.OrderBy(e => e.CalcAvgWage()).ToList();

            reader.Close();
            var writer = new StreamWriter(@"C:\Users\User\Desktop\input_data\output.csv");
            foreach (Employe i in myList)
                writer.WriteLine("{1} {0}, {2}", i.Name, i.LastName, i.CalcAvgWage());
            writer.Close();
        }
    }
}
