using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGenerator
{
    public class CardHolder
    {
        public string HolderEmail;
        public string HolderName;

        int _CVV = 0;

        public int CVV
        {
            get
            {
                if(_CVV != 0)
                {
                    return _CVV;
                }
                else
                {
                    // Defines _CVV with random number generator
                    _CVV = new Random().Next(111, 999);

                    // Returns the stored value for the CVV
                    return _CVV;
                }
            }
            set
            {
                _CVV = value;
            }
        }

        string _CardNumber = string.Empty;

        public string CardNumber
        {
            get
            {
                if (_CardNumber != string.Empty)
                {
                    return _CardNumber;
                }
                else
                {

                    // Creates a instance of random class
                    Random rnd = new Random();

                    // Build a string that will hold the random generated numbers
                    _CardNumber = $"{rnd.Next(1111, 9999)} {rnd.Next(1111, 9999)} {rnd.Next(1111, 9999)} {rnd.Next(1111, 9999)}";

                    // Returns the card number
                    return _CardNumber;
                }
            }
            set
            {
                _CardNumber = value;
            }
        }

        string _Brand = string.Empty;

        public string Brand
        {
            get
            {
                if (_Brand != string.Empty)
                {
                    return _Brand;
                }
                else
                {
                    // Creates a instance of random class
                    Random rnd = new Random();

                    // Creates a list that has all the credit card brands
                    string[] brands = { "VISA", "MASTERCARD", "AMEX", "ELO" };

                    // Randomly choose the value of the brands list and store it at the _Brand var
                    _Brand =  brands[rnd.Next(brands.Length)];

                    // Returns the value
                    return _Brand;
                }
            }
            set
            {
                _Brand = value;
            }
        }

        /// <summary>
        /// Returns a card that matches the given email
        /// </summary>
        /// <param name="email">Email param</param>
        /// <param name="Cardlist">Cards list</param>
        /// <returns></returns>
        public CardHolder GetByEmail(string email, HashSet<CardHolder> Cardlist)
        {
            // If a card has been created return it using this var
            CardHolder newCard = null;
            // Try to perform a search using LINQ and passing email as parameter
            var res = from c in Cardlist where c.HolderEmail == email select c;

            // Check if the list has any result
            bool found = res.ToArray().Length > 0;

            // Checks if has been found
            if (found)
            {
                // Instantiate new card object
                newCard = new CardHolder();

                foreach (var c in res)
                {
                    newCard.CardNumber = c.CardNumber;
                    newCard.HolderEmail = c.HolderEmail;
                    newCard.HolderName = c.HolderName;
                    newCard.CVV = c.CVV;
                    newCard.Brand = c.Brand;
                }
            }

            // Returns the choosen card
            return newCard;
        }

        public HashSet<CardHolder> GenerateRandom(int count)
        {
            HashSet<CardHolder> tempCards = new HashSet<CardHolder>();

            for(int i = 0; i < count; i++)
            {
                CardHolder card = new CardHolder
                {
                    HolderEmail = "RANDOM_" + i + "@gmail.com",
                    HolderName = "RANDOM " + i + " NAME"
                };

                tempCards.Add(card);
            }

            return tempCards;
        }

    }
}
