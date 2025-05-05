using System;

namespace oddOrEven
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int anzahlDices = Convert.ToInt32(Abfrage("Wie viele Würfeln sollen genutzt werden?"));
            
            int seiten = Convert.ToInt32(Abfrage("Wie viele Seiten soll der Würfel haben?"));
            
            Dice game1 = new Dice(anzahlDices, seiten);
            
            bool spielen = false;
            do
            {
                Console.Clear();
                
                Game(game1);
                
                switch (Abfrage("möchtest du nochmal spielen?  [y/n]"))
                {
                    case "y" or "yes" or "j" or "ja":
                        spielen = true;
                        break;
                    case "n" or "no" or "nein":
                        spielen = false;
                        break;
                    default:
                        ErrorMessage();
                        spielen = false;
                        break;
                }
            } while (spielen);
        }

        static void Game(Dice game)
        {
            bool einsatz;
            
            switch (Abfrage("Gerade oder Ungerade?").ToLower())
            {
                case "gerade" or "even" or "g" or "e":
                    einsatz = true;
                    break;
                case "ungerade" or "odd" or "u" or "o":
                    einsatz = false;
                    break;
                default:
                    ErrorMessage();
                    return;
            }
            Console.Clear();
            
            game.Roll();

            Console.WriteLine();
            Linie(game.NumberOfDices);
            for (int i = 0; i < game.NumberOfDices; i++)
            {
                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($" {game.ShownEyes[i]} ");
                Console.ResetColor();
                Console.Write("|");
            }
            Console.ResetColor();
            Console.WriteLine();
            Linie(game.NumberOfDices);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($" summe: {game.Sum}\n");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Thread.Sleep(500);
            if (game.Even)
                Console.WriteLine(" Es ist gerade");
            else
                Console.WriteLine(" Es ist ungerade");

            Thread.Sleep(500);
            if(game.Even == einsatz)
                Console.WriteLine(" DU HAST GEWONNEN  \\(^-^)/");
            else
                Console.WriteLine(" Du hast verloren :(");
            Console.ResetColor();

        }

        static void Linie(int length)
        {
            for(int i =0; i<length*4; i++)
                Console.Write("-");
            Console.WriteLine(" ");
        }

        static string Abfrage(string frage)
        {
            Console.WriteLine($"\n {frage}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string input = Console.ReadLine();
            Console.ResetColor();
            Console.Clear();

            return input;
        }
        static void ErrorMessage()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n Ungültige eingabe");
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();
        }
    }
}