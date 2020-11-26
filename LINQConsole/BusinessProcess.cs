using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LINQConsole
{
    //1. dichiaro il delegate
    public delegate void ProcessStarted();
    public delegate void ProcessCompleted(int duration);

    //public delegate void BusinessProcessEvent(int value);
    public class BusinessProcess
    {
        //2. dichiaro l'evento
        public event ProcessStarted Started; //dichiaro l'evento con la stessa firma del delegate
        public event ProcessCompleted Completed;

        //public event BuisnessProcessEvent Started;
        //public event BuisnessProcessEvent Completed;

        public event EventHandler StartedCore; //utilizzo un delegate già pronto che ha due parametri in input

        public event EventHandler<ProcessEndEventArgs> CompletedCore; //nel generics metto una classe che eredita da eventargs: il generics mi serve per fire il tipo del secondo parametro che passo

        public void ProcessData()
        {
            Console.WriteLine("---Starting Process---");
            Thread.Sleep(2000);
            Console.WriteLine("---Process started---");

            //3. sollevo l'evento
            if(Started!=null)
                Started();
            if (StartedCore != null)
                StartedCore(this, new EventArgs()); //oppure EventArgs.Empty--> voglio utilizzare il delagate EventHandler ma non ho parametri da passargli
            Thread.Sleep(3000);

            Console.WriteLine("---Process completed---");
            //3 sollevo l'ebvento
            if (Completed!=null)
            {
                Completed(5000);
            }
            if (CompletedCore != null)
                CompletedCore(this, new ProcessEndEventArgs { Duration = 4500 }); //this si riferisce all'instanza di esecuzione, alla classe stessa
            
        }
    }

    public class ProcessEndEventArgs:EventArgs //mi serve per passare i parametri
    {
        public int Duration { get; set; }
    }
}
