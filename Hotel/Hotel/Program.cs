using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Hotel
{

    class Program
    {
        static Hotel hotel1 = new Hotel();
        static char klawisz = 'k';
        static void Main(string[] args)
        {

            Wykonaj();
            
        }
        
        private static void WczytajKlawisz()
        {
           
            Console.WriteLine("Co chcesz zrobić?");
            Console.WriteLine("A - ustaw datę.");
            Console.WriteLine("B - dodaj rezerwację.");
            Console.WriteLine("C - usuń rezerwację.");
            Console.WriteLine("D - wypisz rezerwację.");
            Console.WriteLine("X - zakończ program.");
            klawisz = Convert.ToChar(Console.ReadLine());
        }
        public static void Wykonaj()
        {
            
            while(true)
            {
                WczytajKlawisz();
                switch (klawisz)
                {
                    case'A':
                    case 'a': Data(); Continue(); break;
                    case'B':
                    case 'b': Rezerwacja(); Continue(); break;
                    case'C':
                    case 'c': hotel1.OdwolajRezerwacje(); Continue(); break;
                    case'D':
                    case 'd': hotel1.ToString(); Continue(); break;
                    case'X':
                    case 'x': return;
                }
            }
        }
            
            public static void Data()
            {
                
                DateTime data;
                do
                {
                    Console.WriteLine("Podaj datę rezerwacji w formacie 16.01.2018");
                    string wejscie = Console.ReadLine();
                    string format = "dd.MM.yyyy";
                    DateTime.TryParseExact(wejscie, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out data);
                    hotel1.UstawDate(data);
                    if (!hotel1.SprawdzDate()) Console.WriteLine("Data rezerwacji nie może być ani dzisiejsza, ani wcześniejsza.");

                    //int rok=-1,miesiac=-1,dzien=-1;
                    //Console.WriteLine("Podaj datę rezerwacji w formacie rok, miesiąc, dzień, np. 2018.02.04.");
                    //Console.Write("Najpierw podaj liczbę oznaczającą rok: ");
                    //bool czyPoprawna = false;
                    //while(!czyPoprawna)
                    //{
                    //    czyPoprawna = true;
                    //    try
                    //    {
                    //        rok = Convert.ToInt32(Console.ReadLine());
                    //    }
                    //    catch (Exception e)
                    //    {
                    //        Console.WriteLine(e.Message); czyPoprawna = false;
                    //    }
                    //    Console.Write("Teraz podaj liczbę oznaczającą miesiąc: ");
                    //    try
                    //    {
                    //        miesiac = Convert.ToInt32(Console.ReadLine());
                    //    }
                    //    catch (Exception e)
                    //    {
                    //        Console.WriteLine(e.Message); czyPoprawna = false;
                    //    }
                    //    Console.Write("Teraz podaj liczbę oznaczającą dzień miesiąca: ");
                    //    try
                    //    {
                    //        dzien = Convert.ToInt32(Console.ReadLine());
                    //    }
                    //    catch (Exception e)
                    //    {
                    //        Console.WriteLine(e.Message); czyPoprawna = false;
                    //    }

                    //    if (miesiac == 02 && dzien > 29)
                    //    {
                    //        Console.WriteLine("Luty nie ma więcej niż 29 dni.");
                    //        czyPoprawna = false;
                    //    }
                    //    if (!(rok % 400 == 0) && miesiac == 02 && dzien == 29)
                    //    {
                    //        Console.WriteLine("Rok {0} nie jest rokiem przestępnym.", rok);
                    //        czyPoprawna = false;
                    //    }
                    //    if((miesiac==04||miesiac==06||miesiac==09||miesiac==11)&&dzien>30)
                    //    {
                    //        Console.WriteLine("Miesiąc {0} ma tylko 30 dni.", miesiac);
                    //        czyPoprawna = false;
                    //    }

                                             
                    //}

                    //data = new DateTime(rok, miesiac, dzien);
                    //hotel1.UstawDate(data);
                    //if (!hotel1.SprawdzDate()) Console.WriteLine("Data rezerwacji nie może być ani dzisiejsza, ani wcześniejsza.");

                } while (!hotel1.SprawdzDate());
            }
            
            public static void Rezerwacja()
            {
                
                Console.WriteLine("Podaj imię Gościa.");
                string imie = Console.ReadLine();
                Console.WriteLine("Podaj nazwisko Gościa.");
                string nazwisko = Console.ReadLine();
                int nrPokoju;
                double cenaZaDzien;
                
                bool czyDodatnia = false;
                do
                {
                    Console.WriteLine("Podaj numer pokoju.");
                    nrPokoju = Convert.ToInt32(Console.ReadLine());
                    if (nrPokoju > 0) czyDodatnia = true;
                    else Console.WriteLine("Numer pokoju nie może być taką liczbą: {0}!", nrPokoju);
                } while (!czyDodatnia);

                czyDodatnia = false;
                do
                {
                    Console.WriteLine("Podaj cenę za dzień.");
                    cenaZaDzien = Convert.ToDouble(Console.ReadLine());
                    if (cenaZaDzien > 0) czyDodatnia = true;
                    else Console.WriteLine("Cena za dzień nie może być taką liczbą: {0}!", cenaZaDzien);
                } while (!czyDodatnia);
                
                hotel1.DodajRezerwacje(imie, nazwisko, nrPokoju, cenaZaDzien);
                

            }
        private static void Continue()
            {
                Console.WriteLine("Wciśnij dowolny klawisz, aby kontynuować.");
                Console.ReadKey();
                Console.Clear();
            
            }
            
        
        }
            
    }


