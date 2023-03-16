using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePojistenych
{
    internal class PojisteneOsoby
    {
       /// <summary>
       /// Seznam pro pojištěnce z třídy "Osoba.cs"
       /// </summary>
        private List<Osoba> pojistenci;

        /// <summary>
        /// 
        /// </summary>
        public PojisteneOsoby()
        {
            pojistenci = new List<Osoba>();
        }


        /// <summary>
        /// Pridání nového pojištěnce
        /// </summary>
        /// <param name="jmeno">Jméno</param>
        /// <param name="prijmeni">Příjmení</param>
        /// <param name="vek">Věk</param>
        /// <param name="telefon">Telefon</param>
        public void PridejOsobu(string jmeno, string prijmeni, int vek, string telefon)
        {
            pojistenci.Add(new Osoba(jmeno, prijmeni, vek, telefon));
        }

        /// <summary>
        /// Vyhledává všechny pojištěné v seznamu
        /// </summary>
        /// <returns>Kompletní seznam pojištěných</returns>
        public List<Osoba> NajdiOsoby()
        {
            List<Osoba> nalezene = new List<Osoba>();
            foreach (Osoba o in pojistenci)
            {
                nalezene.Add(o);
            }
            return nalezene;
        }

        /// <summary>
        /// Vyhledá konkrétní pojištěnce podle jméno nebo příjmení
        /// </summary>
        /// <param name="jmenoNeboPrijmeni">Jméno nebo příjmení</param>
        /// <returns>Pojištěnce, které splňují vyhledávací kritérium</returns>
        public List<Osoba> NajdiKonkretniOsoby(string jmenoNeboPrijmeni)
        {
            List<Osoba> nalezeneKonkretni = new List<Osoba>();
            foreach (Osoba o in pojistenci)
            {
                if ((jmenoNeboPrijmeni == o.Jmeno) || (jmenoNeboPrijmeni == o.Prijmeni))
                    nalezeneKonkretni.Add(o);
            }
            return nalezeneKonkretni;
        }

        /// <summary>
        /// Vymaže konkrétní pojištěnce podle jméno nebo příjmení
        /// </summary>
        /// <param name="prijmeniNeboJmeno">Jméno nebo příjmení</param>
        public void VymazKonkretniOsoby(string prijmeniNeboJmeno)
        {
            List<Osoba> nalezeno = NajdiKonkretniOsoby(prijmeniNeboJmeno);
            foreach (Osoba o in nalezeno)
                pojistenci.Remove(o);
        }


        /// <summary>
        /// Vymaže všechny pojištěnce
        /// </summary>
        /// <returns>Vrátí prázdný seznam pojištěnců</returns>
        public List<Osoba> VymazVsechnyOsoby()
        {
            pojistenci.Clear();
            return pojistenci;
        }

    }
}
