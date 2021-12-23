using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.EsercitazioneFinale.OrsolaLiccardo.Entities
{
    internal class QueryLinq
    {

        static void Main(string[] args)
        {
            //QuerySyntax();
            LambdaSyntax();
            //DeferredExecution();
            //ImmediateExecution();

        }

        #region DATA
        public static List<Spesa> GetSpesa()
        {
            var spesa = new List<Spesa>();
            {
                new Spesa()
                {
                    Id = 1,
                    Date = new DateTime(2021, 09, 07),
                    Descrizione = "Rata Auto",
                    Utente = "Chiara Rossi",
                    Importo = 230.70m,
                    Approvata = false,
                    Categoria = "Finanziamento"

                };
                new Spesa()
                {
                    Id = 2,
                    Date = new DateTime(2021, 12, 08),
                    Descrizione = "Rata Casa",
                    Utente = "Valeria Coppi",
                    Importo = 500.50m,
                    Approvata = true,
                    Categoria = "Finanziamento"

                };
                new Spesa()
                {
                    Id = 3,
                    Date = new DateTime(2021, 12, 07),
                    Descrizione = "Shopping Zara",
                    Utente = "Chiara Rossi",
                    Importo = 80.70m,
                    Approvata = true,
                    Categoria = "Shopping"

                };


            };
            return Spesa();
        }





        #endregion

        public static void LambdaSyntax()
        {
            var importo = GetSpesa();


            //spese  con importo maggiore di 100
            var importoOver100 = importo.Where(x => x.Importo >= 100);
            //  .Select(x => x.Importo);
            foreach (var item in importoOver100)
            {
                Console.WriteLine($"{item.Id}-{item.Descrizione}-{item.Importo}");

            }


        }

    }
}

