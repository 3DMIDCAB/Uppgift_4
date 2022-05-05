using System;//Namespace System måste vara skrivet med stort S så jag ändrade från litet s till stort S. 
using System.Collections.Generic;

namespace Uppgift_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Skapar en bool med namnet spelaIgen för hantering om användaren väljer att spela igen.
            bool spelaIgen = true;

            //Skapar en lista av typen integer med namnet poängLista, lägger den utanför while loopen för att listan ska spara poängen för varje spelomgång. 
            List<int> poängLista = new List<int>();

            //Skapar en while sats som loopar så länge användaren inte väljer att avsluta spelet.
            while (spelaIgen)

            {
                // Deklaration av variabler
                Random slumpat = new Random(); // skapar ett random objekt
                                               //Programmet saknade intervall värdena 1 och 20, vilket gjorde att programmet inte slumpade enbart tal mellan 1-20, så jag skrev in siffran 1, 20. 
                int speltal = slumpat.Next(1, 20); // anropar Next metoden för att skapa ett slumptal mellan 1 och 20
                                                   // läs på, vad är overload metoder? https://msdn.microsoft.com/en-us/library/system.random.next(v=vs.110).aspx
                bool spela = true; // Variabel för att kontrollera om spelet ska fortsätta köras
                int tal = 0; //Variabel skapas och tilldelas värdet 0 pga variablers livslängd, variabeln skulle annars enbart existera inne i kodblocket try.
                int räknaAntaletGissningar = 0;
                while (spela)//while loopen var fel då det stod !spela, vilket gör att villkoret inte uppfylls och programmet hoppar över kodblocken. 
                {
                    Console.Write("\n\tGissa på ett tal mellan 1 och 20: ");
                    //Använder ett TryCatch block för felhantering i de fall användaren anger annat än siffror.
                    try
                    {
                        tal = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine("\tError! Du måste ange ett tal mellan 1 och 20 med sifror!"); //Om användaren skriver annat än siffror skriver programmet ut ett felmeddelande.
                        Console.WriteLine(error);
                        Console.WriteLine(""); //Jag la till en tom rad efter felmeddelandet för att få lite luft vid utskriften till konsolfönstret.
                    }
                    if (tal < speltal)
                    {
                        räknaAntaletGissningar++;
                        Console.WriteLine("\tDet inmatade talet " + tal + " är för litet, försök igen.");

                    }

                    if (tal > speltal)
                    {
                        räknaAntaletGissningar++;
                        Console.WriteLine("\tDet inmatade talet " + tal + " är för stort, försök igen."); //Saknades + tecken efter variabeln tal vilket gör att ihopvävningen ej fungerar.
                    }

                    if (tal == speltal) //Felet var att det endast var 1 = vilket gör att programmet försöker att tilldela ett värde istället för med 2st = där programmet nu försöker jämföra värdet.
                    { //öppnande klammerparentes saknades så kodblocken fungerade ej eftersom det var mer än 1 rad i if satsen.
                        Console.WriteLine("\tGrattis, du gissade rätt!");

                        //Skriver ut antalet gånger som användaren gissade. 
                        Console.WriteLine("\tDu gissade " + räknaAntaletGissningar + " gånger!");

                        //Adderar spelomgångens antal gissningar till poängListan.
                        poängLista.Add(räknaAntaletGissningar);

                        //Lägger in en sortering av poängListan så att den lägsta poängen alltid visas överst i highscore tavlan.
                        poängLista.Sort();

                        //Skriver highscore tavlan till konsolfönstret. 
                        Console.WriteLine("\tHighscore tavlan: ");

                        //Använder en foreach loop för att loopa igenom och skriva ut varje poäng från poängListan.
                        foreach (int poäng in poängLista)
                        {
                            Console.WriteLine("\t" + poäng + " gissningar");
                        }

                        // Frågar användaren om den vill spela igen.
                        Console.Write("\tVill du spela igen? j/n ");

                        //Skapar en string variabel med namnet spelaIgen.
                        string spelaVidare = Console.ReadLine();

                        //Använder en OM sats för att kontrollera användarens svar. 
                        if (spelaVidare == "j")
                        {
                            spelaIgen = true;
                        }
                        else
                        {
                            spelaIgen = false;
                        }
                        spela = false;

                    } //Stängande klammerparentes saknades så kodblocken fungerade ej eftersom det är mer än 1 rad i if satsen.

                }

            }
        }
    }
}
