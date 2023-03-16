using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePojistenych
{
    internal class Evidence
    {
        /// <summary>
        /// Propojení s třídou "PojisteneOsoby.cs"
        /// </summary>
        private PojisteneOsoby pojisteneOsoby;

        /// <summary>
        /// 
        /// </summary>
        public Evidence()
        {
            pojisteneOsoby = new PojisteneOsoby();
        }

        /// <summary>
        /// Vypíše úvodní obrazovku včetně aktuálního data a času
        /// </summary>
        public void VypisUvodniObrazovku()
        {
            Console.Clear();
            Console.WriteLine("---------------------------\nEVIDENCE POJIŠTĚNÝCH\n---------------------------\n");
            Console.WriteLine("Dnes je: {0}\n", DateTime.Now);
        }

        /// <summary>
        /// CASE 1 - přidá nového pojištěnce na základě uživatelského vstupu
        /// jmeno, prijmeni - projdou pouze abecední znaky. Neprojdou prázdné znaky, Enter, čísla.
        /// vek - projde pouze číslo od 1 do 99.Neprojdou abecední znaky, prádné znaky, Enter.
        /// telefon - projde pouze 9 číslic. Neprojdou abecední znaky, prázdné znaky, Enter.
        /// </summary>
        public void PridejPojisteneho()
        {
            Console.WriteLine("\nZadejte jméno pojištěného: ");
            string jmeno;
       
            while (string.IsNullOrWhiteSpace(jmeno = Console.ReadLine().Trim()) || jmeno.All(char.IsLetter) == false)
            {
                Console.WriteLine("Zadejte znovu");
            }

            Console.WriteLine("Zadejte příjmení pojištěného: ");
            string prijmeni;
            while (string.IsNullOrWhiteSpace(prijmeni = Console.ReadLine().Trim()) || prijmeni.All(char.IsLetter) == false)
            {
                Console.WriteLine("Zadejte znovu");
            }

            Console.WriteLine("Zadejte věk pojištěného: ");
            int vek;
            while (!int.TryParse(Console.ReadLine(), out vek) || vek <= 0 || vek >= 100)
            {
                Console.WriteLine("Zadejte znovu");
            }
            
            Console.WriteLine("Zadejte telefon pojištěného: ");
            string telefon;
            while (string.IsNullOrWhiteSpace(telefon = Console.ReadLine().Trim()) || telefon.All(char.IsDigit) == false || telefon.Length != 9)
            {
                Console.WriteLine("Zadejte znovu");
            }

            pojisteneOsoby.PridejOsobu(jmeno, prijmeni, vek, telefon);
            Console.WriteLine("\nPojištěný byl přidán.\n\nPokračujte klávesou ENTER");
        }


        /// <summary>
        /// CASE 2 - vypíše všehcny pojištěné pod sebe do seznamu
        /// </summary>
        public void VypisPojistene()
        {
            List<Osoba> pojistenci = pojisteneOsoby.NajdiOsoby();
            if (pojistenci.Count == 0)
            {
                Console.WriteLine("\nNejsou pojištěny žádné osoby");
            }
            else
            {
                Console.WriteLine("\nSeznam pojištěných:");
                foreach (Osoba o in pojistenci)
                    Console.WriteLine(o);
            }
            Console.WriteLine("\nPokračujte klávesou ENTER");
        }




        /// <summary>
        /// CASE 3 - vyhledá konkrétní pojištěné na základě jména nebo příjmení
        /// jmeno, prijmeni - projdou pouze abecední znaky. Neprojdou prázdné znaky, Enter, čísla.
        /// Pokud není jméno nebo příjmení zadáno přesně, jak je v evidenci, tak se nic nevyhledá (Jan není jan)
        /// </summary>
        public void VyhledejPojisteneho()     // CASE 3
        {
            Console.WriteLine("\nZadejte jméno nebo příjmení pojištěného: ");
            string hledaneJmeno;
            while (string.IsNullOrWhiteSpace(hledaneJmeno = Console.ReadLine().Trim()) || hledaneJmeno.All(char.IsLetter) == false)
            {
                Console.WriteLine("Zadejte znovu");
            }

            List<Osoba> pojistenci = pojisteneOsoby.NajdiKonkretniOsoby(hledaneJmeno);
            if (pojistenci.Count > 0)
            {
                Console.WriteLine("\nNalezeni následující pojištěnci:");
                foreach (Osoba o in pojistenci)
                    Console.WriteLine(o);
                Console.WriteLine("\nPokračujte klávesou ENTER");
            }
            else
                Console.WriteLine("\nNebyl nalezen žádný pojištěnec.\n\nPokračujte klávesou ENTER");
        }


        /// <summary>
        /// CASE 4 - vymaže konkrétní pojištěné na základě jména nebo příjmení
        /// jmeno, prijmeni - projdou pouze abecední znaky. Neprojdou prázdné znaky, Enter, čísla.
        /// Pokud není jméno nebo příjmení zadáno přesně, jak je v evidenci, tak se nic nesmaže (Jan není jan)
        /// </summary>
        public void VymazPojisteneho()
        {
            Console.WriteLine("\nZadejte jméno nebo příjmení pojištěných, které chcete smazat: ");
            string hledaneJmeno;
            while (string.IsNullOrWhiteSpace(hledaneJmeno = Console.ReadLine().Trim()) || hledaneJmeno.All(char.IsLetter) == false)
            {
                Console.WriteLine("Zadejte znovu");
            }

            pojisteneOsoby.VymazKonkretniOsoby(hledaneJmeno);
            Console.WriteLine("\nPokračujte klávesou ENTER");

        }

        /// <summary>
        /// CASE 5 - vymaže všechny pojištěné z evidence
        /// Vymazání všech pojištěncýh se musí potvrtid (A/a) nebo se dá ještě zrušit (N/n)
        /// </summary>
        public void VymazVsechnyPojistene() // CASE 5
        {
            bool pokracovani = true;
            bool platnaVolba = true;
            Console.WriteLine("\nOpravdu chcete vymazat všechny pojištěné? [a/n]");

            platnaVolba = false;
            while(!platnaVolba)
            {
                switch(Console.ReadKey().KeyChar.ToString().ToLower())
                {
                    case "a":
                        pokracovani = true;
                        platnaVolba = true;
                        pojisteneOsoby.VymazVsechnyOsoby();
                        Console.WriteLine("\nVšichni pojištění smazáni!\n\nPokračujte klávesou ENTER");
                        break;
                    case "n":
                        pokracovani = false;
                        platnaVolba = true;
                        Console.WriteLine("\nNikdo nebyl smazán!\n\nPokračujte klávesou ENTER");
                        break;
                    default:
                        Console.WriteLine("\nNeplatná volba, zadejte prosím [a/n]");
                        break;
                }
            }
        }
    }
}
