using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePojistenych
{
    internal class Osoba
    {
        /// <summary>
        /// Jméno pojištěnce
        /// </summary>
        public string Jmeno { get; set; }

        /// <summary>
        /// Příjmení pojištěnce 
        /// </summary>
        public string Prijmeni { get; set; }

        /// <summary>
        /// Věk pojištěnce
        /// </summary>
        public int Vek { get; set; }

        /// <summary>
        /// Telefon pojištěného
        /// </summary>
        public string Telefon { get; set; }
        
        /// <summary>
        /// Vytvoření pojištěnce s parametry níže:
        /// </summary>
        /// <param name="jmeno">Jméno p</param>
        /// <param name="prijmeni">Příjmení</param>
        /// <param name="vek">Věk</param>
        /// <param name="telefon">Telefon</param>
        public Osoba(string jmeno, string prijmeni, int vek, string telefon)
        {
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            Vek = vek;
            Telefon = telefon;
        }

        /// <summary>
        /// Textový formát pojištěnce
        /// </summary>
        /// <returns>formát pojištěnce včetně tabulátorů</returns>
        public override string ToString()
        {
            return Jmeno.PadRight(15) + Prijmeni.PadRight(15) + Vek + "\t " + Telefon;
        }

    }
}
