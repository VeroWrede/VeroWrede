using System.Collections.Generic;
using System;

namespace Cards
{
    public class Deck 
    {
        List<string> Cards = new List<string>();
        List<string> UsedCards = new List<string>();

        public Deck (List<string> cards)
        {
            foreach (string card in cards) {
                if (!Cards.Contains(card)) 
                {
                    Cards.Add(card);
                };
            };
            if (Cards.Count < 52) 
            { 
                
                Console.WriteLine("this is not a full set of cards");
            };

            UsedCards = Cards;
        }

        public string DealCard (List<string> UsedCards)
        {
            string card = UsedCards[0];
            Console.WriteLine(UsedCards[0]);
            UsedCards.RemoveAt(0);
            return card;
        }

        public void Reset() 
        {
            UsedCards = Cards;
        }

        public List<string> Shuffle(List<string> Cards)
        {
            List<string> Temp = new List<string>();
            Random rand = new Random();
            for (int i = 52; i >= 0; i--)
            {
                int index = rand.Next(0, i + 1);
                Temp.Add(Cards[index]);
                Cards.RemoveAt(index);
            };

            return Temp;
        }
    }
}