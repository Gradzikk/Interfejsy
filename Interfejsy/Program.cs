using System;
using System.Collections.Generic;
using System.Threading.Tasks;
public interface IKalkulator
{
    int Dodaj(int a, int b);
    int Odejmij(int a, int b);
}

public class ProstyKalkulator : IKalkulator
{
    public int Dodaj(int a, int b)
    {
        return a + b;
    }

    public int Odejmij(int a, int b)
    {
        return a - b;
    }
}
public interface IDzialanieMatematyczne
{
    int WykonajDzialanie(int a, int b);
}

public interface ILogowanie
{
    void Zaloguj(string komunikat);
}

public interface IStatystyki
{
    void PokazStatystyki();
}

public class ZaawansowanyKalkulator : IDzialanieMatematyczne, ILogowanie, IStatystyki
{
    public int WykonajDzialanie(int a, int b)
    {

        return a * b;
    }

    public void Zaloguj(string komunikat)
    {
        Console.WriteLine("Log: " + komunikat);
    }

    public void PokazStatystyki()
    {
        Console.WriteLine("Statystyki: ...");
    }
}


    public interface IDrukarka
    {
        void Drukuj();
    }

    public class DrukarkaLaserowa : IDrukarka
    {
        void IDrukarka.Drukuj()
        {
            Console.WriteLine("Drukowanie za pomocą IDrukarka.Drukuj()");
        }

        public void Drukuj()
        {
            Console.WriteLine("Drukowanie za pomocą własnej metody Drukuj()");
        }
    }

    public interface IDzwiek
    {
        void OdtwarzajDzwiek();
    }

    public class Samochod : IDzwiek
    {
        public void OdtwarzajDzwiek()
        {
            Console.WriteLine("Odtwarzanie dźwięku w samochodzie");
        }
    }

    public class Telefon : IDzwiek
    {
        public void OdtwarzajDzwiek()
        {
            Console.WriteLine("Odtwarzanie dźwięku na telefonie");
        }
    }

    class Program
    {
        static void Main()
        {
            List<IDzwiek> urzadzenia = new List<IDzwiek>();
            urzadzenia.Add(new Samochod());
            urzadzenia.Add(new Telefon());

            foreach (var urzadzenie in urzadzenia)
            {
                urzadzenie.OdtwarzajDzwiek();
            }
        }
    }


    public interface ILogowanie2
    {
        void Loguj(string komunikat);
    }

    public class Uzytkownik
    {
        public string Imie { get; set; }
    }

    public static class RozszerzeniaLogowania
    {
        public static void Loguj(this ILogowanie2 logowanie, Uzytkownik uzytkownik)
        {
            logowanie.Loguj($"Użytkownik {uzytkownik.Imie} zalogowany.");
        }
    }

    class Program1
    {
        static void Main1()
        {
            Uzytkownik uzytkownik = new Uzytkownik { Imie = "Jan" };
            Loger loger = new Loger();
            loger.Loguj(uzytkownik);
        }
    }

    public class Loger : ILogowanie2
    {
        public void Loguj(string komunikat)
        {
            Console.WriteLine(komunikat);
        }
}





public interface IRepozytorium<T>
{
    void Dodaj(T element);
    T Pobierz(int indeks);
    void Aktualizuj(int indeks, T element);
    void Usun(int indeks);
}

public class Repozytorium<T> : IRepozytorium<T>
{
    private List<T> kolekcja = new List<T>();

    public void Dodaj(T element)
    {
        kolekcja.Add(element);
    }

    public T Pobierz(int indeks)
    {
        return kolekcja[indeks];
    }

    public void Aktualizuj(int indeks, T element)
    {
        kolekcja[indeks] = element;
    }

    public void Usun(int indeks)
    {
        kolekcja.RemoveAt(indeks);
    }
}


public interface IZarzadzanieAsynchroniczne
{
    Task WykonajAkcjeAsynchronicznie();
    Task<string> PobierzDaneAsynchronicznie();
}

public class ImplementacjaAsynchroniczna : IZarzadzanieAsynchroniczne
{
    public async Task WykonajAkcjeAsynchronicznie()
    {
        Console.WriteLine("Wykonuję akcję asynchroniczną...");
        await Task.Delay(2000);
        Console.WriteLine("Akcja asynchroniczna zakończona.");
    }

    public async Task<string> PobierzDaneAsynchronicznie()
    {
        Console.WriteLine("Pobieram dane asynchronicznie...");
        await Task.Delay(3000);
        return "Pobrane dane.";
    }
}

class Program2
{
    static async Task Main2()
    {
        ImplementacjaAsynchroniczna implementacja = new ImplementacjaAsynchroniczna();
        await implementacja.WykonajAkcjeAsynchronicznie();
        string dane = await implementacja.PobierzDaneAsynchronicznie();
        Console.WriteLine("Otrzymane dane: " + dane);
    }
}