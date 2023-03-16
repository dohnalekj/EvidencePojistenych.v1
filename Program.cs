using EvidencePojistenych;
using System.ComponentModel;
using System.Xml.Schema;

Evidence evidence = new Evidence();
char volba = '0';

//hlavní cycklus
while (volba != '9')
{
    evidence.VypisUvodniObrazovku();
    Console.WriteLine("Vyberte si akci:");
    Console.WriteLine("1 - Přidat nového pojištěného");
    Console.WriteLine("2 - Vypsat všechny pojištěné");
    Console.WriteLine("3 - Vyhledat pojištěného");
    Console.WriteLine("4 - Vymazat pojištěného");
    Console.WriteLine("5 - Vymazat VŠECHNY pojištěné");
    Console.WriteLine("9 - Konec");

    volba = Console.ReadKey().KeyChar;
    Console.WriteLine();

    //reakce na volbu

    switch (volba)
    {
        case '1':
            evidence.PridejPojisteneho();
            break;
        case '2':
            evidence.VypisPojistene();
            break;
        case '3':
            evidence.VyhledejPojisteneho();
            break;
        case '4':
            evidence.VymazPojisteneho();
            break;
        case '5':
            evidence.VymazVsechnyPojistene();
            break;
        case '9':
            Console.WriteLine("\nPro ukončení stiskněte ENTER...");
            break;
        default:
            Console.WriteLine("\nNeplatná volba. Stiskněte libovelnou klávesu a opakujte volbu dle nápovědy.");
            break;
    }
    Console.ReadLine();
}