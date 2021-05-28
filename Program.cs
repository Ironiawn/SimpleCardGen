using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "CardGenerator C#";

            // Cards list
            HashSet<CardHolder> Cards = new HashSet<CardHolder>();// to generate a random card list: new CardHolder().GenerateRandom(30);

            // Create an example card
            Cards.Add(new CardHolder
            {
                HolderEmail = "BUTTON@GMAIL.COM",
                HolderName  = "JASON BUTTON"
            });

            // Create an example card
            Cards.Add(new CardHolder
            {
                HolderEmail = "bautchs@gmail.com",
                HolderName = "JOSEPH BAUTCHS"
            });

        ListCards:

            foreach (CardHolder card in Cards)
            {
                Console.WriteLine("#############################################");
                Console.WriteLine($"Nome: {card.HolderName}\nEmail: {card.HolderEmail}\nCVV: {card.CVV}\nNúmero: {card.CardNumber}\nBandeira: {card.Brand}");
                Console.WriteLine("#############################################");
            }

            #region ADD NEW CARD
            /*
            Console.WriteLine("## GOING TO 'INSERT NEW CARD FUNCTION' ##");

            Console.WriteLine("INSERT HOLDER E-MAIL AND PRESS 'ENTER'");

            string hEmail = Console.ReadLine();

            Console.WriteLine("INSERT HOLDER NAME AND PRESS 'ENTER'");

            string hName = Console.ReadLine();

            Cards.Add(new CardHolder
            {
                HolderEmail = hEmail,
                HolderName = hName
            });
            */
            #endregion

            Console.WriteLine("INPUT AN EMAIL TO SEARCH FOR A CARD");
            string email = Console.ReadLine();

            CardHolder c = new CardHolder().GetByEmail(email, Cards);

            if(c != null)
            {
                Console.WriteLine("############### SEARCH OK !! ######################");
                Console.WriteLine($"Nome: {c.HolderName}\nEmail: {c.HolderEmail}\nCVV: {c.CVV}\nNúmero: {c.CardNumber}\nBandeira: {c.Brand}");
                Console.WriteLine("#############################################");
            }
            else
            {
                Console.WriteLine("############### DO CARD AVAILABLE ON THE LIST ######################");
            }

            goto ListCards;
        }
    }
}
