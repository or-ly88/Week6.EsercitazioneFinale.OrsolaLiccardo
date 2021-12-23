using System;

namespace Week6.EsercitazioneFinale.OrsolaLiccardo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("==== DEMO CONNECTION MODE");
            AdoConnected.ConnectionDemo();
            AdoConnected.InsertDemo();
            AdoConnected.InsertWithParameter();

            Console.WriteLine("=== ADO DISCONNECTED ===");
            // AdoDisconnected.InsertRowDemo();
             //AdoDisconnected.FillDataSet();
            // AdoDisconnected.UpdateRowDemo();
             AdoDisconnected.DeleteRowDemo();
            // AdoDisconnected.FillDataSet();
            // AdoDisconnected.MultipleSelectDemo();
            // AdoDisconnected.ConcorrenzaOttimistica();






        }
    }

}


