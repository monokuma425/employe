using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
   abstract class Employe
    {
        public string Name;
        public string LastName;
        public double Wage;
       
       public abstract double CalcAvgWage();
        
       public Employe(string Name, string LastName, double Wage)
        {
            this.Name = Name;
            this.LastName = LastName;
            this.Wage = Wage;
        }
    }

    class HourlyEmploye:Employe
    {
        public HourlyEmploye(string Name, string LastName, double Wage)
            : base(Name, LastName, Wage)
        {

        }

        public override double CalcAvgWage()
        {
            return (20.8 * 8 * Wage);
        }
    }

    class AlwaysEmploye:Employe
    {
        public AlwaysEmploye(string Name, string LastName, double Wage)
            : base(Name, LastName, Wage)
        {

        }

        public override double CalcAvgWage()
        {
            return Wage;
        }
    }
}

