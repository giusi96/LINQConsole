using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LINQConsole
{
    class Program
    {
        public delegate int Sum(int val1, int val2); // a sum(che è un tipo) posso associare tutte le funzioni che prendono due tipi interi e mi restituiscono un intero.

        public static int PrimaSomma(int valore1, int valore2)
        {
               return valore1+valore2;
        }

        public static int SecondaSomma(int valore1, double valore2)
        {
            return valore1 + (int)valore2;
        }

        public static void Chiamami(Sum funzioneDaChiamare)
        {
            funzioneDaChiamare(1, 2);
        }
        

        static void Main(string[] args)
        {
            #region STEP4

            List<EmployeeInt> employees = new List<EmployeeInt>
            {
                new EmployeeInt {ID=1, Name="Roberto"},
                new EmployeeInt {ID=2, Name="Alice"},
                new EmployeeInt {ID=3, Name="Mauro"},
                new EmployeeInt {ID=4, Name="Roberto"},
            };

            var result = employees.Where("ID", "1");
            var result2 = employees.Where("Name", "Roberto");





            #endregion





            #region STEP3
            //LAMBDA EXPRESSION
            //Func<int, int> lambdaZero = x => x * 2; // è la stessa di avere la funzione Mult

            //Func<int, int> lambdaZeroZero = x => { return 2 * x; };

            //Func<int, int> lambdaZeroZeroZero = Mult;

            //var list = new List<int> { 1, 2, 3, 4, 5, 6 };
            //var result = list.Where(x => x > 2);

            //Func<int, double, int> lambdaOne =(x,y)=>x * (int)y;

            //Func<int, double, bool> lambdaOne1 = (x, y) => x > (int)y;

            #endregion
            #region STEP2
            //var process = new BusinessProcess();

            ////devo ascoltare l'evento
            //process.Started += Process_Started;

            //process.Completed += Process_Completed;

            //process.StartedCore += Process_StartedCore;

            //process.ProcessData();


            Sum lamiaSomma = new Sum(PrimaSomma);
            //OPPURE
            //Sum lamiaSomma = PrimaSomma;

            Func<int, int, int> primaFunc = PrimaSomma;    //è equivalente a  public delegate int primaFunc() cha n parametri in input, e un valore di ritorno

            Action<int, int> primaAction; //delegate che ha solo n parametri di input, no di output


            //Chiamami(lamiaSomma);
            //Chiamami(PrimaSomma);
            //// Chiamami(SecondaSomma) -> non posso chiamare SecondaSomma perchè non rispetta la stessa firma
            #endregion

            #region STEP1
            //Console.WriteLine("Hello World!");

            //string firstName = "Roberto";

            //var lastName = "Rossi";

            ////using var file = new StreamWriter();

            ////List<int> data = new List<int> { 1, 2, 3, 4 };
            ////var data = new List<int> { 1, 2, 3, 4 };

            ////List<Employee> data = new List<Employee> { };
            //Employee<string> pluto = new Employee<string>();
            //Employee<int> pippo=new Employee<int>();

            ////Extension Method
            //List<Employee<int>> data = new List<Employee<int>>();

            //string example = "EXample";
            //example.ToUpper;
            //example.ToDouble;

            //foreach (var value in data)
            //{
            //    Console.WriteLine("#", value.Nome);
            //}

            //pippo.ID = 9;
#endregion
        }

        private static int Mult(int x)
        {
            return 2 * x;
        }

        private static void Process_StartedCore(object sender, EventArgs e)
        {
            Console.WriteLine("Ricevuto StartedCore");
        }

        private static void Process_Completed(int duration)
        {
            Console.WriteLine($"Process Completed: (duration:{duration})");
        }

        private static void Process_Started() //stessa firma del delegate
        {
            Console.WriteLine("Ricevuto => Processo avviato!");
        }
    }

    
    internal class Employee<T> //non generics
    {

        //altro modo: full property

        //private int _id; //campo privato
        //public int ID
        //{
        //    get
        //    {
        //        return _id;
        //    }
        //    set
        //    {
        //        if (value <= 0)
        //            throw new ArgumentException("ID must be greater than 0");
        //        _id = value;
        //    }
        //}
        public T ID { get; set; }
        public string Name { get; set; }
    }

    //avrei dovuto fare due classi se avesssi dovuto distringuere ID per int e string
    internal class EmployeeInt 
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    internal class EmployeeString
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }
}
